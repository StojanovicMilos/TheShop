namespace TheShop.BL.Interfaces
{
	public interface ISupplier
	{
		bool ArticleAvailableInInventory(int articleId);
	    OperationResult<Article.Article> GetArticle(int articleId);
	}
}