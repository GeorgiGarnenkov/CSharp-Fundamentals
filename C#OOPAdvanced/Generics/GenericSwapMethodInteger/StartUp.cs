using System;
using System.Linq;
using GenericBox;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Box<int> data = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var element = int.Parse(Console.ReadLine());

                data.Add(element);
            }

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            data.Swap(indexes[0], indexes[1]);

            Console.WriteLine(data.ToString());
        }
    }
}
