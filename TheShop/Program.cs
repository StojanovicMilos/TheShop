using System;

namespace TheShop
{
    public static class Program
	{
		private static IShopService _shopService;

	    public static void Main()
	    {
	        const int orderAndSellArticleId = 1;
	        const int maxExpectedPrice = 20;
	        const int buyerId = 10;
	        const int getArticleId = 12;

	        DoShopping(orderAndSellArticleId, maxExpectedPrice, buyerId, getArticleId);
	        Console.ReadKey();
	    }

	    public static void DoShopping(int orderAndSellArticleId, int maxExpectedPrice, int buyerId, int getArticleId)
	    {
	        _shopService = new ShopService();

	        try
	        {
	            //order and sell
	            _shopService.OrderAndSellArticle(orderAndSellArticleId, maxExpectedPrice, buyerId);
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
	            var article = _shopService.GetById(getArticleId);
	            if (article == null)
	            {
	                Console.WriteLine("Article with ID: " + getArticleId + " not found.");
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
	    }
	}
}