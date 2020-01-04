using System;
using System.Collections.Generic;
using System.IO;

namespace TheShop.IntegrationTests
{
    public class TestList<T> : List<T>
    {
        public TestList()
        {

        }

        public TestList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public override string ToString() => "GetArticleIDs:" + string.Join(",", this);
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
