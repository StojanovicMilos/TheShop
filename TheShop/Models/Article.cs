using System;

namespace TheShop.Models
{
	public class Article
	{
		public int Id { get; }
		public string NameOfArticle { get; }
		public int ArticlePrice { get;  }
		public bool IsSold { get; private set; }
		public DateTime SoldDate { get; private set; }
		public int BuyerId { get; private set; }

	    public Article(int id, string nameOfArticle, int articlePrice)
	    {
	        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
	        if (articlePrice <= 0) throw new ArgumentOutOfRangeException(nameof(articlePrice));
	        Id = id;
	        NameOfArticle = nameOfArticle ?? throw new ArgumentNullException(nameof(nameOfArticle));
	        ArticlePrice = articlePrice;
	    }

	    public OperationResult<Article> Sell(DateTime soldDate, int buyerId)
	    {
	        if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId));
	        if (IsSold)
	            return OperationResult<Article>.Failure($"Article with id {Id} is already sold");

	        SoldDate = soldDate;
	        BuyerId = buyerId;

	        return OperationResult<Article>.Success();
	    }

	    public void CancelSellTransaction()
	    {
	        IsSold = false;
	        SoldDate = default(DateTime);
	        BuyerId = 0;
	    }
	}

    public class ArticleSoldState
    {

    }
}