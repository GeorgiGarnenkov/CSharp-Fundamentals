using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            var commandArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numberOfElements = commandArgs[0];
            var numberForPop = commandArgs[1];
            var numberForFind = commandArgs[2];

            var elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < numberForPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count < 1)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numberForFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
