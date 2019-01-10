using System.Collections.Generic;
using System.Linq;

namespace ExtendedDatabase
{
    using System;

    public class Database
    {
        private List<Person> people;

        public Database()
        {
            this.people = new List<Person>();
        }


        public void Add(Person person)
        {
            if (this.people.Any(un => un.UserName == person.UserName))
            {
                throw new InvalidOperationException($"Person with username - {person.UserName} already exists!");
            }
            if (this.people.Any(id => id.Id == person.Id))
            {
                throw new InvalidOperationException($"Person with id - {person.Id} already exists!");
            }

            this.people.Add(person);
        }

        public void Remove()
        {
            if (this.people.Count <= 0)
            {
                throw new InvalidOperationException("Database is emplty!");
            }

            this.people.RemoveAt(people.Count - 1);
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"{username} is Null or WhiteSpace!");
            }

            if (this.people.All(un => un.UserName != username))
            {
                throw new InvalidOperationException($"User with username {username} doesn't exists!");
            }

            return this.people.Find(p => p.UserName == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException($"This {id} is negative!");
            }

            if (this.people.All(un => un.Id != id))
            {
                throw new InvalidOperationException($"User with id {id} doesn't exists!");
            }

            return this.people.Find(p => p.Id == id);
        }
    }
}