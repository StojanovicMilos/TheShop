using TheShop.Models;

namespace TheShop
{
	public interface IShopService
	{
	    OrderAndSellArticleResult OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
		Article GetArticleBy(int articleId);
	}
}