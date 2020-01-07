using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.BL
{
    public interface IArticleService
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }
}