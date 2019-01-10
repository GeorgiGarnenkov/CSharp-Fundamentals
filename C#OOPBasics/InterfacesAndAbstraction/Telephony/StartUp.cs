using System;

public class StartUp
{
    public static void Main()
    {
        string[] numbers = Console.ReadLine().Split();
        string[] urls = Console.ReadLine().Split();

        Smartphone smartphone = new Smartphone();

        foreach (var num in numbers)
        {
            Console.WriteLine(smartphone.Calling(num));
        }

        foreach (var url in urls)
        {
            Console.WriteLine(smartphone.Browsing(url));
        }
        
    }
}