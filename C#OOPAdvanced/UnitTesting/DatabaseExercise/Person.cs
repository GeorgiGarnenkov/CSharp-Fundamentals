﻿using DatabaseExercise.Interfaces;

namespace DatabaseExercise
{
    public class Person : IPerson
    {
        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public long Id { get; private set; }

        public string UserName { get; private set; }
    }
}