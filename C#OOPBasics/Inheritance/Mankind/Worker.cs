using System;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;
    private double salaryPerHour;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
    :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private double WeekSalary
    {
        get => weekSalary;
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    private double WorkHoursPerDay
    {
        get => workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }

    private double SalaryPerHour
    {
        get
        {
            return (weekSalary / 5) / workHoursPerDay; 
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.weekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        return sb.ToString().TrimEnd();
    }
}