public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Type
    {
        get => type;
        set => type = value;
    }
}