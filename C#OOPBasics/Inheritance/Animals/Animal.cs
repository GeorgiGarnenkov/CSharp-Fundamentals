using System;
using System.Text;

public abstract class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }
    public string Name
    {
        get => name;
        set
        {
            if (String.IsNullOrEmpty(value) ||
                String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value < 0 ||
                String.IsNullOrWhiteSpace(value.ToString()) ||
                String.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    public virtual string Gender
    {
        get => gender;
        set
        {
            if (String.IsNullOrEmpty(value) ||
                String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb
            .AppendLine($"{GetType().ToString()}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine($"{this.ProduceSound()}");

        return sb.ToString().TrimEnd();
    }
}