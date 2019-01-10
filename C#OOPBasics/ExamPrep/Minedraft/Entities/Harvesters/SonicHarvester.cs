using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    private int SonicFactor
    {
        get => sonicFactor;
        set => sonicFactor = value;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Sonic Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().TrimEnd();
    }
}