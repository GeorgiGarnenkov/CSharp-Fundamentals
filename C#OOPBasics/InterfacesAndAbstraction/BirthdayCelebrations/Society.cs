public abstract class Society
{
    private string name;
    private string age;
    private string model;
    private string id;
    private string birthdate;

    protected Society(string name, string age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    protected Society(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
    


    private string Name
    {
        get => name;
        set => name = value;
    }

    private string Age
    {
        get => age;
        set => age = value;
    }

    private string Model
    {
        get => model;
        set => model = value;
    }

    private string Id
    {
        get => id;
        set => id = value;
    }

    public string Birthdate
    {
        get => birthdate;
        set => birthdate = value;
    }
}