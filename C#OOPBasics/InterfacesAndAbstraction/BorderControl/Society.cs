public abstract class Society
{
    private string name;
    private string age;
    private string model;
    private string id;

    public Society(string name, string age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public Society(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Age
    {
        get => age;
        set => age = value;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }
}