using System;
using System.Linq;

namespace ParkingSystem
{
    class ParkingSystem
    {
        private static bool[][] parking;
        private static int rows;
        private static int cols;


        static void Main()
        {
            int[] demensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            rows = demensions[0];
            cols = demensions[1];

            parking = new bool[rows][];

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] commandArgs = command
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = commandArgs[0];
                int targetRow = commandArgs[1];
                int targetCol = commandArgs[2];

                if (IsSpotTaken(targetRow, targetCol))
                {
                    targetCol = TryFindFreeSpot(targetRow, targetCol);
                }

                if (targetCol > 0)
                {
                    MarkSpotAsTaken(targetRow, targetCol);

                    int distancePassed = Math.Abs(entryRow - targetRow) + targetCol + 1;
                    Console.WriteLine(distancePassed);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }

            }

        }

        private static void MarkSpotAsTaken(int targetRow, int targetCol)
        {
            if (parking[targetRow] == null)
            {
                parking[targetRow] = new bool[cols];
            }

            parking[targetRow][targetCol] = true;
        }

        private static int TryFindFreeSpot(int targetRow, int targetCol)
        {
            int parkingCol = 0;
            int bestDistance = 10001;

            for (int currentCol = 1; currentCol < cols; currentCol++)
            {
                if (!parking[targetRow][currentCol])
                {
                    int distance = Math.Abs(currentCol - targetCol);
                    if (distance < bestDistance)
                    {
                        parkingCol = currentCol;
                        bestDistance = distance;
                    }
                }
            }

            return parkingCol;
        }

        private static bool IsSpotTaken(int targetRow, int targetCol)
        {
            return parking[targetRow] != null && parking[targetRow][targetCol];
        }
    }
}
