namespace TheShop.Suppliers
{
	public class Supplier2 : SupplierBase
	{
		protected override int Id => 1;
		protected override string NameOfArticle => "Article from supplier2";
		protected override int ArticlePrice => 459;
	}
}