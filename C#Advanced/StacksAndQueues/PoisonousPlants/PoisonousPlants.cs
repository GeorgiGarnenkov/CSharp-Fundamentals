using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //  6 5 8 4 7 10 9

            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            int[] days = new int[n];

            for (int i = 1; i < n; i++)
            {
                var maxDays = 0;
                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
