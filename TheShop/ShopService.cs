using System;
using TheShop.Models;

namespace TheShop
{
    public class ShopService : IShopService
	{
		private readonly IDatabaseDriver _databaseDriver;
		private readonly IShopServiceLogger _logger;
		private readonly ISupplier _supplier;

	    public ShopService(IDatabaseDriver databaseDriver, IShopServiceLogger logger, ISupplier supplier)
	    {
	        _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
	        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
	        _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
	    }

		public void OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest)
		{
		    int id = orderAndSellRequest.OrderAndSellArticleId;
		    int buyerId = orderAndSellRequest.BuyerId;

			#region ordering article

		    Article article = _supplier.OrderArticle(id);

			#endregion

			#region selling article

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			_logger.Debug("Trying to sell article with ID = " + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_databaseDriver.Save(article);
				_logger.Info("Article with ID = " + id + " is sold.");
			}
			catch (Exception)
			{
				string errorMessage = "Could not save article with ID = " + id;
				_logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}

			#endregion
		}

		public Article GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
	}
}