using TheShop.Models;

namespace TheShop
{
    public interface IDatabaseDriver
    {
        OperationResult<Article> GetArticleBy(int articleId);
        OperationResult<Article> Save(Article article);
    }
}