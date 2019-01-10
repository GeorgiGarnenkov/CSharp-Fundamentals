using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EarthNation
{
    private decimal bendersTotalPower;
    private long percentFromMonuments;
    private decimal nationTotalPower;

    public EarthNation()
    {
        this.EarthBenders = new List<EarthBender>();
        this.EarthMonuments = new List<EarthMonument>();
    }

    public List<EarthBender> EarthBenders { get; set; }

    public List<EarthMonument> EarthMonuments { get; set; }

    public long PercentFromMonuments
    {
        get => percentFromMonuments;
        set => percentFromMonuments = value;
    }

    public decimal BendersTotalPower
    {
        get => bendersTotalPower;
        set => bendersTotalPower = value;
    }

    public decimal NationTotalPower
    {
        get => nationTotalPower;
        set => nationTotalPower = value;
    }

    public decimal Check()
    {
        this.BendersTotalPower = this.EarthBenders.Sum(a => a.TotalPower);
        this.PercentFromMonuments = this.EarthMonuments.Sum(a => a.EarthAffinity);

        if (this.PercentFromMonuments != 0)
        {
            return this.NationTotalPower = this.BendersTotalPower + ((this.BendersTotalPower / 100) * this.PercentFromMonuments);
        }
        else
        {
            return this.NationTotalPower = BendersTotalPower;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{NationNames.Earth.ToString()} Nation");

        if (this.EarthBenders.Count > 0)
        {
            sb.AppendLine($"Benders:");
            foreach (var earthBender in this.EarthBenders)
            {
                sb.AppendLine($"###{earthBender.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Benders: None");
        }

        
        if (this.EarthMonuments.Count > 0)
        {
            sb.AppendLine($"Monuments:");
            foreach (var earthMonument in this.EarthMonuments)
            {
                sb.AppendLine($"###{earthMonument.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Monuments: None");
        }

        return sb.ToString().TrimEnd();
    }
}
