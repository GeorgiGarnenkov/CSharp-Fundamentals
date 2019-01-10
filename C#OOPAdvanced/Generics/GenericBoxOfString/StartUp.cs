using System;
using System.Runtime.InteropServices;
using GenericBox;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                box.Value = Console.ReadLine();

                Console.WriteLine(box.ToString());
            }
        }
    }
}
