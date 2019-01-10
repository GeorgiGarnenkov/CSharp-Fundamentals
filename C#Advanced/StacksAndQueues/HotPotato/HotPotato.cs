using System;
using System.Collections.Generic;

namespace HotPotato
{
    public class HotPotato
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var queue = new Queue<string>(input.Split(' '));

            var number = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    var reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
