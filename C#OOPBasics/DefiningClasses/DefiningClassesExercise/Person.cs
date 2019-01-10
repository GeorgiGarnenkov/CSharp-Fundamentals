public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }
    public Person(int age)
    : this()
    {
        this.age = age;
    }
    public Person(string name, int age)
    : this(age)
    {
        this.name = name;
        this.age = age;
    }

}
