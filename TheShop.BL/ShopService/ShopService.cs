using System;
using TheShop.BL.Interfaces;

namespace TheShop.BL.ShopService
{
    public class ShopService : IShopService
	{
	    private readonly ISupplier _supplier;
	    private readonly IArticleSeller _articleSeller;

	    public ShopService(ISupplier supplier, IArticleSeller articleSeller)
	    {
	        _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
	        _articleSeller = articleSeller ?? throw new ArgumentNullException(nameof(articleSeller));
	    }

	    public OperationResult<Article.Article> SellArticle(SellRequest sellRequest)
        {
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            OperationResult<Article.Article> orderResult = _supplier.GetArticle(sellRequest);
            return orderResult.Successful ? _articleSeller.SellArticle(orderResult.ReturnValue, sellRequest) : orderResult;
        }
	}
}