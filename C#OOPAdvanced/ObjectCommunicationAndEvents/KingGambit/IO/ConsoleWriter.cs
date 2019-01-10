using System;
using KingGambit.Interfaces;

namespace KingGambit.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}