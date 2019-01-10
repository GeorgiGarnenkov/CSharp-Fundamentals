using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExamOne
{
    public class ExamOne
    {
        public static void Main()
        {
            int priceForBullet = int.Parse(Console.ReadLine());

            int sizeOfBarrel = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            Queue<int> locksQueue = new Queue<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            int value = int.Parse(Console.ReadLine());

            int counter = 0;

            while (true)
            {
                int currentBullit = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();

                if (currentBullit <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    bulletsStack.Pop();
                    locksQueue.Dequeue();
                    value -= priceForBullet;

                    counter++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    value -= priceForBullet;

                    counter++;
                }

                if (counter == sizeOfBarrel && bulletsStack.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }

                if (locksQueue.Count == 0)
                {
                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${value}");
                    break;
                }

                if (bulletsStack.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    break;
                }
            }
        }
    }
}
