using TheShop.Models;

namespace TheShop
{
    public interface IDatabaseDriver : IArticleServiceDatabaseDriver, IArticleSellerDatabaseDriver
    {

    }

    public interface IArticleServiceDatabaseDriver
    {
        OperationResult<Article> GetArticleBy(int articleId);
    }

    public interface IArticleSellerDatabaseDriver
    {
        OperationResult<Article> Save(Article article);
    }
}