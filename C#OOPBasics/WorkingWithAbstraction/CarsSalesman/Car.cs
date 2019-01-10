using System.Text;

class Car
{
    private const string offset = "  ";
    private string model;
    private Engine engine;
    private string weight = "n/a";
    private string color = "n/a";

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public Car(string model, Engine engine, string weightOrColor) 
        : this(model, engine)
    {
        if (int.TryParse(weightOrColor, out int disp))
        {
            this.Weight = disp.ToString();
        }
        else
        {
            this.Color = weightOrColor;
        }

    }

    public Car(string model, Engine engine, string weight, string color) 
        : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }
    public Engine Engine
    {
        get => engine;
        set => engine = value;
    }

    public string Weight
    {
        get => weight;
        set => weight = value;
    }

    public string Color
    {
        get => color;
        set => color = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Model}:");
        sb.AppendLine(this.Engine.ToString());
        sb.AppendLine($"{offset}Weight: {this.Weight}");
        sb.Append($"{offset}Color: {this.Color}");

        return sb.ToString();
    }
}