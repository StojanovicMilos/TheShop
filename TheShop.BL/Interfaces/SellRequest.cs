using System;

namespace TheShop.BL.Interfaces
{
    public class SellRequest
    {
        public int SellArticleId { get; }
        public int BuyerId { get; }

        public SellRequest(int sellArticleId, int buyerId)
        {
            if (sellArticleId <= 0) throw new ArgumentOutOfRangeException(nameof(sellArticleId));
            if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId));
            SellArticleId = sellArticleId;
            BuyerId = buyerId;
        }
    }
}