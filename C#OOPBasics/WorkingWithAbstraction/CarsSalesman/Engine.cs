using System.Text;

public class Engine
{
    private const string offset = "  ";
    private string model;
    private int power;
    private string displacement = "n/a";
    private string efficiency = "n/a";

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
    }

    public Engine(string model, int power, string displacementOrEfficiency)
        : this(model, power)
    {
        if (int.TryParse(displacementOrEfficiency, out int disp))
        {
            this.Displacement = disp.ToString();
        }
        else
        {
            this.Efficiency = displacementOrEfficiency;
        }

    }

    public Engine(string model, int power, string displacement, string efficiency)
        : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public int Power
    {
        get => power;
        set => power = value;
    }
    public string Displacement
    {
        get => displacement;
        set => displacement = value;
    }

    public string Efficiency
    {
        get => efficiency;
        set => efficiency = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{offset}{this.Model}:");
        sb.AppendLine($"{offset}{offset}Power: {this.Power}");
        sb.AppendLine($"{offset}{offset}Displacement: {this.Displacement}");
        sb.Append($"{offset}{offset}Efficiency: {this.Efficiency}");

        return sb.ToString();
    }
}