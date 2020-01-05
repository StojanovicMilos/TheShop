using System;

namespace TheShop
{
    public class OrderAndSellArticleResult
    {
        public bool Successful => Message == string.Empty;
        public string Message { get; }

        public static OrderAndSellArticleResult Failure(string message) => new OrderAndSellArticleResult(message);
        public static OrderAndSellArticleResult Success() => new OrderAndSellArticleResult(string.Empty);

        private OrderAndSellArticleResult(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}