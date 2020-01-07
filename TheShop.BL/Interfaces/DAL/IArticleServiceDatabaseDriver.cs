using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.DAL
{
    public interface IArticleServiceDatabaseDriver
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }
}