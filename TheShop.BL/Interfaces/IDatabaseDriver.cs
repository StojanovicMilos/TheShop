namespace TheShop.BL.Interfaces
{
    public interface IDatabaseDriver : IArticleServiceDatabaseDriver, IArticleSellerDatabaseDriver
    {

    }

    public interface IArticleServiceDatabaseDriver
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }

    public interface IArticleSellerDatabaseDriver
    {
        OperationResult<Article.Article> Save(Article.Article article);
    }
}