using TheShop.Models;

namespace TheShop
{
    public interface IArticleSeller
    {
        OrderAndSellArticleResult SellArticle(Article article, OrderAndSellRequest orderAndSellRequest);
    }
}