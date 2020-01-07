using System;
using TheShop.BL.Interfaces.UtilityClasses;

namespace TheShop.BL.Article
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

	    public OperationResult<Article> Sell(SellRequest sellRequest)
	    {
	        if (sellRequest == null) throw new ArgumentNullException(nameof(sellRequest));

	        if (IsSold)
	            return OperationResult<Article>.Failure($"Article with id {Id} is already sold");

	        SoldDate = sellRequest.SoldDate;
	        BuyerId = sellRequest.BuyerId;

	        return OperationResult<Article>.Success();
	    }

	    public void CancelSellTransaction()
	    {
	        IsSold = false;
	        SoldDate = default(DateTime);
	        BuyerId = 0;
	    }
	}
}