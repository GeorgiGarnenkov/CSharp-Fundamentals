﻿using System;
using System.Runtime.CompilerServices;

public class Human
{
    private string firstName;
    private string lastName;

    protected Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    protected virtual string FirstName
    {
        get => firstName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length <= 3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            this.firstName = value;
        }
    }

    protected virtual string LastName
    {
        get => lastName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length <= 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            this.lastName = value;
        }
    }
}