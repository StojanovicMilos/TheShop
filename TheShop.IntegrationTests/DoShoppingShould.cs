using System;
using System.IO;
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
            OrderAndSellRequest orderAndSellRequest = new OrderAndSellRequest
            {
                OrderAndSellArticleId = 1,
                BuyerId = 10
            };
            const int getArticleId = 12;

            //Exercise
            Program.DoShopping(orderAndSellRequest, getArticleId);

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
            int[] getArticleIds = Enumerable.Range(1, 10).ToArray();

            //Act+Assert
            CombinationApprovals.VerifyAllCombinations(DoShoppingWithOutput, orderAndSellArticleIds, buyerIds, getArticleIds);
        }

        private static string DoShoppingWithOutput(int orderAndSellArticleId, int buyerId, int getArticleId)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                Program.DoShopping(new OrderAndSellRequest {OrderAndSellArticleId = orderAndSellArticleId, BuyerId = buyerId}, getArticleId);
                return consoleOutput.GetOutput();
            }
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        public string GetOutput() => _stringWriter.ToString();

        public void Dispose()
        {
            Console.SetOut(Console.Out);
            _stringWriter.Dispose();
        }
    }
}
