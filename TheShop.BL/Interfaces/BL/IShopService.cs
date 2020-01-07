using TheShop.BL.Interfaces.Utility;

namespace TheShop.BL.Interfaces.BL
{
    public interface IShopService
	{
	    OperationResult<Article.Article> SellArticle(SellRequest sellRequest);
	}
}