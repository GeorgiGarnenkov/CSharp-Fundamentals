using System;
using GenericBox;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                box.Value = int.Parse(Console.ReadLine());

                Console.WriteLine(box.ToString());
            }
        }
    }
}
