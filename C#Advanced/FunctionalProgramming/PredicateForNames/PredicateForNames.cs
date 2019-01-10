using System;

namespace PredicateForNames
{
    using System.Linq;

    class PredicateForNames
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Func<string, bool> checker = w => w.Length <= n;

            var namesLeft = names.Where(checker);

            foreach (var name in namesLeft)
            {
                Console.WriteLine(name);
            }
        }
    }
}
