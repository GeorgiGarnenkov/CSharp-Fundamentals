public class Parent
{
    private string name;
    private string birthday;

    public Parent(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name { get => name; set => name = value; }
    public string Birthday { get => birthday; set => birthday = value; }
}