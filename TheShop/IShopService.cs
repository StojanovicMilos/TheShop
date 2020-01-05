using TheShop.Models;

namespace TheShop
{
    public interface IShopService
	{
	    OperationResult<Article> OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
	}
}