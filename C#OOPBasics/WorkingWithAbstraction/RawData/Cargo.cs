public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }

    public int Weight
    {
        get => weight;
        set => weight = value;
    }

    public string Type
    {
        get => type;
        set => type = value;
    }
}
