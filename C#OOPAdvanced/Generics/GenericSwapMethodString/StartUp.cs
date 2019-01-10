using System;
using System.Collections.Generic;
using System.Linq;
using GenericBox;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Box<string> data = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var element = Console.ReadLine();
                
                data.Add(element);
            }

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            data.Swap(indexes[0], indexes[1]);

            Console.WriteLine(data.ToString());
        }
    }
}
