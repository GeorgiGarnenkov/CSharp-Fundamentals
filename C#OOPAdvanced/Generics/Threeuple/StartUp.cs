using System;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var name = input[0] + " " + input[1];
            var address = input[2];
            var town = input[3];
            var nameAndAddress = new MyTuple<string, string, string>(name, address, town);

            Console.WriteLine(nameAndAddress.ToString());


            input = Console.ReadLine().Split();
            string drunkOrNot = input[2];
            if (drunkOrNot == "drunk")
            {
                var nameAndBeers = new MyTuple<string, int, bool>(input[0], int.Parse(input[1]), true);

                Console.WriteLine(nameAndBeers.ToString());
            }
            else
            {
                var nameAndBeers = new MyTuple<string, int, bool>(input[0], int.Parse(input[1]), false);

                Console.WriteLine(nameAndBeers.ToString());
            }
            
            
            input = Console.ReadLine().Split();
            var intsAndDoubles = new MyTuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);

            Console.WriteLine(intsAndDoubles.ToString());
        }
    }
}
