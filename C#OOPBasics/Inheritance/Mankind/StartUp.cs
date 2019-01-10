using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            var inputStudent = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
            var firstNameS = inputStudent[0];
            var lastNameS = inputStudent[1];
            var facultyNum = inputStudent[2];

            Student student = new Student(firstNameS, lastNameS, facultyNum);

            var inputWorker = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
            var firstNameW = inputWorker[0];
            var lastNameW = inputWorker[1];
            var weekSalary = double.Parse(inputWorker[2]);
            var hoursPerDay = double.Parse(inputWorker[3]);

            Worker worker = new Worker(firstNameW, lastNameW, weekSalary, hoursPerDay);

            Console.WriteLine(student.ToString());
            Console.WriteLine(worker.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}