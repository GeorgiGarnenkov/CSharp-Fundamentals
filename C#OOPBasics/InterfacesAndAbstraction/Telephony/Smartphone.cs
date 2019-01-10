using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string Calling(string number)
    {
        if (number.Any(Char.IsLetter))
        {
            return "Invalid number!";
        }

        return $"Calling... {number}";
    }

    public string Browsing(string url)
    {
        if (url.Any(char.IsDigit))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {url}!";
    }
}