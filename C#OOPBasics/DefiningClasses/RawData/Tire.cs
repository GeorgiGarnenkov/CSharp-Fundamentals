using System.Collections.Generic;

public class Tire
{
    private double pressure;
    private int age;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }
    public double Pressure
    {
        get => pressure;
        set => pressure = value;
    }
    public int Age
    {
        get => age;
        set => age = value;
    }


}