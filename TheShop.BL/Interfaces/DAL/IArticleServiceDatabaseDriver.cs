using TheShop.BL.Interfaces.Utility;

namespace TheShop.BL.Interfaces.DAL
{
    public interface IArticleServiceDatabaseDriver
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }
}