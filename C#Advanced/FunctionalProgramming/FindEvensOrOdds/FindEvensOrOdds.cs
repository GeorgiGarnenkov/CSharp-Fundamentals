using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            var borders = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var start = borders[0];
            var end = borders[1];
            var countOfArray = end - start + 1;
            int[] numbers = new int[countOfArray];

            for (int i = 0; i < countOfArray; i++)
            {
                numbers[i] = start++;
            }
            var command = Console.ReadLine();

            Func<int, bool> even = n => n % 2 == 0;
            Func<int, bool> odd = n => n % 2 != 0;

            if (command == "even")
            {
                numbers.Where(even)
                    .ToList()
                    .ForEach(n => Console.Write($"{n} "));
                Console.WriteLine();
            }
            else if (command == "odd")
            {
                numbers.Where(odd)
                    .ToList()
                    .ForEach(n => Console.Write($"{n} "));
                Console.WriteLine();
            }
        }
    }
}
