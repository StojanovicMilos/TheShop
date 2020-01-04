using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop
{
	public class DatabaseDriver : IDatabaseDriver
    {
		private readonly List<Article> _articles = new List<Article>();

		public Article GetArticleBy(int articleId)
		{
		    if (articleId <= 0) throw new ArgumentOutOfRangeException(nameof(articleId));
		    return _articles.FirstOrDefault(x => x.Id == articleId);
		}

        public void Save(Article article)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            _articles.Add(article);
        }
    }
}