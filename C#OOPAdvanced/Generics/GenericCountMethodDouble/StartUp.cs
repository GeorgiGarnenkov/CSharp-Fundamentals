using System;
using GenericBox;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Box<double> data = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var element = double.Parse(Console.ReadLine());

                data.Add(element);
            }

            var comparer = double.Parse(Console.ReadLine());

            var count = data.CountOfBiggerElements(data, comparer);

            Console.WriteLine(count);
        }
    }
}
