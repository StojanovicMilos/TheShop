using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.BL
{
    public interface IShopService
	{
	    OperationResult<Article.Article> SellArticle(SellRequest sellRequest);
	}
}