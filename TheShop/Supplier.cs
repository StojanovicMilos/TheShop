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

        public bool ArticleInInventory(int articleId) => _articles.Any(a => a.Id == articleId);

        public Article OrderArticle(int articleId) => _articles.FirstOrDefault(a => a.Id == articleId);
    }
}