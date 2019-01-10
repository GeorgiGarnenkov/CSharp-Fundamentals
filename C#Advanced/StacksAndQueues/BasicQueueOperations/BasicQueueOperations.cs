using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            var commandArgs = Console.ReadLine().Split();

            var numbersCount = int.Parse(commandArgs[0]);
            var numbersCountToRemove = int.Parse(commandArgs[1]);
            var numberForSearch = int.Parse(commandArgs[2]);

            var queue = new Queue<int>();

            var numbers = Console.ReadLine().Split();

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }

            for (int i = 0; i < numbersCountToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numberForSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
