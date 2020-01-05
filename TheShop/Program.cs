using System;
using System.Collections.Generic;
using TheShop.Models;

namespace TheShop
{
    public static class Program
    {
        public static void Main()
        {
            Client client = GetDefaultClient();

            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest { OrderAndSellArticleId = 1, BuyerId = 10 };
            List<int> getArticleIds = new List<int> { 1, 12 };
            client.DoShopping(orderAndSellRequest, getArticleIds);

            Console.ReadKey();
        }

        public static Client GetDefaultClient()
        {
            var databaseDriver = new DatabaseDriver();
            return new Client(new ShopService(new Suppliers(new List<ISupplier>
                    {
                        new Supplier(new List<Article> {new Article(1, "Article from supplier1", 458)}),
                        new Supplier(new List<Article> {new Article(1, "Article from supplier2", 459)}),
                        new Supplier(new List<Article> {new Article(1, "Article from supplier3", 460)})
                    }),
                    new LoggingArticleSeller(new ConsoleShopServiceLogger(), new ArticleSeller(databaseDriver))),
                new ConsoleClientLogger(), new ArticleService(databaseDriver));
        }
    }
}