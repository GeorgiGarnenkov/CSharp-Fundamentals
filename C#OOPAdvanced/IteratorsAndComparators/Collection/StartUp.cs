using System;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var collection = input.Split(' ').Skip(1).ToList();

            ListIterator<string> iterator = new ListIterator<string>(collection);

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(' ');

                var command = args[0];

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(iterator.Print());
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                    case "PrintAll":
                        Console.WriteLine(iterator.PrintAll());
                        break;
                }
            }
        }
    }
}
