using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FireNation
{
    private decimal bendersTotalPower;
    private long percentFromMonuments;
    private decimal nationTotalPower;

    public FireNation()
    {
        this.FireBenders = new List<FireBender>();
        this.FireMonuments = new List<FireMonument>();
    }


    public List<FireBender> FireBenders { get; set; }

    public List<FireMonument> FireMonuments { get; set; }

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
        this.BendersTotalPower = this.FireBenders.Sum(a => a.TotalPower);
        this.PercentFromMonuments = this.FireMonuments.Sum(a => a.FireAffinity);

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

        sb.AppendLine($"{NationNames.Fire.ToString()} Nation");


        if (this.FireBenders.Count > 0)
        {
            sb.AppendLine($"Benders:");
            foreach (var fireBender in this.FireBenders)
            {
                sb.AppendLine($"###{fireBender.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Benders: None");
        }


        if (this.FireMonuments.Count > 0)
        {
            sb.AppendLine($"Monuments:");
            foreach (var fireMonument in this.FireMonuments)
            {
                sb.AppendLine($"###{fireMonument.ToString()}");
            }
        }
        else
        {
            sb.AppendLine($"Monuments: None");
        }

        return sb.ToString().TrimEnd();
    }
}