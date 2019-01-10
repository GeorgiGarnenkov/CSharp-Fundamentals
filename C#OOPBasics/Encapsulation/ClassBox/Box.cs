using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Xml.Schema;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    private double LiteralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    private double Area()
    {
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    }

    private double Volume()
    {
        return Length * Width * Height;
    }

    public override string ToString()
    {
        return $"Surface Area - {this.Area():f2}\n" +
               $"Lateral Surface Area - {this.LiteralSurfaceArea():f2}\n" +
               $"Volume - {this.Volume():f2}\n";
    }
}