using System.Collections.Generic;
using Moq;
using TheShop;
using TheShop.Models;
using Xunit;

namespace ShopServiceUnitTests
{
    public class ShopServiceShould
    {
        [Fact]
        public void CallDatabaseDriverOnceWhenGettingArticleById()
        {
            //Arrange
            const int articleId = 0;
            Mock<IDatabaseDriver> mockDatabaseDriver = new Mock<IDatabaseDriver>();
            mockDatabaseDriver.Setup(mock => mock.GetArticleBy(articleId));
            ShopService shopService = new ShopService(mockDatabaseDriver.Object, new ConsoleShopServiceLogger(), new Suppliers(new List<ISupplier>
            {
                new Supplier(new List<Article>
                {
                    new Article
                    {
                        ArticlePrice = 458,
                        Id = 1,
                        NameOfArticle = "Article from supplier1"
                    }
                }),
                new Supplier(new List<Article>
                {
                    new Article
                    {
                        ArticlePrice = 459,
                        Id = 1,
                        NameOfArticle = "Article from supplier2"
                    }
                }),
                new Supplier(new List<Article>
                {
                    new Article
                    {
                        ArticlePrice = 460,
                        Id = 1,
                        NameOfArticle = "Article from supplier3"
                    }
                })
            }));

            //Act
            shopService.GetArticleBy(articleId);

            //Assert
            mockDatabaseDriver.Verify(mock => mock.GetArticleBy(articleId), Times.Once);
        }
    }
}
