using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Xunit;

namespace TheShop.IntegrationTests
{
    public class DoShoppingShould
    {
        [Fact]
        public void OutputTextToConsoleForInitialUseCase()
        {
            //Setup
            var consoleOutput = new ConsoleOutput();
            string expectedOutput = "Debug: Trying to sell article with ID = 1"
                                    + Environment.NewLine + "Info: Article with ID = 1 is sold."
                                    + Environment.NewLine + "Found article with ID: 1"
                                    + Environment.NewLine + "Article with ID: 12 not found." + Environment.NewLine;
            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest {OrderAndSellArticleId = 1, BuyerId = 10};
            List<int> getArticleIds = new List<int> {1, 12};
            Client client = new Client(new ShopService(new ConsoleShopServiceLogger()), new ConsoleClientLogger());

            //Exercise
            client.DoShopping(orderAndSellRequest, getArticleIds);

            //Verify
            Assert.Equal(expectedOutput, consoleOutput.GetOutput());

            //Teardown
            consoleOutput.Dispose();
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void OutputTextToConsoleForOtherUseCases()
        {
            //Arrange
            int[] orderAndSellArticleIds = Enumerable.Range(1, 10).ToArray();
            int[] buyerIds = Enumerable.Range(1, 5).ToArray();
            TestList<TestList<int>> getArticleIds = new TestList<TestList<int>> {new TestList<int>(Enumerable.Range(1, 10))};
            

            //Act+Assert
            CombinationApprovals.VerifyAllCombinations(DoShoppingWithOutput, orderAndSellArticleIds, buyerIds, getArticleIds);
        }

        private static string DoShoppingWithOutput(int orderAndSellArticleId, int buyerId, List<int> getArticleIds)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                Client client = new Client(new ShopService(new ConsoleShopServiceLogger()), new ConsoleClientLogger());
                client.DoShopping(new OrderAndSellRequest {OrderAndSellArticleId = orderAndSellArticleId, BuyerId = buyerId}, getArticleIds);
                return consoleOutput.GetOutput();
            }
        }
    }
}
