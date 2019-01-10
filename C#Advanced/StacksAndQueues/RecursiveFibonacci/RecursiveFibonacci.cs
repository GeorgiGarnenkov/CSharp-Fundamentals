using System;
using System.Dynamic;

namespace RecursiveFibonacci
{
    public class RecursiveFibonacci
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n)); ;

        }

        static double GetFibonacci(long n)
        {
            long[] array = new long[n];
            array[0] = array[1] = 1;

            for (int i = 2; i < n; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }
            return array[n - 1];
        }
    }
}
