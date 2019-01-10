using System;

namespace ListOfPredicates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;

    class ListOfPredicates
    {
        static void Main()
        {
            var lastOfNums = long.Parse(Console.ReadLine());

            var numbers = new List<long>();

            for (int i = 0; i < lastOfNums; i++)
            {
                numbers.Add(i + 1);
            }

            var dividers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).Distinct().ToArray();

            Func<long, bool> func = CreatePredicate(dividers);

            var result = numbers.Where(func).ToArray();

            Console.WriteLine(string.Join(" ", result));

        }

        private static Func<long, bool> CreatePredicate(long[] dividers)
        {
            return num =>
                {
                    foreach (var div in dividers)
                    {
                        if (num % div != 0)
                        {
                            return false;
                        }
                    }

                    return true;
                };
        }
    }
}
