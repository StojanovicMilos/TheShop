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

        public OperationResult<Article.Article> SellArticle(Article.Article article, OrderAndSellRequest orderAndSellRequest)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));

            _logger.Debug("Trying to sell article with ID = " + orderAndSellRequest.OrderAndSellArticleId);
            var result = _articleSeller.SellArticle(article, orderAndSellRequest);
            _logger.Info("Article with ID = " + orderAndSellRequest.OrderAndSellArticleId + " is sold.");
            return result;
        }
    }
}