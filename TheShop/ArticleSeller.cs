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
            var articleSellResult = article.Sell(soldDate, orderAndSellRequest.BuyerId);
            if (!articleSellResult.Successful)
                return articleSellResult;

            var databaseSaveResult = _databaseDriver.Save(article);
            if (!databaseSaveResult.Successful)
            {
                article.CancelSellTransaction();
            }

            return databaseSaveResult;
        }
    }
}