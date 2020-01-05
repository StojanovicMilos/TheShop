namespace TheShop.BL.Interfaces
{
    public interface IArticleService
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }
}