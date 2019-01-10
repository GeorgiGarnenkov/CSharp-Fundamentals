using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();

                queue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpPassed = 0; pumpPassed < n; pumpPassed++)
                {
                    int[] currentPump = queue.Dequeue();

                    queue.Enqueue(currentPump);

                    fuel += currentPump[0] - currentPump[1];

                    if (fuel < 0)
                    {
                        currentStart += pumpPassed;
                        isSolution = false;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
