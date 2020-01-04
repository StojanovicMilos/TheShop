using System;
using System.Collections.Generic;

namespace TheShop
{
    public static class Program
    {
        public static void Main()
        {
            Client client = new Client(new ShopService());
            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest {OrderAndSellArticleId = 1, BuyerId = 10};
            List<int> getArticleIds = new List<int> {1, 12};

            client.DoShopping(orderAndSellRequest, getArticleIds);
            Console.ReadKey();
        }
    }

    public class Client
    {
        private readonly IShopService _shopService;

        public Client(IShopService shopService)
        {
            _shopService = shopService;
        }

        public void DoShopping(OrderAndSellRequest orderAndSellRequest, IEnumerable<int> getArticleIds)
        {
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