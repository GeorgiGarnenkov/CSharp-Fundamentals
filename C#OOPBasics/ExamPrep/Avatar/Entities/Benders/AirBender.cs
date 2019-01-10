public class AirBender : Bender
{
    private decimal aerialIntegrity;

    public AirBender(string name, long power, decimal aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
        this.TotalPower = this.Power * this.AerialIntegrity;
    }

    public decimal AerialIntegrity
    {
        get => this.aerialIntegrity;
        set => this.aerialIntegrity = value;
    }

    public override string ToString()
    {
        return $"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}