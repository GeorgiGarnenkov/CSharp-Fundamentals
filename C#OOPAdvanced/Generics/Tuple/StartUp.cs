using System;

namespace Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var name = input[0] + " " + input[1];
            var address = input[2];
            var nameAndAddress = new MyTuple<string, string>(name, address);
            Console.WriteLine(nameAndAddress.ToString());


            input = Console.ReadLine().Split();
            var nameAndBeers = new MyTuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(nameAndBeers.ToString());


            input = Console.ReadLine().Split();
            var intsAndDoubles = new MyTuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(intsAndDoubles.ToString());
            

        }
    }
}
