﻿using System;

namespace TheShop
{
    public class ConsoleShopServiceLogger : IShopServiceLogger
    {
        public void Debug(string message) => Console.WriteLine("Debug: " + message);

        public void Info(string message) => Console.WriteLine("Info: " + message);

        public void Error(string message) => Console.WriteLine("Error: " + message);
    }
}