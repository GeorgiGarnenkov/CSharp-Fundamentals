using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Crossfire
    {
        static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var cols = matrixSizes[1];

            List<List<long>> matrix = new List<List<long>>();

            FillMatrix(rows, cols, matrix);
            
            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var commandArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var shotRow = commandArgs[0];
                var shotCol = commandArgs[1];
                var radius = commandArgs[2];


                for (int r = 0; r < matrix.Count; r++)
                {
                    for (int c = 0; c < matrix[r].Count; c++)
                    {
                        if ((r == shotRow && Math.Abs(c - shotCol) <= radius) ||
                            (c == shotCol && Math.Abs(r - shotRow) <= radius))
                        {
                            matrix[r][c] = 0;
                        }
                    }
                }
                for (int r = 0; r < matrix.Count; r++)
                {
                    matrix[r].RemoveAll(x => x == 0);
                    if (matrix[r].Count == 0)
                    {
                        matrix.RemoveAt(r);
                        r--;
                    }
                }
            }
            for (int r = 0; r < matrix.Count; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r]));
            }

        }

        private static void FillMatrix(int rows, int cols, List<List<long>> matrix)
        {
            var count = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<long>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(count++);
                }
            }
        }
    }
}
