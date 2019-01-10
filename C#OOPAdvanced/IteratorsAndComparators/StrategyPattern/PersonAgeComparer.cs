using System.Collections.Generic;

namespace StrategyPattern
{
    public class PersonAgeComparer : IComparer<Person>

    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var result = firstPerson.Age.CompareTo(secondPerson.Age);
            
            return result;
        }
    }
}
