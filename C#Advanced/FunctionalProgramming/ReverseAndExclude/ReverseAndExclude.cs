namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var commandNumber = int.Parse(Console.ReadLine());

            Func<int, bool> checker = n => n % commandNumber != 0;

            var checkedNumbers = numbers.Reverse().Where(checker);

            Console.WriteLine(string.Join(" ", checkedNumbers));
        }
    }
}
