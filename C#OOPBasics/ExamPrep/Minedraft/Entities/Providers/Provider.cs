using System;

public abstract class Provider : Machine
{
    
    private double energyOutput;

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }
    

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }
}