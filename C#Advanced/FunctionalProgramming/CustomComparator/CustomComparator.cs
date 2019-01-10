using System;

namespace CustomComparator
{
    using System.Collections.Generic;
    using System.Linq;

    class CustomComparator
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int, bool> evenNums = n => n % 2 == 0;
            Func<int, bool> oddNums = n => n % 2 != 0;

            int[] even = numbers.Where(evenNums).OrderBy(n => n).ToArray();
            int[] odd = numbers.Where(oddNums).OrderBy(n => n).ToArray();

            Console.Write(string.Join(" ", even) + " ");
            Console.WriteLine(string.Join(" ", odd));
        }
    }
}
