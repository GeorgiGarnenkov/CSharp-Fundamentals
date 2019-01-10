public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model)
    {
        this.Model = model;
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
        return $"{this.Model}:\r\n  {this.Engine.Model}:\r\n    Power: {this.Engine.Power}\r\n    Displacement: {this.Engine.Displacement}\r\n    Efficiency: {this.Engine.Efficiency}\r\n  Weight: {this.Weight}\r\n  Color: {this.Color}";
    }
}