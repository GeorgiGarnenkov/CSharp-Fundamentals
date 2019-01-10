public class AirMonument : Monument
{
    private long airAffinity;

    public AirMonument(string name, long airAffinity)
        : base(name)
    {
        this.AirAffinity = airAffinity;
        
    }

    public long AirAffinity
    {
        get => airAffinity;
        set => airAffinity = value;
    }

    public override string ToString()
    {
        return $"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }
}