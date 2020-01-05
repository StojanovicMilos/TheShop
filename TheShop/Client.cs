using System;
using System.Collections.Generic;

namespace TheShop
{
    public class Client
    {
        private readonly IShopService _shopService;
        private readonly IClientLogger _clientLogger;
        private readonly IArticleService _articleService;

        public Client(IShopService shopService, IClientLogger clientLogger, IArticleService articleService)
        {
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService));
            _clientLogger = clientLogger ?? throw new ArgumentNullException(nameof(clientLogger));
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        public void DoShopping(OrderAndSellRequest orderAndSellRequest, IEnumerable<int> getArticleIds)
        {
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));
            if (getArticleIds == null) throw new ArgumentNullException(nameof(getArticleIds));

            OrderAndSellArticleResult result = _shopService.OrderAndSellArticle(orderAndSellRequest);
            if (!result.Successful)
            {
                _clientLogger.WriteLine(result.Message);
            }

            foreach (var articleId in getArticleIds)
            {
                var article = _articleService.GetArticleBy(articleId);
                if (article == null)
                {
                    _clientLogger.WriteLine("Article with ID: " + articleId + " not found.");
                }
                else
                {
                    _clientLogger.WriteLine("Found article with ID: " + article.Id);
                }
            }
        }
    }
}