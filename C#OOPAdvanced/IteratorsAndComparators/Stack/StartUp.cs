using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            string input;
            MyStack<int> stack = new MyStack<int>();
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var command = args[0];
                switch (command)
                {
                    case "Push":
                        stack.Push(args.Skip(1).Select(int.Parse));
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
