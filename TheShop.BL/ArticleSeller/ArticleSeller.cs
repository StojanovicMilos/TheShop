using System;
using TheShop.BL.Interfaces;

namespace TheShop.BL.ArticleSeller
{
    public class ArticleSeller : IArticleSeller
    {
        private readonly IArticleSellerDatabaseDriver _databaseDriver;

        public ArticleSeller(IDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
        }

        public OperationResult<Article.Article> SellArticle(Article.Article article, SellRequest sellRequest)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            var articleSellResult = article.Sell(sellRequest.SoldDate, sellRequest.BuyerId);
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