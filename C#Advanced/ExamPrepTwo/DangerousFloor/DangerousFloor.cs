using System;
using System.Linq;

namespace DangerousFloor
{
    class DangerousFloor
    {
        static char[][] board;

        static void Main(string[] args)
        {
            board = new char[8][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().Split(',')
                    .Select(char.Parse).ToArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                char figureType = command[0];
                int startingRow = int.Parse(command[1].ToString());
                int startingCol = int.Parse(command[2].ToString());
                int targetRow = int.Parse(command[4].ToString());
                int targetCol = int.Parse(command[5].ToString());

                if (!FigureExists(figureType, startingRow, startingCol))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsMoveValid(figureType, startingRow, startingCol, targetRow, targetCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (!OutOfBoard(targetRow, targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[targetRow][targetCol] = figureType;
                board[startingRow][startingCol] = 'x';
            }
        }

        private static bool OutOfBoard(int row, int col)
        {
            bool validRow = row >= 0 && row <= 7;
            bool validCol = col >= 0 && col <= 7;

            return validRow && validCol;
        }

        private static bool IsMoveValid(char figureType, int startingRow, int startingCol, int targetRow, int targetCol)
        {
            switch (figureType)
            {
                case 'P':
                    return ValidPawnMove(startingRow, startingCol, targetRow, targetCol);
                case 'R':
                    return ValidStraightMove(startingRow, startingCol, targetRow, targetCol);
                case 'B':
                    return ValidDiagonalMove(startingRow, startingCol, targetRow, targetCol);
                case 'Q':
                    return ValidStraightMove(startingRow, startingCol, targetRow, targetCol) ||
                            ValidDiagonalMove(startingRow, startingCol, targetRow, targetCol);
                case 'K':
                    return ValidKingMove(startingRow, startingCol, targetRow, targetCol);
                default:
                    throw new Exception();
            }
        }

        private static bool ValidKingMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool rowMove = Math.Abs(startingRow - targetRow) == 1
                && Math.Abs(startingCol - targetCol) == 0;
            bool columnMove = Math.Abs(startingCol - targetCol) == 1
                && Math.Abs(startingRow - targetRow) == 0;
            bool diagonalMove = Math.Abs(startingCol - targetCol) == 1
                && Math.Abs(startingRow - targetRow) == 1;

            return rowMove || columnMove || diagonalMove;
        }

        private static bool ValidDiagonalMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            return Math.Abs(startingRow - targetRow) == Math.Abs(startingCol - targetCol);
        }

        private static bool ValidStraightMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool sameRow = startingRow == targetRow;
            bool sameCol = startingCol == targetCol;

            return sameRow || sameCol;
        }

        private static bool ValidPawnMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool validColumn = startingCol == targetCol;
            bool validRow = startingRow - 1 == targetRow;

            return validColumn && validRow;
        }

        private static bool FigureExists(char figureType, int row, int col)
        {
            return board[row][col] == figureType;
        }
    }
}
