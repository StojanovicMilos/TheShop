using System;
using TheShop.Models;

namespace TheShop
{
    public class ArticleSeller : IArticleSeller
    {
        private readonly IDatabaseDriver _databaseDriver;

        public ArticleSeller(IDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver;
        }

        public OperationResult<Article> SellArticle(Article article, OrderAndSellRequest orderAndSellRequest)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));

            DateTime soldDate = DateTime.Now;
            article.Sell(soldDate, orderAndSellRequest.BuyerId);
            return _databaseDriver.Save(article);
        }
    }
}