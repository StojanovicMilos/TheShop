using System;
using TheShop.BL.Interfaces;

namespace TheShop.BL.ArticleSeller
{
    public class ArticleSeller : IArticleSeller
    {
        private readonly IArticleSellerDatabaseDriver _databaseDriver;

        public ArticleSeller(IDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver;
        }

        public OperationResult<Article.Article> SellArticle(Article.Article article, OrderAndSellRequest orderAndSellRequest)
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