public class FireBender : Bender
{
    private decimal heatAggression;

    public FireBender(string name, long power, decimal heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
        this.TotalPower = this.Power * this.HeatAggression;
    }

    private decimal HeatAggression
    {
        get => this.heatAggression;
        set => this.heatAggression = value;
    }

    public override string ToString()
    {
        return $"Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:f2}";
    }
}

