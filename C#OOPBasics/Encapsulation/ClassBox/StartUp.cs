using System;
using System.Runtime.ConstrainedExecution;

public class StartUp
{
    public static void Main()
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        Box box = new Box(length, width, height);

        Console.WriteLine(box.ToString());
    }
}