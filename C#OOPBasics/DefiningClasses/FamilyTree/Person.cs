using System.Collections.Generic;
using System.Linq;

public class Person
{
    private List<Person> children;

    public Person()
    {
        this.children = new List<Person>();
    }

    public Person(string name, string date) : this()
    {
        this.Name = name;
        this.Birthday = date;
    }


    public string Name { get; set; }

    public string Birthday { get; set; }

    public IReadOnlyList<Person> Children
    {
        get { return this.children.AsReadOnly(); }
    }

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }

    public void AddChildrenInfo(string name, string date)
    {
        if (this.children.FirstOrDefault(c => c.Name == name) != null)
        {
            this.children.FirstOrDefault(c => c.Name == name).Birthday = date;
            return;
        }
        if (this.children.FirstOrDefault(c => c.Birthday == date) != null)
        {
            this.children.FirstOrDefault(c => c.Birthday == date).Name = name;
            return;
        }
    }

    public Person FindChildName(string childName)
    {
        return this.children.FirstOrDefault(c => c.Name == childName);
    }
}
