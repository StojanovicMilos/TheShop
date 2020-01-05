using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop
{
    public class Supplier : ISupplier
    {
        private readonly List<Article> _articles;

        public Supplier(List<Article> articles)
        {
            _articles = articles ?? throw new ArgumentNullException(nameof(articles));
        }

        public bool ArticleAvailableInInventory(int articleId) => _articles.Any(a => a.Id == articleId && !a.IsSold);

        public OperationResult<Article> OrderArticle(int articleId)
        {
            if (ArticleAvailableInInventory(articleId))
                return OperationResult<Article>.SuccessWithValue(_articles.First(a => a.Id == articleId));
            return OperationResult<Article>.Failure("article does not exist");
        }
    }
}