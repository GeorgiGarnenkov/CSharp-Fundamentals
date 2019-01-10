using System;
using StorageMaster.IO.Interfaces;

namespace StorageMaster.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}