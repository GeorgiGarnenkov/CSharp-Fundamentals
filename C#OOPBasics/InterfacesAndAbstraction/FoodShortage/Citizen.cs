public abstract class Citizen
{
    private string name;
    private string age;
    private string model;
    private string id;
    private string birthdate;
    private string group;
    private int food = 0;

    protected Citizen(string name, string age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    protected Citizen(string name, string age , string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }
    


    public string Name
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

    private string Birthdate
    {
        get => birthdate;
        set => birthdate = value;
    }

    private string Group
    {
        get => this.group;
        set => this.group = value;
    }

    public virtual int Food
    {
        get => food;
        set => food = value;
    }

    public virtual void BuyFood()
    {
    }
}