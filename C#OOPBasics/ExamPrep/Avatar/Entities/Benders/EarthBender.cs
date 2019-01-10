public class EarthBender : Bender
{
    private decimal groundSaturation;

    public EarthBender(string name, long power, decimal groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
        this.TotalPower = this.Power * this.GroundSaturation;
    }

    private decimal GroundSaturation
    {
        get => this.groundSaturation;
        set => this.groundSaturation = value;
    }

    public override string ToString()
    {
        return $"Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}