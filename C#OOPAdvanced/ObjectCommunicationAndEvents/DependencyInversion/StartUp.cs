using System;
using DependencyInversion.IO;
using DependencyInversion.Models;

namespace DependencyInversion
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var calculator = new PrimitiveCalculator();

            new Engine(calculator, reader, writer).Run();
        }
    }
}
