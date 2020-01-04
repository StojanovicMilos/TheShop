using System;
using System.Collections.Generic;

namespace TheShop
{
    public static class Program
    {
        public static void Main()
        {
            Client client = new Client(new ShopService(new ConsoleShopServiceLogger()), new ConsoleClientLogger());

            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest {OrderAndSellArticleId = 1, BuyerId = 10};
            List<int> getArticleIds = new List<int> {1, 12};
            client.DoShopping(orderAndSellRequest, getArticleIds);

            Console.ReadKey();
        }
    }
}