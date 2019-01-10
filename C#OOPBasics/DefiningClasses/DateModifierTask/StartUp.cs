using System;

public class StartUp
{
    public static void Main()
    {
        var first = Console.ReadLine();
        var second = Console.ReadLine();

        DateModifier diff = new DateModifier();

        diff.GetDifferens(first, second);
    }
}
