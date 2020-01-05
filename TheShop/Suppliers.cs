using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop
{
    public class Suppliers : ISupplier
    {
        private readonly List<ISupplier> _suppliers;

        public Suppliers(List<ISupplier> suppliers)
        {
            if (suppliers == null) throw new ArgumentNullException(nameof(suppliers));
            if (suppliers.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(suppliers));
            _suppliers = suppliers;
        }

        public bool ArticleInInventory(int articleId) => _suppliers.Any(s => s.ArticleInInventory(articleId));

        private ISupplier GetSupplierWithMinimumPriceFor(int articleId) =>
            _suppliers.Where(s => s.ArticleInInventory(articleId) && !s.OrderArticle(articleId).IsSold)
                .WithMinimum(s => s.OrderArticle(articleId).ArticlePrice);

        public Article OrderArticle(int articleId) =>
            GetSupplierWithMinimumPriceFor(articleId)?.OrderArticle(articleId);
    }
}
