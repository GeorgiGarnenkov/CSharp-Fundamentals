using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[][] matrix = new string[int.Parse(matrixSizes[0])][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[int.Parse(matrixSizes[1])];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var first = alphabet[row].ToString();
                    var second = alphabet[row + col].ToString();
                    var third = alphabet[row].ToString();

                    matrix[row][col] = first + second + third;
                }

            }

            foreach (var element in matrix)
            {
                Console.WriteLine(string.Join(" ", element));
            }
        }
    }
}
