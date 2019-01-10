namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var command = input;
                
                Func<List<int>, string, List<int>> funcCommand = CommandExecute;
                
                var resultNumbers = funcCommand(numbers, command);
            }
        }

        private static List<int> CommandExecute(List<int> numbers, string command)
        {
            switch (command)
            {
                case "add":
                   numbers = Add(numbers);
                    break;
                case "multiply":
                    numbers = Multiply(numbers);
                    break;
                case "subtract":
                    numbers = Subtract(numbers);
                    break;
                case "print":
                    Print(numbers);
                    break;
            }
            return numbers;
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> Subtract(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
            return numbers;
        }

        private static List<int> Multiply(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }
            return numbers;
        }

        private static List<int> Add(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]++;
            }
            return numbers;
        }
    }
}
