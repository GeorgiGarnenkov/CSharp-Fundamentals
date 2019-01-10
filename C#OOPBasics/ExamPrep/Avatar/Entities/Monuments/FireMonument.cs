public class FireMonument : Monument
{
    private long fireAffinity;

    public FireMonument(string name, long fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public long FireAffinity
    {
        get => this.fireAffinity;
        set => this.fireAffinity = value;
    }

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}