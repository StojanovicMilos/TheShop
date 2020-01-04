namespace TheShop.Suppliers
{
	public class Supplier1 : SupplierBase
	{
		protected override int Id => 1;
		protected override string NameOfArticle => "Article from supplier1";
		protected override int ArticlePrice => 458;
	}
}