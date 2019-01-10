using System;
using DungeonsAndCodeWizards.IO.Interfaces;

namespace DungeonsAndCodeWizards.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}