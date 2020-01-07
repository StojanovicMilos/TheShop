using System;

namespace TheShop.ConsoleApp
{
    public class ConsoleClientLogger : IClientLogger
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}