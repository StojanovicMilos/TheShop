using System;

namespace TheShop.BL.Interfaces
{
    public class OrderAndSellRequest
    {
        public int OrderAndSellArticleId { get; }
        public int BuyerId { get; }

        public OrderAndSellRequest(int orderAndSellArticleId, int buyerId)
        {
            if (orderAndSellArticleId <= 0) throw new ArgumentOutOfRangeException(nameof(orderAndSellArticleId));
            if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId));
            OrderAndSellArticleId = orderAndSellArticleId;
            BuyerId = buyerId;
        }
    }
}