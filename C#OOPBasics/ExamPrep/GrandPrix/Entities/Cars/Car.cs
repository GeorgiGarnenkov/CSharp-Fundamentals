using System;

public class Car
{
    public const int tankMaxCapacity = 160;

    private double fuelAmount;
   
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, tankMaxCapacity);
        }
    }

    public Tyre Tyre { get; private set; }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}