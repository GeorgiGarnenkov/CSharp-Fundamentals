using System;
using System.Linq;

namespace SumMatrixElements
{
    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            int[][] matrix = new int[int.Parse(matrixSizes[0])][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int maxSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                    maxSum += matrix[row].Sum();
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(maxSum);
        }
    }
}
