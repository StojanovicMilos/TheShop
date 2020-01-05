using System;
using TheShop.Models;

namespace TheShop
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleServiceDatabaseDriver _databaseDriver;

        public ArticleService(IArticleServiceDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
        }

        public OperationResult<Article> GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
    }

    
}