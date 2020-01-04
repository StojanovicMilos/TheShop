using System;

namespace TheShop
{
    public class ConsoleClientLogger : IClientLogger
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}