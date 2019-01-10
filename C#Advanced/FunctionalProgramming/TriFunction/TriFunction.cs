using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(names.FirstOrDefault(name => name.ToCharArray().Sum(c => c) >= sum));
        }
    }
}
