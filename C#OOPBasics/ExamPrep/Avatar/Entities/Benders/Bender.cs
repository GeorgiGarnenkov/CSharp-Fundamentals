public abstract class Bender
{
    private long power;

    protected Bender(string name, long power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name
    {
        get;
        private set;
    }

    public long Power
    {
        get => this.power;
        set => this.power = value;
    }

    public decimal TotalPower { get; set; }
}