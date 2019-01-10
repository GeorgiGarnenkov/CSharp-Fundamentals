using System;
using System.Collections.Generic;
namespace exam1
{
    public class StartUp
    {
        public static void Main()
        {
            var greenDuration = int.Parse(Console.ReadLine());

            var freeWindowDuration = int.Parse(Console.ReadLine());

           List<string> queue = new List<string>();
            string input;
            var counter = 0;
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input;

                if (command == "green")
                {
                    var greenDurationLeft = greenDuration;
                    var freeWindowDurationLeft = freeWindowDuration;

                    for (int i = 0; i < queue.Count; i++)
                    {
                        var carName = queue[i];
                        var car = queue[i];
                        var carLength = car.Length;


                        if (carLength <= greenDurationLeft)
                        {
                            queue.RemoveAt(i);
                            greenDurationLeft -= carLength;
                            i--;
                            counter++;
                            continue;
                        }

                        if (carLength > greenDurationLeft)
                        {
                            queue[i] = queue[i].ToString().Remove(0, greenDurationLeft);
                            if (queue[i].Length <= freeWindowDuration)
                            {
                                queue.RemoveAt(i);
                                counter++;
                            }
                            else
                            {
                                queue[i] = queue[i].ToString().Remove(0, freeWindowDuration);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carName} was hit at {queue[i][0]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    queue.Add(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
