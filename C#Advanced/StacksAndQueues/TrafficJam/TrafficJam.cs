using System;
using System.Collections.Generic;

namespace TrafficJam
{
    public class TrafficJam
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            string input;
            var queue = new Queue<string>();
            var counter = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                var commandArgs = input;

                if (commandArgs == "green")
                {
                    if (queue.Count < n)
                    {
                        n = queue.Count;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(commandArgs);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
