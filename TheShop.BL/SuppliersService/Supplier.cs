using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.BL.Interfaces;

namespace TheShop.BL.SuppliersService
{
    public class Supplier : ISupplier
    {
        private readonly List<Article.Article> _articles;

        public Supplier(List<Article.Article> articles)
        {
            _articles = articles ?? throw new ArgumentNullException(nameof(articles));
        }

        public bool ArticleAvailableInInventory(int articleId)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));

            return _articles.Any(a => a.Id == articleId && !a.IsSold);
        }

        public bool ArticleAvailableInInventoryForPrice(int articleId, int maximumPrice)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));
            if (maximumPrice <= 0) throw new ArgumentOutOfRangeException(nameof(maximumPrice));

            return _articles.Any(a => a.Id == articleId && !a.IsSold && a.ArticlePrice <= maximumPrice);
        }

        public OperationResult<Article.Article> GetArticle(SellRequest sellRequest)
        {
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            return ArticleAvailableInInventory(sellRequest.SellArticleId)
                ? OperationResult<Article.Article>.SuccessWithValue(_articles.First(a => a.Id == sellRequest.SellArticleId))
                : OperationResult<Article.Article>.Failure("article does not exist");
        }
    }
}