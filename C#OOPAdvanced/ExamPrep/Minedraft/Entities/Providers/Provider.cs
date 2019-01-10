using System;

public abstract class Provider : IProvider
{
    private double durability;
    private const double DefaultDurability = 1000;


    protected Provider(int id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public int Id { get; protected set; }

    public double EnergyOutput { get; protected set; }

    public double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.Id));
            }

            this.durability = value;
        }
    }


    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrease;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine +
               $"Durability: {this.Durability}";
    }
}