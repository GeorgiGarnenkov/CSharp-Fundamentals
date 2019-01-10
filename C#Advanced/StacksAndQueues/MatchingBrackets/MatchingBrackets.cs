using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var position = input[i];

                if (position == '(')
                {
                    stack.Push(i);
                }
                if (position == ')')
                {
                    var startIndex = stack.Pop();
                    var reminder = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(reminder);
                }
            }
        }
    }
}
