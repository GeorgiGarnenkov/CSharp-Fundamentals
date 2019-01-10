using System;
using DependencyInversion.Interfaces;

namespace DependencyInversion.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}