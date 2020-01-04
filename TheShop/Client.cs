using System;
using System.Collections.Generic;

namespace TheShop
{
    public class Client
    {
        private readonly IShopService _shopService;
        private readonly IClientLogger _clientLogger;

        public Client(IShopService shopService, IClientLogger clientLogger)
        {
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService));
            _clientLogger = clientLogger ?? throw new ArgumentNullException(nameof(clientLogger));
        }

        public void DoShopping(OrderAndSellRequest orderAndSellRequest, IEnumerable<int> getArticleIds)
        {
            try
            {
                //order and sell
                _shopService.OrderAndSellArticle(orderAndSellRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            foreach (var articleId in getArticleIds)
            {
                var article = _shopService.GetArticleBy(articleId);
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