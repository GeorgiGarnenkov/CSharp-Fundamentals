using System;
using EventImplementation.Interfaces;

namespace EventImplementation
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}