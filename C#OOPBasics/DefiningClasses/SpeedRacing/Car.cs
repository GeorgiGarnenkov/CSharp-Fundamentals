using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionForOneKm;
    private int distanceTraveled = 0;
    private double usedFuel;
    private int amountOfKm;


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public double FuelConsumptionForOneKm
    {
        get => fuelConsumptionForOneKm;
        set => fuelConsumptionForOneKm = value;
    }

    public int DistanceTraveled
    {
        get => distanceTraveled;
        set => distanceTraveled = value;
    }

    public double UsedFuel
    {
        get => usedFuel;
        set => usedFuel = amountOfKm * fuelConsumptionForOneKm;
    }

    public int AmountOfKm
    {
        get => amountOfKm;
        set => amountOfKm = value;
    }

    public void CanOrCannotMove()
    {
        if (UsedFuel <= FuelAmount)
        {
            FuelAmount -= UsedFuel;
            DistanceTraveled += AmountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }

    }
}