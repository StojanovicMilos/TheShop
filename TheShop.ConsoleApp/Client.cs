using System;
using System.Collections.Generic;
using TheShop.BL.Article;
using TheShop.BL.Interfaces;

namespace TheShop.ConsoleApp
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

            OperationResult<Article> orderAndSellResult = _shopService.OrderAndSellArticle(orderAndSellRequest);
            if (!orderAndSellResult.Successful)
            {
                _clientLogger.WriteLine(orderAndSellResult.Message);
            }

            foreach (var articleId in getArticleIds)
            {
                var getArticleResult = _articleService.GetArticleBy(articleId);
                if (getArticleResult.Successful)
                {
                    _clientLogger.WriteLine("Found article with ID: " + articleId);
                }
                else
                {
                    _clientLogger.WriteLine("Article with ID: " + articleId + " not found.");
                }
            }
        }
    }
}