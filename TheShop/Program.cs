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

            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest {OrderAndSellArticleId = 1, BuyerId = 10};
            List<int> getArticleIds = new List<int> {1, 12};
            client.DoShopping(orderAndSellRequest, getArticleIds);

            Console.ReadKey();
        }

        public static Client GetDefaultClient() => new Client(new ShopService(
                new DatabaseDriver(),
                new ConsoleShopServiceLogger(),
                new Suppliers(new List<ISupplier>
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
                })),
            new ConsoleClientLogger());
    }
}