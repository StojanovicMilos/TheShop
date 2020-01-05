namespace TheShop
{
    public interface IShopService
	{
	    OrderAndSellArticleResult OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
	}
}