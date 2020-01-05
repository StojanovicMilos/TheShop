using TheShop.Models;

namespace TheShop
{
	public interface ISupplier
	{
		bool ArticleInInventory(int articleId);
		Article OrderArticle(int articleId);
	}
}