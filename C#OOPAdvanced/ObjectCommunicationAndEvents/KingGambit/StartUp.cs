using System;
using KingGambit.IO;

namespace KingGambit
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            new Engine(new ConsoleReader(), new ConsoleWriter()).Run();
        }
    }
}
