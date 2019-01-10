using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = FillMatrix(dimestions);

        string command;

        long sum = 0;

        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] jediPath = command
                .Split(new string[] { " " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] sithPath = Console.ReadLine()
                .Split(new string[] { " " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SithMove(matrix, sithPath);

            sum = JediMoveAndSum(matrix, sum, jediPath);
        }

        Console.WriteLine(sum);

    }

    private static int[,] FillMatrix(int[] dimestions)
    {
        int rows = dimestions[0];
        int cols = dimestions[1];

        int[,] matrix = new int[rows, cols];

        int value = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = value++;
            }
        }

        return matrix;
    }

    private static void SithMove(int[,] matrix, int[] sithPath)
    {
        int xSith = sithPath[0];
        int ySith = sithPath[1];

        while (xSith >= 0 && ySith >= 0)
        {
            if (InsideMatrix(matrix, xSith, ySith))
            {
                matrix[xSith, ySith] = 0;
            }
            xSith--;
            ySith--;
        }
    }

    private static long JediMoveAndSum(int[,] matrix, long sum, int[] jediPath)
    {
        int xJedi = jediPath[0];
        int yJedi = jediPath[1];

        while (xJedi >= 0 && yJedi < matrix.GetLength(1))
        {
            if (InsideMatrix(matrix, xJedi, yJedi))
            {
                sum += matrix[xJedi, yJedi];
            }

            yJedi++;
            xJedi--;
        }

        return sum;
    }

    private static bool InsideMatrix(int[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
    }
}
