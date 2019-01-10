public class WaterBender : Bender
{
    private decimal waterClarity;

    public WaterBender(string name, long power, decimal waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
        this.TotalPower = this.Power * this.WaterClarity;
    }

    private decimal WaterClarity
    {
        get => this.waterClarity;
        set => this.waterClarity = value;
    }

    public override string ToString()
    {
        return $"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:f2}";
    }
}
