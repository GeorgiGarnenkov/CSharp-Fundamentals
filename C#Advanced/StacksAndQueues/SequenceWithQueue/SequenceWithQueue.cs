using System;
using System.Collections.Generic;

namespace SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var mainQueue = new Queue<long>();
            var result = new List<long>();

            mainQueue.Enqueue(n);
            result.Add(n);

            while (true)
            {
                var currentNumber = mainQueue.Dequeue();
                if (result.Count == 50)
                {
                    break;
                }
                var tempN1 = currentNumber + 1;
                mainQueue.Enqueue(tempN1);
                result.Add(tempN1);
                if (result.Count == 50)
                {
                    break;
                }
                var tempN2 = (2 * currentNumber) + 1;
                mainQueue.Enqueue(tempN2);
                result.Add(tempN2);
                if (result.Count == 50)
                {
                    break;
                }
                var tempN3 = currentNumber + 2;
                mainQueue.Enqueue(tempN3);
                result.Add(tempN3);
                
            }
            Console.Write(string.Join(" ", result));
            Console.WriteLine();
        }
    }
}
