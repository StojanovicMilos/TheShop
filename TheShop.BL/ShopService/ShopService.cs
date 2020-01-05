using System;
using TheShop.BL.Interfaces;
using TheShop.BL.SuppliersService;

namespace TheShop.BL.ShopService
{
    public class ShopService : IShopService
	{
	    private readonly Suppliers _supplier;
	    private readonly IArticleSeller _articleSeller;

	    public ShopService(Suppliers supplier, IArticleSeller articleSeller)
	    {
	        _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
	        _articleSeller = articleSeller ?? throw new ArgumentNullException(nameof(articleSeller));
	    }

	    public OperationResult<Article.Article> OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest)
        {
            if (orderAndSellRequest == null) throw new ArgumentNullException(nameof(orderAndSellRequest));

            OperationResult<Article.Article> orderResult = _supplier.OrderArticle(orderAndSellRequest.OrderAndSellArticleId);
            return orderResult.Successful ? _articleSeller.SellArticle(orderResult.ReturnValue, orderAndSellRequest) : OperationResult<Article.Article>.Failure("Could not order article");
        }
	}
}