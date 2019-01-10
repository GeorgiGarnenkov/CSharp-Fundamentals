public class WaterMonument : Monument
{
    private long waterAffinity;

    public WaterMonument(string name, long waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public long WaterAffinity
    {
        get => this.waterAffinity;
        set => this.waterAffinity = value;
    }

    public override string ToString()
    {
        return $"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}";
    }
}