namespace TheShop.BL.Interfaces
{
    public interface IShopService
	{
	    OperationResult<Article.Article> SellArticle(SellRequest sellRequest);
	}
}