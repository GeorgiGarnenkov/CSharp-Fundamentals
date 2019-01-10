using System.Collections.Generic;
using System.Text;

namespace Regeh
{
    using System;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main()
        {
            var pattern = @"\[\w+\<(\d+)REGEH(\d+)\>\w+\]";

            var input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            List<int> nums = new List<int>();
            foreach (Match m in matches)
            {
                var first = int.Parse(m.Groups[1].Value);
                var second = int.Parse(m.Groups[2].Value);
                nums.Add(first);
                nums.Add(second);
            }

            if (nums.Count < 1)
            {
                Console.WriteLine();
                Environment.Exit(0);
            }
            var sb = new StringBuilder();
            var num = nums[0];
            for (int i = 0; i < nums.Count - 1; i++)
            {
                var numTwo = nums[i + 1];
                if (num >= input.Length)
                {
                    num = num % input.Length;
                }
                sb.Append(input[num]);
                num += numTwo;
            }
            if (num >= input.Length)
            {
                num = num % input.Length;
                sb.Append(input[num + 1]);
            }
            else
            {
                sb.Append(input[num]);
            }
         

            Console.WriteLine(sb.ToString());
        }
    }
}
