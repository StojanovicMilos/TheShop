using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.BL.Interfaces;
using TheShop.BL.Utility;

namespace TheShop.BL.SuppliersService
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

        public bool ArticleAvailableInInventory(int articleId) => _suppliers.Any(s => s.ArticleAvailableInInventory(articleId));

        private ISupplier GetSupplierWithMinimumPriceFor(int articleId) =>
            _suppliers
                .Where(s => s.ArticleAvailableInInventory(articleId))
                .WithMinimum(s =>
                {
                    var orderArticleResult = s.OrderArticle(articleId);
                    return orderArticleResult.Successful ? orderArticleResult.ReturnValue.ArticlePrice : int.MaxValue;
                });

        public OperationResult<Article.Article> OrderArticle(int articleId)
        {
            var supplierWithMinimumPriceForArticle = GetSupplierWithMinimumPriceFor(articleId);
            return supplierWithMinimumPriceForArticle == null
                ? OperationResult<Article.Article>.Failure("No supplier has the article")
                : OperationResult<Article.Article>.SuccessWithValue(supplierWithMinimumPriceForArticle.OrderArticle(articleId).ReturnValue);
        }
    }
}
