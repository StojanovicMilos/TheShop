using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.BL.Interfaces.BL;
using TheShop.BL.Interfaces.Utility;
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

        public bool ArticleAvailableInInventoryForPrice(int articleId, int maximumPrice) => _suppliers.Any(s => s.ArticleAvailableInInventoryForPrice(articleId, maximumPrice));

        private ISupplier GetSupplierWithMinimumPriceFor(SellRequest sellRequest) =>
            _suppliers
                .Where(s => s.ArticleAvailableInInventoryForPrice(sellRequest.SellArticleId, sellRequest.MaximumPrice))
                .WithMinimum(s => s.GetArticle(sellRequest).ReturnValue.ArticlePrice);

        public OperationResult<Article.Article> GetArticle(SellRequest sellRequest)
        {
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            var supplierWithMinimumPriceForArticle = GetSupplierWithMinimumPriceFor(sellRequest);
            return supplierWithMinimumPriceForArticle == null
                ? OperationResult<Article.Article>.Failure("Could not order article")
                : supplierWithMinimumPriceForArticle.GetArticle(sellRequest);
        }
    }
}
