using System;
using TheShop.Models;

namespace TheShop
{
    public class ShopService : IShopService
	{
		private readonly IDatabaseDriver _databaseDriver;
		private readonly ISupplier _supplier;
	    private readonly IArticleSeller _articleSeller;

	    public ShopService(IDatabaseDriver databaseDriver,ISupplier supplier, IArticleSeller articleSeller)
	    {
	        _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
	        _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
	        _articleSeller = articleSeller ?? throw new ArgumentNullException(nameof(articleSeller));
	    }

	    public OrderAndSellArticleResult OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest)
        {
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));

            Article article = _supplier.OrderArticle(orderAndSellRequest.OrderAndSellArticleId);
            return article == null ? OrderAndSellArticleResult.Failure("Could not order article") : _articleSeller.SellArticle(article, orderAndSellRequest);
        }

	    public Article GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
	}
}