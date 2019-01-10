using System;
using StorageMaster.IO.Interfaces;

namespace StorageMaster.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();

        }
    }
}