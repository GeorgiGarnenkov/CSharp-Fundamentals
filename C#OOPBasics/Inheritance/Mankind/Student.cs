using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;
    private readonly Regex regex = new Regex("^[A-Za-z0-9]{5,10}$");

    public Student(string firstName, string lastName, string facultyNumber)
    : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    private string FacultyNumber
    {
        get => facultyNumber;
        set
        {
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Faculty number: {this.FacultyNumber}");

        return sb.ToString();
    }
}