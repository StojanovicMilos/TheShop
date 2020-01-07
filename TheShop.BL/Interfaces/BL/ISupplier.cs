using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.BL
{
	public interface ISupplier
	{
		bool ArticleAvailableInInventory(int articleId);
	    OperationResult<Article.Article> GetArticle(SellRequest sellRequest);
	    bool ArticleAvailableInInventoryForPrice(int articleId, int maximumPrice);
	}
}