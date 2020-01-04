using TheShop.Models;

namespace TheShop
{
	public interface IShopService
	{
	    void OrderAndSellArticle(OrderAndSellRequest orderAndSellRequest);
		Article GetById(int id);
	}

    public class OrderAndSellRequest
    {
        public int OrderAndSellArticleId { get; set; }
        public int BuyerId { get; set; }
    }
}