using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> funcGetMin = GetMin;

            var minNumber = funcGetMin(numbers);

            Console.WriteLine(minNumber);

        }

        static int GetMin(int[] nums)
        {
            var minNum = int.MaxValue;

            foreach (var n in nums)
            {
                if (n < minNum)
                {
                    minNum = n;
                }
            }
            return minNum;
        }
    }
}
