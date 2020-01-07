using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.BL.ExtensionMethods;
using TheShop.BL.Interfaces.BL;
using TheShop.BL.Interfaces.UtilityClasses;

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

        public bool ArticleAvailableInInventory(int articleId)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));

            return _suppliers.Any(s => s.ArticleAvailableInInventory(articleId));
        }

        public bool ArticleAvailableInInventoryForPrice(int articleId, int maximumPrice)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));
            if (maximumPrice <= 0) throw new ArgumentOutOfRangeException(nameof(maximumPrice));

            return _suppliers.Any(s => s.ArticleAvailableInInventoryForPrice(articleId, maximumPrice));
        }

        public OperationResult<Article.Article> GetArticle(SellRequest sellRequest)
        {
            if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

            return _suppliers.Where(s => s.ArticleAvailableInInventoryForPrice(sellRequest.SellArticleId, sellRequest.MaximumPrice))
                       .Select(s => s.GetArticle(sellRequest))
                       .Where(operationResult => operationResult.Successful)
                       .WithMinimum(operationResult => operationResult.ReturnValue.ArticlePrice)
                   ?? OperationResult<Article.Article>.Failure("Could not order article");
        }
    }
}
