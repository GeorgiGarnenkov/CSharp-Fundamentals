using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class Family
{
    private List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.people
            .OrderByDescending(a => a.Age)
            .FirstOrDefault();
    }

    public List<Person> GetOlderThenThirty()
    {
        return this.people
            .FindAll(a => a.Age > 30)
            .OrderBy(a => a.Name)
            .ToList();
    }

}

