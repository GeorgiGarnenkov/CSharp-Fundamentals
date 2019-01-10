using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            var text = new StringBuilder();
            stack.Push("");

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "1":
                        stack.Push(text.ToString());
                        text.Append(commandArgs[1]);
                        break;
                    case "2":
                        stack.Push(text.ToString());
                        text.Remove(text.Length - int.Parse(commandArgs[1]), int.Parse(commandArgs[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(commandArgs[1]) - 1]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(stack.Pop());
                        break;
                }
            }
        }
    }
}
