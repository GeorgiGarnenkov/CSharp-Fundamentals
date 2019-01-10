﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(matrixSizes[0]);
            var columns = int.Parse(matrixSizes[1]);

            var snake = Console.ReadLine();

            var shotParameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char[,] stairs = FillMatrix(snake, rows, columns);

            stairs = FireShot(shotParameters, stairs);

            stairs = Gravity(stairs);

            PrintMatrix(stairs);
        }

        private static void PrintMatrix(char[,] stairs)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    sb.Append(stairs[row, col]);
                }
                sb.AppendLine();
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        private static char[,] Gravity(char[,] stairs)
        {
            for (int col = 0; col < stairs.GetLength(1); col++)
            {
                int emptyRows = 0;
                for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
                {
                    if (stairs[row, col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if (emptyRows > 0)
                    {
                        stairs[row + emptyRows, col] = stairs[row, col];
                        stairs[row, col] = ' ';
                    }
                }
            }
            return stairs;
        }

        private static char[,] FireShot(string[] shotParameters, char[,] stairs)
        {
            int row = int.Parse(shotParameters[0]);
            int column = int.Parse(shotParameters[1]);
            int radius = int.Parse(shotParameters[2]);

            for (int r = 0; r < stairs.GetLength(0); r++)
            {
                for (int c = 0; c < stairs.GetLength(1); c++)
                {
                    int a = row - r;
                    int b = column - c;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        stairs[r, c] = ' ';
                    }
                }
            }
            return stairs;
        }

        private static char[,] FillMatrix(string snake, int rows, int columns)
        {
            var matrix = new char[rows, columns];

            bool isGoingLeft = true;
            int snakeIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                int index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;
                int increment = isGoingLeft ? -1 : 1;
                
                for (int i = 0; i < columns; i++)
                {
                    matrix[row, index] = snake[snakeIndex++];

                    if (snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                    index += increment;
                }
                isGoingLeft = !isGoingLeft;
            }
            return matrix;
        }
    }
}
