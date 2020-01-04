using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop
{
	public class ShopService : IShopService
	{
		private readonly IDatabaseDriver _databaseDriver;
		private readonly IShopServiceLogger _logger;
		private readonly List<ISupplier> _suppliers;

	    public ShopService(IDatabaseDriver databaseDriver, IShopServiceLogger logger, List<ISupplier> suppliers)
	    {
	        if (suppliers == null) throw new ArgumentNullException(nameof(suppliers));
	        if (suppliers.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(suppliers));
	        _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
	        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
	        _suppliers = suppliers;
	    }

		public void OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest)
		{
		    int id = orderAndSellRequest.OrderAndSellArticleId;
		    int buyerId = orderAndSellRequest.BuyerId;

			#region ordering article

			Article article = null;
			var articlesInInventory = _suppliers.Where(s => s.ArticleInInventory(id) && !s.GetArticle(id).IsSold).ToArray();
			if (articlesInInventory.Length > 0)
			{
				var minPrice = articlesInInventory.Min(s => s.GetArticle(id).ArticlePrice);
				article = articlesInInventory.Select(s => s.GetArticle(id)).First(s => s.ArticlePrice == minPrice);
			}

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