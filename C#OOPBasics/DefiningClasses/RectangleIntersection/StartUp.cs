using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        List<Rectangle> rectangles = new List<Rectangle>();

        var n = input[0];
        var m = input[1];

        for (int i = 0; i < n; i++)
        {
            var inputRectangle = Console.ReadLine().Split();

            Rectangle rectangle = new Rectangle();

            rectangle.Id = inputRectangle[0];
            rectangle.Width = double.Parse(inputRectangle[1]);
            rectangle.Height = double.Parse(inputRectangle[2]);
            rectangle.X = double.Parse(inputRectangle[3]);
            rectangle.Y = double.Parse(inputRectangle[4]);

            rectangles.Add(rectangle);
        }
        

        for (int i = 0; i < m; i++)
        {
            var inputPairs = Console.ReadLine().Split();

            var firstId = inputPairs[0];
            var secondId = inputPairs[1];

            var firstRectangle = rectangles.FirstOrDefault(a => a.Id == firstId);
            var secondRectangle = rectangles.FirstOrDefault(a => a.Id == secondId);

            if (firstRectangle == null || secondRectangle == null)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine(firstRectangle.CheckRectanglesForIntersect(secondRectangle) ? "true" : "false");
            }
        }
    }
}
