namespace KnightGame
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            char[][] board = new char[n][];

            for (int rows = 0; rows < n; rows++)
            {
                var row = Console.ReadLine();
                board[rows] = row.ToCharArray();
            }

            int result = Checking(board);


            Console.WriteLine(result);

        }

        private static int Checking(char[][] board)
        {
            var result = 0;

            again:
            var position = new int[2];
            var knightCounter = 0;

            knightCounter = KnightCounter(board, position, knightCounter);

            if (knightCounter != 0)
            { 
                board[position[0]][position[1]] = 'O';
                result++;
                goto again;
            }
            return result;
        }

        private static int KnightCounter(char[][] board, int[] position, int knightCounter)
        {
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    var currentKnightCounter = 0;
                    if (board[r][c] == 'K')
                    {
                        if (r - 2 >= 0 && c - 1 >= 0)
                        {
                            if (board[r - 2][c - 1] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r - 2 >= 0 && c + 1 < board[0].Length)
                        {
                            if (board[r - 2][c + 1] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r - 1 >= 0 && c - 2 >= 0)
                        {
                            if (board[r - 1][c - 2] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r - 1 >= 0 && c + 2 < board[0].Length)
                        {
                            if (board[r - 1][c + 2] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r + 1 < board.Length && c - 2 >= 0)
                        {
                            if (board[r + 1][c - 2] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r + 1 < board.Length && c + 2 < board[0].Length)
                        {
                            if (board[r + 1][c + 2] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r + 2 < board.Length && c - 1 >= 0)
                        {
                            if (board[r + 2][c - 1] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }

                        if (r + 2 < board.Length && c + 1 < board[0].Length)
                        {
                            if (board[r + 2][c + 1] == 'K')
                            {
                                currentKnightCounter++;
                            }
                        }
                    }

                    if (knightCounter < currentKnightCounter)
                    {
                        knightCounter = currentKnightCounter;
                        position[0] = r;
                        position[1] = c;
                    }
                }
            }

            return knightCounter;
        }
    }
}
