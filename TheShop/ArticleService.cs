using System;
using TheShop.Models;

namespace TheShop
{
    public class ArticleService : IArticleService
    {
        private readonly IDatabaseDriver _databaseDriver;

        public ArticleService(IDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException(nameof(databaseDriver));
        }

        public OperationResult<Article> GetArticleBy(int articleId) => _databaseDriver.GetArticleBy(articleId);
    }
}