using System;
using System.Linq;

namespace LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var firstMatrix = new int[n][];
            var secondMatrix = new int[n][];
            FillMatrix(firstMatrix, secondMatrix);
            ConcatMatrixes(n, firstMatrix, secondMatrix);
            PrintResult(n, firstMatrix);

        }
        private static void PrintResult(int n, int[][] firstMatrix)
        {
            bool isEquel = true;
            for (int row = 0; row < n - 1; row++)
            {
                var length = firstMatrix[row].Length;
                isEquel = length == firstMatrix[row + 1].Length;
            }

            if (isEquel)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstMatrix[row])}]");
                }
            }
            else
            {
                var countOfElements = 0;
                for (int row = 0; row < n; row++)
                {
                    countOfElements += firstMatrix[row].Length;
                }
                Console.WriteLine($"The total number of cells is: {countOfElements}");
            }
        }

        private static void ConcatMatrixes(int n, int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] secondMatrixReversedRow = secondMatrix[row].Reverse().ToArray();
                firstMatrix[row] = firstMatrix[row].Concat(secondMatrixReversedRow).ToArray();
            }
        }

        private static void FillMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int rows = 0; rows < firstMatrix.Length; rows++)
            {
                var colsElements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                firstMatrix[rows] = colsElements;
            }
            for (int rows = 0; rows < secondMatrix.Length; rows++)
            {
                var colsElements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                secondMatrix[rows] = colsElements;
            }
        }
    }
}
