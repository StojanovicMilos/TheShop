using System;
using TheShop.Models;

namespace TheShop
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

        public OrderAndSellArticleResult SellArticle(Article article, OrderAndSellRequest orderAndSellRequest)
        {
            _logger.Debug("Trying to sell article with ID = " + orderAndSellRequest.OrderAndSellArticleId);
            var result = _articleSeller.SellArticle(article, orderAndSellRequest);
            _logger.Info("Article with ID = " + orderAndSellRequest.OrderAndSellArticleId + " is sold.");
            return result;
        }
    }
}