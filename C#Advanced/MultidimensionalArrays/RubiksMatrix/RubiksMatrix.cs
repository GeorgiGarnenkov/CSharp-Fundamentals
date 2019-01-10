using System;
using System.Linq;

namespace RubiksMatrix
{
    public class RubiksMatrix
    {

        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var cols = matrixSizes[1];

            int[][] matrix = new int[rows][];

            var count = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = count++;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var rcIndex = int.Parse(commandArgs[0]);
                var direction = commandArgs[1];
                var moves = int.Parse(commandArgs[2]);

                switch (direction)
                {
                    case "up":
                        MoveColumn(matrix, rcIndex, moves);
                        break;
                    case "down":
                        MoveColumn(matrix, rcIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, rcIndex, cols - moves % cols);
                        break;
                }
            }

            var element = 1;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) " +
                                                      $"with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix[0].Length];

            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                temp[colIndex] = matrix[rcIndex][(colIndex + moves) % matrix[0].Length];
            }
            matrix[rcIndex] = temp;

        }

        static void MoveColumn(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.Length];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][rcIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][rcIndex] = temp[rowIndex];
            }
        }
    }
}
