namespace TheShop.BL.Interfaces
{
    public interface IArticleSeller
    {
        OperationResult<Article.Article> SellArticle(Article.Article article, OrderAndSellRequest orderAndSellRequest);
    }
}