using System;
using System.IO;
using Xunit;

namespace TheShop.IntegrationTests
{
    public class DoShoppingShould
    {
        [Fact]
        public void OutputTextToConsole()
        {
            //Setup
            var consoleOutput = new ConsoleOutput();
            string expectedOutput = "Debug: Trying to sell article with ID = 1"
                                    + Environment.NewLine + "Info: Article with ID = 1 is sold."
                                    + Environment.NewLine + "Found article with ID: 1"
                                    + Environment.NewLine + "Article with ID: 12 not found." + Environment.NewLine;

            //Exercise
            Program.DoShopping();

            //Verify
            Assert.Equal(expectedOutput, consoleOutput.GetOutput());

            //Teardown
            consoleOutput.Dispose();
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
