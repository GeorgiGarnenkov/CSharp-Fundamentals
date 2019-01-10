using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>(n);

            for (int i = 0; i < n; i++)
            {
                var nameAndAge = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var name = nameAndAge[0];
                var age = int.Parse(nameAndAge[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, age);
                }
            }

            var condition = Console.ReadLine();
            var conditionAge = int.Parse(Console.ReadLine());
            var printFormat = Console.ReadLine();

            var filter = GetFilter(condition, conditionAge);
            var printer = CreatePrinter(printFormat);

            PrintPeople(dict, filter, printer);


            //dict.Where(filter).ToList().ForEach(printer);
        }

        private static void PrintPeople(Dictionary<string, int> dict, 
            Func<KeyValuePair<string, int>, bool> filter, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in dict)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }

        static Func<KeyValuePair<string, int>, bool> GetFilter(string condition, int conditionAge)
        {
            if (condition == "younger")
            {
                return x => x.Value < conditionAge;
            }
            else
            {
                return x => x.Value >= conditionAge;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string printFormat)
        {
            switch (printFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
            throw new InvalidOperationException();
        }
    }
}
