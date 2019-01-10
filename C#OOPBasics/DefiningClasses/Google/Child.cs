public class Child
{
    private string name;
    private string birthday;

    public Child(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name { get => name; set =>name = value; }
    public string Birthday { get => birthday; set => birthday = value; }
}
