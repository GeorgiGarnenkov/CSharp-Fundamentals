using System;
using System.Linq;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book( string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get => author;
        private set
        {
            if (CheckFirstLetter(value))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    public string Title
    {
        get => title;
        private set
        {
            if (value.Length <= 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get => price;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");
        
        string result = sb.ToString().TrimEnd();
        return result;
    }

    private bool CheckFirstLetter(string name)
    {
        var nameForCheck = name.Split(' ');
        if (nameForCheck.Length > 1)
        {
            var secondName = nameForCheck[1];

            return char.IsDigit(secondName[0]);
        }
        else
        {
            return false;
        }
    }
}