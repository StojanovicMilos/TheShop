using TheShop.Models;

namespace TheShop
{
    public interface IArticleService
    {
        Article GetArticleBy(int articleId);
    }
}