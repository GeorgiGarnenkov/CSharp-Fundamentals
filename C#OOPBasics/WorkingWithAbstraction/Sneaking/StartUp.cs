using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

public class StartUp
{
    static char[][] matrix;

    static void Main()
    {
        var matrixSize = int.Parse(Console.ReadLine());

        matrix = new char[matrixSize][];

        for (int row = 0; row < matrix.Length; row++)
        {
            var newRow = Console.ReadLine().ToCharArray().ToArray();
            matrix[row] = newRow;
        }

        var moves = Console.ReadLine().ToCharArray();

        int[] positionSam = new int[2];
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'S')
                {
                    positionSam[0] = row;
                    positionSam[1] = col;
                }
            }
        }
        foreach (var move in moves)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    switch (matrix[r][c])
                    {
                        case 'b':
                            if (r >= 0 && r < matrix.Length && c + 1 >= 0 && c + 1 < matrix[r].Length)
                            {
                                matrix[r][c] = '.';
                                matrix[r][c + 1] = 'b';
                                c++;
                            }
                            else
                            {
                                matrix[r][c] = 'd';
                            }

                            break;
                        case 'd':
                            if (r >= 0 && r < matrix.Length && c - 1 >= 0 && c - 1 < matrix[r].Length)
                            {
                                matrix[r][c] = '.';
                                matrix[r][c - 1] = 'd';
                            }
                            else
                            {
                                matrix[r][c] = 'b';
                            }

                            break;
                    }
                }
            }

            int[] positionEnemy = new int[2];

            for (int col = 0; col < matrix[positionSam[0]].Length; col++)
            {
                if (matrix[positionSam[0]][col] != '.' && matrix[positionSam[0]][col] != 'S')
                {
                    positionEnemy[0] = positionSam[0];
                    positionEnemy[1] = col;
                }
            }

            if (positionSam[1] < positionEnemy[1] && matrix[positionEnemy[0]][positionEnemy[1]] == 'd' && positionEnemy[0] == positionSam[0])
            {
                matrix[positionSam[0]][positionSam[1]] = 'X';
                Console.WriteLine($"Sam died at {positionSam[0]}, {positionSam[1]}");
                foreach (var r in matrix)
                {
                    foreach (var c in r)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                }
                return;
            }
            else if (positionEnemy[1] < positionSam[1] && matrix[positionEnemy[0]][positionEnemy[1]] == 'b' && positionEnemy[0] == positionSam[0])
            {
                matrix[positionSam[0]][positionSam[1]] = 'X';
                Console.WriteLine($"Sam died at {positionSam[0]}, {positionSam[1]}");

                foreach (var r in matrix)
                {
                    foreach (var c in r)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                }
                return;
            }

            matrix[positionSam[0]][positionSam[1]] = '.';
            switch (move)
            {
                case 'U':
                    positionSam[0]--;
                    break;
                case 'D':
                    positionSam[0]++;
                    break;
                case 'L':
                    positionSam[1]--;
                    break;
                case 'R':
                    positionSam[1]++;
                    break;
                default:
                    break;
            }

            matrix[positionSam[0]][positionSam[1]] = 'S';

            for (int col = 0; col < matrix[positionSam[0]].Length; col++)
            {
                if (matrix[positionSam[0]][col] != '.' && matrix[positionSam[0]][col] != 'S')
                {
                    positionEnemy[0] = positionSam[0];
                    positionEnemy[1] = col;
                }
            }
            if (matrix[positionEnemy[0]][positionEnemy[1]] == 'N' && positionSam[0] == positionEnemy[0])
            {
                matrix[positionEnemy[0]][positionEnemy[1]] = 'X';

                Console.WriteLine("Nikoladze killed!");
                foreach (var r in matrix)
                {
                    foreach (var c in r)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                }

                return;
            }
        }
    }
}