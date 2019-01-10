using System;
using System.Collections.Generic;

namespace ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                stack.Push(character);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().ToString());
            }
            Console.WriteLine();
        }
    }
}
