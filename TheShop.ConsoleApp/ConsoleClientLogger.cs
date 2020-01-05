using System;
using TheShop.BL.Interfaces;

namespace TheShop.ConsoleApp
{
    public class ConsoleClientLogger : IClientLogger
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}