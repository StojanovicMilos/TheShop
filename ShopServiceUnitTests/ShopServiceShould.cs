using System.Collections.Generic;
using Moq;
using TheShop;
using TheShop.Suppliers;
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
            ShopService shopService = new ShopService(mockDatabaseDriver.Object, new ConsoleShopServiceLogger(), new List<ISupplier> {new Supplier1(), new Supplier2(), new Supplier3()});

            //Act
            shopService.GetArticleBy(articleId);

            //Assert
            mockDatabaseDriver.Verify(mock => mock.GetArticleBy(articleId), Times.Once);
        }
    }
}
