using System;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                print($"Sir {name}");
            }
        }
    }
}
