using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Interfaces.BL
{
    public interface IArticleSeller
    {
        OperationResult<Article.Article> SellArticle(Article.Article article, SellRequest sellRequest);
    }
}