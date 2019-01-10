using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        List<Department> departments = new List<Department>();

        for (int i = 0; i < n; i++)
        {
            var commandArgs = Console.ReadLine()
                .Split();

            string depName = commandArgs[3];
            
            if (!departments.Any(d => d.Name == depName))
            {
                Department dep = new Department(depName);
                departments.Add(dep);
            }

            var department = departments.FirstOrDefault(d => d.Name == depName);

            Employee employee = ParseEmployee(commandArgs);

            department.AddEmployee(employee);
        }

        var highestAverageDep = departments.OrderByDescending(d => d.AverageSalary).First();

        Console.WriteLine($"Highest Average Salary: {highestAverageDep.Name}");

        foreach (var em in highestAverageDep.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{em.Name} {em.Salary:f2} {em.Email} {em.Age}");
        }
    }

    static Employee ParseEmployee(string[] commandArgs)
    {
        var name = commandArgs[0];
        var salary = decimal.Parse(commandArgs[1]);
        var position = commandArgs[2];
        var email = "n/a";
        var age = -1;
        if (commandArgs.Length == 6)
        {
            email = commandArgs[4];
            age = int.Parse(commandArgs[5]);
        }
        else if (commandArgs.Length == 5)
        {
            bool isAge = int.TryParse(commandArgs[4], out age);

            if (!isAge)
            {
                email = commandArgs[4];
                age = -1;
            }
        }
        Employee employee = new Employee(name, salary, position, email, age);
        return employee;
    }
}