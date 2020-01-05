using TheShop.Models;

namespace TheShop
{
	public interface ISupplier
	{
		bool ArticleAvailableInInventory(int articleId);
	    OperationResult<Article> OrderArticle(int articleId);
	}
}