using TheShop.Models;

namespace TheShop.Suppliers
{
	public abstract class SupplierBase : ISupplier
	{
		protected abstract int Id { get; }
		protected abstract string NameOfArticle { get; }
		protected abstract int ArticlePrice { get; }

		public bool ArticleInInventory(int id)
		{
			return true;
		}
		
		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = Id,
				NameOfArticle = NameOfArticle,
				ArticlePrice = ArticlePrice
			};
		}
	}
}