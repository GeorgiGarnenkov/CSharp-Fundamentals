using System;
using System.Collections.Generic;
using System.Linq;
using GenericBox;

namespace GenericCountMethodString
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
            
            var comparer = Console.ReadLine();

            var count = data.CountOfBiggerElements(data, comparer);

            Console.WriteLine(count);
        }
    }
}
