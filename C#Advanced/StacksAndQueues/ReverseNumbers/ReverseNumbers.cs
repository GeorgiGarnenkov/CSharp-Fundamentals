using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>(input
                .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            
            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
