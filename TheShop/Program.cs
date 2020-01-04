using System;
using System.Collections.Generic;

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
	        List<int> getArticleIds = new List<int> {1, 12};

	        DoShopping(orderAndSellRequest, getArticleIds);
	        Console.ReadKey();
	    }

	    public static void DoShopping(OrderAndSellRequest orderAndSellRequest, IEnumerable<int> getArticleIds)
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

	        foreach (var articleId in getArticleIds)
	        {
	            var article = _shopService.GetById(articleId);
	            if (article == null)
	            {
	                Console.WriteLine("Article with ID: " + articleId + " not found.");
	            }
	            else
	            {
	                Console.WriteLine("Found article with ID: " + article.ID);
	            }
            }
	    }
	}
}