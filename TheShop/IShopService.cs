using TheShop.Models;

namespace TheShop
{
	public interface IShopService
	{
		void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
		Article GetById(int id);
	}
}