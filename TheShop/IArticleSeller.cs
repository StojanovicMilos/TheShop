using TheShop.Models;

namespace TheShop
{
    public interface IArticleSeller
    {
        OperationResult<Article> SellArticle(Article article, OrderAndSellRequest orderAndSellRequest);
    }
}