using System;

namespace TheShop.BL.Interfaces
{
    public class SellRequest
    {
        public int SellArticleId { get; }
        public int MaximumPrice { get; }
        public int BuyerId { get; }
        public DateTime SoldDate { get; }

        public SellRequest(int sellArticleId, int buyerId, DateTime soldDate, int maximumPrice)
        {
            if (sellArticleId <= 0) throw new ArgumentOutOfRangeException(nameof(sellArticleId));
            if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId));
            if (maximumPrice <= 0) throw new ArgumentOutOfRangeException(nameof(maximumPrice));
            SellArticleId = sellArticleId;
            BuyerId = buyerId;
            SoldDate = soldDate;
            MaximumPrice = maximumPrice;
        }
    }
}