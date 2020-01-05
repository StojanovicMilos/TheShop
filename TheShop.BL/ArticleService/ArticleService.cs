using System;
using TheShop.BL.Interfaces;

namespace TheShop.BL.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleServiceDatabaseDriver _databaseDriver;

        public ArticleService(IArticleServiceDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
        }

        public OperationResult<Article.Article> GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
    }

    
}