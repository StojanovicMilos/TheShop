using System;

namespace TheShop
{
    public static class Program
	{
		private static IShopService _shopService;

	    public static void Main()
	    {
	        OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest
	        {
	            OrderAndSellArticleId = 1,
	            BuyerId = 10
	        };
	        const int getArticleId = 12;

	        DoShopping(orderAndSellRequest, getArticleId);
	        Console.ReadKey();
	    }

	    public static void DoShopping(OrderAndSellRequest orderAndSellRequest, int getArticleId)
	    {
	        _shopService = new ShopService();

	        try
	        {
	            //order and sell
	            _shopService.OrderAndSellArticle(orderAndSellRequest);
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