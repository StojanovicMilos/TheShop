using TheShop.Models;

namespace TheShop
{
    public interface IArticleService
    {
        OperationResult<Article> GetArticleBy(int articleId);
    }
}