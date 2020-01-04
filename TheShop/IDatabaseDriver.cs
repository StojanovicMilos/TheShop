using TheShop.Models;

namespace TheShop
{
    public interface IDatabaseDriver
    {
        Article GetArticleBy(int articleId);
        void Save(Article article);
    }
}