using System;
using TheShop.BL.Interfaces;

namespace TheShop.BL.ArticleSeller
{
    public class LoggingArticleSeller : IArticleSeller
    {
        private readonly IShopServiceLogger _logger;
        private readonly IArticleSeller _articleSeller;

        public LoggingArticleSeller(IShopServiceLogger logger, IArticleSeller articleSeller)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _articleSeller = articleSeller ?? throw new ArgumentNullException(nameof(articleSeller));
        }

        public OperationResult<Article.Article> SellArticle(Article.Article article, SellRequest sellRequest)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            _logger.Debug("Trying to sell article with ID = " + sellRequest.SellArticleId);
            var result = _articleSeller.SellArticle(article, sellRequest);
            _logger.Info("Article with ID = " + sellRequest.SellArticleId + " is sold.");
            return result;
        }
    }
}