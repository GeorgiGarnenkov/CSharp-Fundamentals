using System;
using System.Linq;

namespace GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var zero = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            var one = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            var two = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}
