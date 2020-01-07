using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.DAL
{
    public interface IArticleSellerDatabaseDriver
    {
        OperationResult<Article.Article> Save(Article.Article article);
    }
}