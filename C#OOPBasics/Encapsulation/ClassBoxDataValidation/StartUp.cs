using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);
            Console.WriteLine(box.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}