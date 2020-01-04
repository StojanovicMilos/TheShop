using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop
{
	public class ShopService : IShopService
	{
		private readonly DatabaseDriver _databaseDriver;
		private readonly Logger _logger;
		private List<ISupplier> _suppliers;

		public ShopService()
		{
			_databaseDriver = new DatabaseDriver();
			_logger = new Logger();
			_suppliers = new List<ISupplier>()
			{
				new Supplier1(),
				new Supplier2(),
				new Supplier3()
			};
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
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

		public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}
}