using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop
{
	public class DatabaseDriver : IDatabaseDriver
    {
		private readonly List<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
		    if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
		    return _articles.FirstOrDefault(x => x.ID == id);
		}

        public void Save(Article article)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));
            _articles.Add(article);
        }
    }
}