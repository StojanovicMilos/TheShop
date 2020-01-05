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
                        new Supplier(new List<Article>
                        {
                            new Article
                            {
                                ArticlePrice = 458,
                                Id = 1,
                                NameOfArticle = "Article from supplier1"
                            }
                        }),
                        new Supplier(new List<Article>
                        {
                            new Article
                            {
                                ArticlePrice = 459,
                                Id = 1,
                                NameOfArticle = "Article from supplier2"
                            }
                        }),
                        new Supplier(new List<Article>
                        {
                            new Article
                            {
                                ArticlePrice = 460,
                                Id = 1,
                                NameOfArticle = "Article from supplier3"
                            }
                        })
                    }),
                    new LoggingArticleSeller(new ConsoleShopServiceLogger(), new ArticleSeller(databaseDriver))),
                new ConsoleClientLogger(), new ArticleService(databaseDriver));
        }
    }
}