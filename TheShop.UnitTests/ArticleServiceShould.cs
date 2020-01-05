﻿using Moq;
using TheShop.BL.ArticleService;
using TheShop.BL.Interfaces;
using Xunit;

namespace TheShop.UnitTests
{
    public class ArticleServiceShould
    {
        [Fact]
        public void CallDatabaseDriverOnceWhenGettingArticleById()
        {
            //Arrange
            const int articleId = 0;
            Mock<IDatabaseDriver> mockDatabaseDriver = new Mock<IDatabaseDriver>();
            mockDatabaseDriver.Setup(mock => mock.GetArticleBy(articleId));
            ArticleService articleService = new ArticleService(mockDatabaseDriver.Object);

            //Act
            articleService.GetArticleBy(articleId);

            //Assert
            mockDatabaseDriver.Verify(mock => mock.GetArticleBy(articleId), Times.Once);
        }
    }
}