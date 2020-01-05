using System;
using TheShop.Models;

namespace TheShop
{
    public class ShopService : IShopService
	{
		private readonly IDatabaseDriver _databaseDriver;
		private readonly IShopServiceLogger _logger;
		private readonly ISupplier _supplier;

	    public ShopService(IDatabaseDriver databaseDriver, IShopServiceLogger logger, ISupplier supplier)
	    {
	        _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
	        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
	        _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
	    }

	    public OrderAndSellArticleResult OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest)
        {
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));

            Article article = OrderArticle(orderAndSellRequest);
            return article == null ? OrderAndSellArticleResult.Failure("Could not order article") : SellArticle(article, orderAndSellRequest);
        }

        private Article OrderArticle(OrderAndSellRequest orderAndSellRequest) => _supplier.OrderArticle(orderAndSellRequest.OrderAndSellArticleId);

	    private OrderAndSellArticleResult SellArticle(Article article, OrderAndSellRequest orderAndSellRequest)
	    {
	        if (article == null) throw new ArgumentNullException(nameof(article));
	        if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));
	        _logger.Debug("Trying to sell article with ID = " + orderAndSellRequest.OrderAndSellArticleId);
	        DateTime soldDate = DateTime.Now;
	        article.Sell(soldDate, orderAndSellRequest.BuyerId);
	        _databaseDriver.Save(article);
	        _logger.Info("Article with ID = " + orderAndSellRequest.OrderAndSellArticleId + " is sold.");
	        return OrderAndSellArticleResult.Success();
	    }

	    public Article GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
	}
}