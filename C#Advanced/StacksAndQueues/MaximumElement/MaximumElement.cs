using System;
using System.Collections.Generic;

namespace MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxNumberStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine().Split(' ');

                if (query[0] == "1")
                {
                    var numberToPush = int.Parse(query[1]);
                    stack.Push(numberToPush);

                    if (maxNumberStack.Count == 0 || numberToPush >= maxNumberStack.Peek())
                    {
                        maxNumberStack.Push(numberToPush);
                    }
                }
                else if (query[0] == "2")
                {
                    var elementAtTop = stack.Pop();
                    var currentMaxNumber = maxNumberStack.Peek();
                    if (elementAtTop == currentMaxNumber)
                    {
                        maxNumberStack.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(maxNumberStack.Peek());
                }
            }
        }
    }
}
