namespace ExamThree
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExamThree
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string blockchain = MakeABlockchain(n);
            
            Regex rgx = new Regex(@"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])");

            StringBuilder sb = new StringBuilder();

            foreach (Match match in rgx.Matches(blockchain))
            {
                string digits = match.Groups["digits"].Value;

                if (digits.Length == 0 || digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int i = 0; i < digits.Length / 3; i++)
                {
                    string digitString = digits.Substring(3 * i, 3);

                    int length = match.Value.Length;

                    char letter = (char)(int.Parse(digitString) - length);

                    sb.Append(letter);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private static string MakeABlockchain(int n)
        {
            string blockchain = string.Empty;
            for (int i = 0; i < n; i++)
            {
                blockchain += Console.ReadLine();
            }

            return blockchain;
        }
    }
}
