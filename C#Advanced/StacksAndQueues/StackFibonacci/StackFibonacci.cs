using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class StackFibonacci
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n)); ;

        }

        static long GetFibonacci(long n)
        {
            var stack = new Stack<long>();

            long first = 0;
            long second = 1;
            for (int j = 0; j < n; j++)
            {
                stack.Push(first);
                stack.Push(second);
                first = stack.Peek();
                second = stack.Pop() + stack.Pop();
            }
            return first;
        }
    }
}
