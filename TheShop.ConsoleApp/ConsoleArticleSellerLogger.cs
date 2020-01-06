using System;
using TheShop.BL.Interfaces;

namespace TheShop.ConsoleApp
{
    public class ConsoleArticleSellerLogger : IArticleSellerLogger
    {
        public void Debug(string message) => Console.WriteLine("Debug: " + message);

        public void Info(string message) => Console.WriteLine("Info: " + message);

        public void Error(string message) => Console.WriteLine("Error: " + message);
    }
}