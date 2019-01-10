using System;
using System.Linq;

namespace SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[][] matrix = new string[matrixSizes[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            var counter = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        counter++;
                    }
                   
                }
            }
            Console.WriteLine(counter);
        }
    }
}
