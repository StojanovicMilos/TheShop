using System;

namespace TheShop
{
    public static class Program
	{
		private static IShopService _shopService;

	    public static void Main()
		{
			_shopService = new ShopService();

			try
			{
				//order and sell
				_shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = _shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = _shopService.GetById(12);
				if (article == null)
				{
					Console.WriteLine("Article with ID: " + 12 + " not found.");
				}
				else
				{
					Console.WriteLine("Found article with ID: " + article.ID);
				}
				
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}