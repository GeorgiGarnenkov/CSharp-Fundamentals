using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ExamTwo
{
    public class ExamTwo
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixSize][];
            for (int row = 0; row < matrix.Length; row++)
            {
                var newRow = Console.ReadLine().ToCharArray().ToArray();
                matrix[row] = newRow;
            }

            var commandArgs = Console.ReadLine().ToCharArray().ToArray();

            int[] playerPosition = new int[2];
            int[] nikoladzePosition = new int[2];
            for (int i = 0; i < commandArgs.Length; i++)
            {
                var command = commandArgs[i];

                playerPosition = GetPlayerAndNikoladzePosition(matrix, playerPosition, nikoladzePosition);

                matrix = EnemyMoves(matrix, playerPosition);

                matrix = SamMove(matrix, playerPosition, nikoladzePosition, command);

            }

        }

        static int[] GetPlayerAndNikoladzePosition(char[][] matrix, int[] playerPosition, int[] nikoladzePosition)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }

                    if (matrix[row][col] == 'N')
                    {
                        nikoladzePosition[0] = row;
                        nikoladzePosition[1] = col;
                    }
                }
            }

            return playerPosition;
        }

        static char[][] SamMove(char[][] matrix, int[] playerPosition, int[] nikoladzePosition, char command)
        {
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];
            var nikolaRow = nikoladzePosition[0];
            var nikolaCol = nikoladzePosition[1];

            switch (command)
            {
                case 'U':
                    if (matrix[playerRow - 1] == matrix[nikolaRow])
                    {
                        Console.WriteLine($"Nikoladze killed!");
                        matrix[playerRow - 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';
                        matrix[nikolaRow][nikolaCol] = 'X';

                        PrintMatrix(matrix);

                        Environment.Exit(0);
                    }

                    if (matrix[playerRow - 1][playerCol] == 'b' || matrix[playerRow - 1][playerCol] == 'd')
                    {
                        matrix[playerRow - 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';
                    }
                    else if (matrix[playerRow][playerCol] == 'S')
                    {
                        matrix[playerRow - 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';

                        if (matrix[playerRow - 1].Contains('d'))
                        {
                            int indexOfD = string.Join("", matrix[playerRow - 1].ToArray())
                                .IndexOf('d');

                            if (indexOfD > playerCol)
                            {
                                Console.WriteLine($"Sam died at {playerRow - 1}, {playerCol}");
                                matrix[playerRow - 1][playerCol] = 'X';

                                PrintMatrix(matrix);

                                Environment.Exit(0);
                            }
                        }
                        if (matrix[playerRow - 1].Contains('b'))
                        {
                            int indexOfB = string.Join("", matrix[playerRow - 1].ToArray())
                                .IndexOf('b');

                            if (indexOfB < playerCol)
                            {
                                Console.WriteLine($"Sam died at {playerRow - 1}, {playerCol}");
                                matrix[playerRow - 1][playerCol] = 'X';

                                PrintMatrix(matrix);

                                Environment.Exit(0);
                            }
                        }

                    }
                    break;

                case 'D':
                    if (matrix[playerRow + 1] == matrix[nikolaRow])
                    {
                        Console.WriteLine($"Nikoladze killed!");
                        matrix[playerRow + 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';
                        matrix[nikolaRow][nikolaCol] = 'X';

                        PrintMatrix(matrix);
                        Environment.Exit(0);
                    }
                    if (matrix[playerRow + 1][playerCol] == 'b' || matrix[playerRow + 1][playerCol] == 'd')
                    {
                        matrix[playerRow + 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';
                    }
                    else if (matrix[playerRow][playerCol] == 'S')
                    {
                        matrix[playerRow + 1][playerCol] = 'S';
                        matrix[playerRow][playerCol] = '.';

                        if (matrix[playerRow + 1].Contains('d'))
                        {
                            int indexOfD = string.Join("", matrix[playerRow + 1].ToArray())
                                .IndexOf('d');

                            if (indexOfD > playerCol)
                            {
                                Console.WriteLine($"Sam died at {playerRow + 1}, {playerCol}");
                                matrix[playerRow + 1][playerCol] = 'X';

                                PrintMatrix(matrix);

                                Environment.Exit(0);
                            }
                        }
                        if (matrix[playerRow + 1].Contains('b'))
                        {
                            int indexOfB = string.Join("", matrix[playerRow + 1].ToArray())
                                .IndexOf('b');
                            
                            if (indexOfB < playerCol)
                            {
                                Console.WriteLine($"Sam died at {playerRow + 1}, {playerCol}");
                                matrix[playerRow + 1][playerCol] = 'X';
                            
                                PrintMatrix(matrix);
                            
                                Environment.Exit(0);
                            }
                        }
                    }
                    break;

                case 'L':
                    if (matrix[playerRow][playerCol] == 'S')
                    {
                        matrix[playerRow][playerCol - 1] = 'S';
                        matrix[playerRow][playerCol] = '.';
                        
                    }
                    break;

                case 'R':
                    if (matrix[playerRow][playerCol] == 'S')
                    {
                        matrix[playerRow][playerCol + 1] = 'S';
                        matrix[playerRow][playerCol] = '.';
                    }
                    break;

                case 'W':
                    if (matrix[playerRow][playerCol] == 'S')
                    {
                        matrix[playerRow][playerCol] = 'S';
                    }
                    break;
            }

            return matrix;
        }

        static char[][] EnemyMoves(char[][] matrix, int[] playerPosition)
        {
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                   
                    if (matrix[r][c] == 'b' && c == matrix[r].Length - 1)
                    {
                        matrix[r][c] = 'd';
                        if (r == playerRow)
                        {
                            Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                            matrix[playerRow][playerCol] = 'X';

                            PrintMatrix(matrix);
                            
                            Environment.Exit(0);
                        }
                        c += 1;
                        continue;
                    }

                    if (matrix[r][c] == 'd' && c == 0)
                    {
                        matrix[r][c] = 'b';
                        if (r == playerRow)
                        {
                            Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                            matrix[playerRow][playerCol] = 'X';

                            PrintMatrix(matrix);

                            Environment.Exit(0);
                        }
                        c += 1;
                        continue;
                    }

                    if (matrix[r][c] == 'b' && c < matrix[r].Length)
                    {
                        matrix[r][c + 1] = 'b';
                        matrix[r][c] = '.';
                        c += 1;
                        continue;
                    }

                    if (matrix[r][c] == 'd' && c > 0)
                    {
                        matrix[r][c - 1] = 'd';
                        matrix[r][c] = '.';
                        c += 1;
                    }
                }
            }

            return matrix;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}