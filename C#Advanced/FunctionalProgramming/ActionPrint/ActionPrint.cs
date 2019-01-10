using System;
using System.Runtime.InteropServices;

namespace ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine(n);
            
            foreach (var name in names)
            {
                print(name);
            }
            
        }
    }
}
