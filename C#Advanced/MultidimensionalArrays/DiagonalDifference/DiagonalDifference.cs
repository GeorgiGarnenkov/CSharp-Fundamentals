using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {
            var matrixSize = long.Parse(Console.ReadLine());

            long[][] matrix = new long[matrixSize][];
            

            for (int row = 0; row < matrix.Length; row++)
            {
                var elements = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();
                
                matrix[row] = elements;
            }

            long firstDiagonalSum = 0;
            long secondDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                 firstDiagonalSum += matrix[row][row];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                secondDiagonalSum += matrix[row][matrix.Length - 1 - row];
            }
            long difference = 0;
            if (firstDiagonalSum >= secondDiagonalSum)
            {
                difference = firstDiagonalSum - secondDiagonalSum;
            }
            else
            {
                difference = secondDiagonalSum - firstDiagonalSum;
            }


            Console.WriteLine(difference);
        }
    }
}
