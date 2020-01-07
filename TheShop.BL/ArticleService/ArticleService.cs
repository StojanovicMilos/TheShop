using System;
using TheShop.BL.Interfaces.BL;
using TheShop.BL.Interfaces.DAL;
using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleServiceDatabaseDriver _databaseDriver;

        public ArticleService(IArticleServiceDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
        }

        public OperationResult<Article.Article> GetArticleBy(int articleId)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));

            return _databaseDriver.GetArticleBy(articleId);
        }
    }
}