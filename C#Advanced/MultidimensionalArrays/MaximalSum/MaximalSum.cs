using System;
using System.Linq;

namespace MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[matrixSizes[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = int.MinValue;
            var maxSquareRow = 0;
            var maxSquareCol = 0;
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    var firstRow = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2];
                    
                    var secondRow = matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2];
                    var thirdRow = matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    
                    var currentSum = firstRow + secondRow + thirdRow;
                                     
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxSquareRow][maxSquareCol]} " +
                              $"{matrix[maxSquareRow][maxSquareCol + 1]} {matrix[maxSquareRow][maxSquareCol + 2]}\n" +
                              $"{matrix[maxSquareRow + 1][maxSquareCol]} " +
                              $"{matrix[maxSquareRow + 1][maxSquareCol + 1]} {matrix[maxSquareRow + 1][maxSquareCol + 2]}\n" +
                              $"{matrix[maxSquareRow + 2][maxSquareCol]} {matrix[maxSquareRow + 2][maxSquareCol+ 1]} {matrix[maxSquareRow + 2][maxSquareCol + 2]}");
        }
    }
}
