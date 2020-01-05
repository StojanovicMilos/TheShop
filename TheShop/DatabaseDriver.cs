using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop
{
	public class DatabaseDriver : IDatabaseDriver
    {
		private readonly List<Article> _articles = new List<Article>();

        public OperationResult<Article> GetArticleBy(int articleId)
        {
            if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));
            Article article = _articles.FirstOrDefault(x => x.Id == articleId);
            return article == null ? OperationResult<Article>.Failure($"Article with id {articleId} doesn't exist in the database.") : OperationResult<Article>.SuccessWithValue(article);
        }

        public OperationResult<Article> Save(Article article)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            _articles.Add(article);
            return OperationResult<Article>.Success();
        }
    }
}