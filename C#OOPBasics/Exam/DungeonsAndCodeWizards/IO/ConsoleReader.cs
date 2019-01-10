using System;
using DungeonsAndCodeWizards.IO.Interfaces;

namespace DungeonsAndCodeWizards.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();

        }
    }
}