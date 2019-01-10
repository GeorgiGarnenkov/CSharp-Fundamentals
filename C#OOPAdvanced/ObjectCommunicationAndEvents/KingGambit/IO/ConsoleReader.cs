using System;
using KingGambit.Interfaces;

namespace KingGambit.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}