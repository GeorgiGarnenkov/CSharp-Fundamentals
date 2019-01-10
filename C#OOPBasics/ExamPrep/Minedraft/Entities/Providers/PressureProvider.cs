using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput / 2;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Pressure Provider - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().TrimEnd();
    }
}