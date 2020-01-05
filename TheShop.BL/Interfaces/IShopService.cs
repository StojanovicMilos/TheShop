namespace TheShop.BL.Interfaces
{
    public interface IShopService
	{
	    OperationResult<Article.Article> OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
	}
}