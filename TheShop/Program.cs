using System;
using System.Collections.Generic;
using TheShop.Suppliers;

namespace TheShop
{
    public static class Program
    {
        public static void Main()
        {
            Client client = GetDefaultClient();

            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest {OrderAndSellArticleId = 1, BuyerId = 10};
            List<int> getArticleIds = new List<int> {1, 12};
            client.DoShopping(orderAndSellRequest, getArticleIds);

            Console.ReadKey();
        }

        public static Client GetDefaultClient() => new Client(new ShopService(
                new DatabaseDriver(),
                new ConsoleShopServiceLogger(),
                new List<ISupplier>
                {
                    new Supplier1(), new Supplier2(), new Supplier3()
                }),
            new ConsoleClientLogger());
    }
}