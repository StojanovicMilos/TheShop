using TheShop.BL.Interfaces.Utility;

namespace TheShop.BL.Interfaces.BL
{
    public interface IArticleSeller
    {
        OperationResult<Article.Article> SellArticle(Article.Article article, SellRequest sellRequest);
    }
}