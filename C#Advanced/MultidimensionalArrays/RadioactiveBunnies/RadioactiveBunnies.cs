using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var lairSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = lairSize[0];
            var columns = lairSize[1];

            var lair = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var strings = Console.ReadLine().ToCharArray();
                lair[row] = strings;
            }

            var commands = Console.ReadLine().ToCharArray();

            var winLosePosition = new int[2];
            bool playerWin = false;
            

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];

                playerWin = MovePlayer(lair, command, winLosePosition, playerWin);
                lair = SpreadBunnies(lair, winLosePosition, columns);

                if (playerWin)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        Console.WriteLine(string.Join("", lair[row]));
                    }
                    Console.WriteLine($"won: {winLosePosition[0]} {winLosePosition[1]}");
                    Environment.Exit(0);
                }

                bool playerDead = true;
                for (int dr = 0; dr < rows; dr++)
                {
                    for (int cd = 0; cd < columns; cd++)
                    {
                        if (lair[dr][cd] == 'P')
                        {
                            playerDead = false;
                            goto exit;
                        }
                    }
                }
                exit:
                if (playerDead && !playerWin)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        Console.WriteLine(string.Join("", lair[row]));
                    }
                    Console.WriteLine($"dead: {winLosePosition[0]} {winLosePosition[1]}");
                    Environment.Exit(0);
                }
            }
        }

        private static bool MovePlayer(char[][] lair, char command, int[] winLosePosition, bool playerWin)
        {
            if (command == 'U')
            {
                for (int r = 0; r < lair.Length; r++)
                {
                    for (int c = 0; c < lair[r].Length; c++)
                    {
                        if (lair[r][c] == 'P')
                        {
                            if (r - 1 >= 0)
                            {
                                if (lair[r - 1][c] == '.')
                                {
                                    lair[r - 1][c] = 'P';
                                    lair[r][c] = '.';
                                    goto exit;
                                }
                                else if (lair[r - 1][c] == 'B')
                                {
                                    lair[r][c] = '.';
                                    playerWin = false;
                                    winLosePosition[0] = r - 1;
                                    winLosePosition[1] = c;
                                    goto exit;
                                }
                            }
                            else
                            {
                                lair[r][c] = '.';
                                playerWin = true;
                                winLosePosition[0] = r;
                                winLosePosition[1] = c;
                                goto exit;
                            }
                        }
                    }
                }
            }
            else if (command == 'D')
            {
                for (int r = 0; r < lair.Length; r++)
                {
                    for (int c = 0; c < lair[r].Length; c++)
                    {
                        if (lair[r][c] == 'P')
                        {
                            if (r + 1 < lair.Length)
                            {
                                if (lair[r + 1][c] == '.')
                                {
                                    lair[r + 1][c] = 'P';
                                    lair[r][c] = '.';
                                    goto exit;
                                }
                                else if (lair[r + 1][c] == 'B')
                                {
                                    lair[r][c] = '.';
                                    playerWin = false;
                                    winLosePosition[0] = r + 1;
                                    winLosePosition[1] = c;
                                    goto exit;
                                }
                            }
                            else
                            {
                                lair[r][c] = '.';
                                playerWin = true;
                                winLosePosition[0] = r;
                                winLosePosition[1] = c;
                                goto exit;
                            }
                        }
                    }
                }
            }
            else if (command == 'L')
            {
                for (int r = 0; r < lair.Length; r++)
                {
                    for (int c = 0; c < lair[r].Length; c++)
                    {
                        if (lair[r][c] == 'P')
                        {
                            if (c - 1 >= 0)
                            {
                                if (lair[r][c - 1] == '.')
                                {
                                    lair[r][c - 1] = 'P';
                                    lair[r][c] = '.';
                                    goto exit;
                                }
                                else if (lair[r][c - 1] == 'B')
                                {
                                    lair[r][c] = '.';
                                    playerWin = false;
                                    winLosePosition[0] = r;
                                    winLosePosition[1] = c - 1;
                                    goto exit;
                                }
                            }
                            else
                            {
                                lair[r][c] = '.';
                                playerWin = true;
                                winLosePosition[0] = r;
                                winLosePosition[1] = c;
                                goto exit;
                            }
                        }
                    }
                }
            }
            else if (command == 'R')
            {
                for (int r = 0; r < lair.Length; r++)
                {
                    for (int c = 0; c < lair[r].Length; c++)
                    {
                        if (lair[r][c] == 'P')
                        {
                            if (c + 1 < lair[r].Length)
                            {
                                if (lair[r][c + 1] == '.')
                                {
                                    lair[r][c + 1] = 'P';
                                    lair[r][c] = '.';
                                    goto exit;
                                }
                                else if (lair[r][c + 1] == 'B')
                                {
                                    lair[r][c] = '.';
                                    playerWin = false;
                                    winLosePosition[0] = r;
                                    winLosePosition[1] = c + 1;
                                    goto exit;
                                }
                            }
                            else
                            {
                                lair[r][c] = '.';
                                playerWin = true;
                                winLosePosition[0] = r;
                                winLosePosition[1] = c;
                                goto exit;
                            }
                        }
                    }
                }
            }
            exit:
            return playerWin;
        }

        private static char[][] SpreadBunnies(char[][] lair, int[] winLosePosition, int columns)
        {
            List<int> bunniesPosition = new List<int>();
            for (int r = 0; r < lair.Length; r++)
            {
                for (int c = 0; c < lair[r].Length; c++)
                {
                    if (lair[r][c] == 'B')
                    {
                        bunniesPosition.Add(r);
                        bunniesPosition.Add(c);
                    }
                }
            }
            var playerDead = false;
            for (int i = 0; i < bunniesPosition.Count; i+=2)
            {
                var r = bunniesPosition[i];
                var c = bunniesPosition[i + 1];

                if (r - 1 >= 0)
                {
                    if (lair[r - 1][c] == '.')
                    {
                        lair[r - 1][c] = 'B';
                    }
                    else if (lair[r - 1][c] == 'P')
                    {
                        lair[r - 1][c] = 'B';
                        playerDead = true;
                        winLosePosition[0] = r - 1;
                        winLosePosition[1] = c;
                    }
                }
                if (r + 1 < lair.Length)
                {
                    if (lair[r + 1][c] == '.')
                    {
                        lair[r + 1][c] = 'B';
                    }
                    else if (lair[r + 1][c] == 'P')
                    {
                        lair[r + 1][c] = 'B';
                        playerDead = true;
                        winLosePosition[0] = r + 1;
                        winLosePosition[1] = c;
                    }
                }
                if (c - 1 >= 0)
                {
                    if (lair[r][c - 1] == '.')
                    {
                        lair[r][c - 1] = 'B';
                    }
                    else if (lair[r][c - 1] == 'P')
                    {
                        lair[r][c - 1] = 'B';
                        playerDead = true;
                        winLosePosition[0] = r;
                        winLosePosition[1] = c - 1;
                    }
                }
                if (c + 1 < columns)
                {
                    if (lair[r][c + 1] == '.')
                    {
                        lair[r][c + 1] = 'B';
                    }
                    else if (lair[r][c + 1] == 'P')
                    {
                        lair[r][c + 1] = 'B';
                        playerDead = true;
                        winLosePosition[0] = r;
                        winLosePosition[1] = c + 1;
                    }
                }
            }
            if (playerDead)
            {
                for (int row = 0; row < lair.Length; row++)
                {
                    Console.WriteLine(string.Join("", lair[row]));
                }
                Console.WriteLine($"dead: {winLosePosition[0]} {winLosePosition[1]}");
                Environment.Exit(0);
            }
            return lair;
        }
    }
}
