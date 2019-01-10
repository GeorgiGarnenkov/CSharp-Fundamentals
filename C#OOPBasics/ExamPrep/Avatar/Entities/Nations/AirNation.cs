using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AirNation
{
    private long percentFromMonuments;
    private decimal bendersTotalPower;
    private decimal nationTotalPower;

    public AirNation()
    {
        this.AirBenders = new List<AirBender>();
        this.AirMonuments = new List<AirMonument>();
    }

    public List<AirBender> AirBenders { get; set; }

    public List<AirMonument> AirMonuments { get; set; }

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
        this.BendersTotalPower = this.AirBenders.Sum(a => a.TotalPower);
        this.PercentFromMonuments = this.AirMonuments.Sum(a => a.AirAffinity);

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

        sb.AppendLine($"{NationNames.Air.ToString()} Nation");
           

        if (this.AirBenders.Count > 0)
        {
            sb.AppendLine($"Benders:");
            foreach (var airBender in this.AirBenders)
            {
                sb.AppendLine($"###{airBender.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Benders: None");
        }

        
        if (this.AirMonuments.Count > 0)
        {
            sb.AppendLine($"Monuments:");
            foreach (var airMonument in this.AirMonuments)
            {
                sb.AppendLine($"###{airMonument.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Monuments: None");
        }

        return sb.ToString().TrimEnd();
    }
}