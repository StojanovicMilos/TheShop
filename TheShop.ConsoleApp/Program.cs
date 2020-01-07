using System;
using System.Collections.Generic;
using TheShop.BL.Article;
using TheShop.BL.ArticleSeller;
using TheShop.BL.ArticleService;
using TheShop.BL.Interfaces.BL;
using TheShop.BL.Interfaces.Utility;
using TheShop.BL.ShopService;
using TheShop.BL.SuppliersService;
using TheShop.DAL;

namespace TheShop.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            Client client = GetDefaultClient();

            SellRequest sellRequest = new SellRequest(1, 10, DateTime.Now, 458);
            List<int> getArticleIds = new List<int> { 1, 12 };
            client.DoShopping(sellRequest, getArticleIds);

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
                    new LoggingArticleSeller(new ConsoleArticleSellerLogger(), new ArticleSeller(databaseDriver))),
                new ConsoleClientLogger(), new ArticleService(databaseDriver));
        }
    }
}