using TheShop.Models;

namespace TheShop
{
	public interface IShopService
	{
	    void OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
		Article GetById(int id);
	}
}