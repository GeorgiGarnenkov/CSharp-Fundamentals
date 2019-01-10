using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;

    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int Id { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
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
        return this.OreOutput;
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrease;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine +
               $"Durability: {this.Durability}";
    }
}