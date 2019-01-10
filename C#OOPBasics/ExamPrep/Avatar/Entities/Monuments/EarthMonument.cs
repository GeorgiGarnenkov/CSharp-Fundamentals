public class EarthMonument : Monument
{
    private long earthAffinity;

    public EarthMonument(string name, long earthAffinity) 
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public long EarthAffinity
    {
        get => this.earthAffinity;
        set => this.earthAffinity = value;
    }

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }
}
