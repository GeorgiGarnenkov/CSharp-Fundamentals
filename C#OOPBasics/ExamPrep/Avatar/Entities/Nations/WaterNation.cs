using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WaterNation
{
    private decimal bendersTotalPower;
    private long percentFromMonuments;
    private decimal nationTotalPower;

    public WaterNation()
    {
        this.WaterBenders = new List<WaterBender>();
        this.WaterMonuments = new List<WaterMonument>();
       
    }

   
    public List<WaterBender> WaterBenders { get; set; }

    public List<WaterMonument> WaterMonuments { get; set; }

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
        this.BendersTotalPower = this.WaterBenders.Sum(a => a.TotalPower);
        this.PercentFromMonuments = this.WaterMonuments.Sum(a => a.WaterAffinity);

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

        sb.AppendLine($"{NationNames.Water.ToString()} Nation");
            

        if (this.WaterBenders.Count > 0)
        {
            sb.AppendLine($"Benders:");
            foreach (var waterBender in this.WaterBenders)
            {
                sb.AppendLine($"###{waterBender.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Benders: None");
        }

        
        if (this.WaterMonuments.Count > 0)
        {
            sb.AppendLine($"Monuments:");
            foreach (var waterMonument in this.WaterMonuments)
            {
                sb.AppendLine($"###{waterMonument.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Monuments: None");
        }

        return sb.ToString().TrimEnd();
    }
}