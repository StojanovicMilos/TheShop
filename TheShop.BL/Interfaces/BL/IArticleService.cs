using TheShop.BL.Interfaces.Utility;

namespace TheShop.BL.Interfaces.BL
{
    public interface IArticleService
    {
        OperationResult<Article.Article> GetArticleBy(int articleId);
    }
}