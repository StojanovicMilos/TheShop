using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using TheShop.BL.Interfaces;
using TheShop.ConsoleApp;
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
            SellRequest sellRequest = new SellRequest(1, 10, DateTime.Now);
            List<int> getArticleIds = new List<int> {1, 12};
            Client client = Program.GetDefaultClient();

            //Exercise
            client.DoShopping(sellRequest, getArticleIds);

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
            int[] orderAndSellArticleIds = Enumerable.Range(1, 2).ToArray();
            int[] buyerIds = Enumerable.Range(1, 5).ToArray();
            TestList<TestList<int>> getArticleIds = new TestList<TestList<int>> {new TestList<int>(Enumerable.Range(1, 2))};

            //Act+Assert
            CombinationApprovals.VerifyAllCombinations(DoShoppingWithOutput, orderAndSellArticleIds, buyerIds, getArticleIds);
        }

        private static string DoShoppingWithOutput(int orderAndSellArticleId, int buyerId, List<int> getArticleIds)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                Program.GetDefaultClient().DoShopping(new SellRequest(orderAndSellArticleId, buyerId, DateTime.Now), getArticleIds);
                return consoleOutput.GetOutput();
            }
        }
    }
}
