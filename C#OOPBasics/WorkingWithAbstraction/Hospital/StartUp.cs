using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, List<string>> departmentPeople = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> doctorPeople = new Dictionary<string, List<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Output")
        {
            var commandArgs = input.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var department = commandArgs[0];
            var doctor = commandArgs[1] + " " + commandArgs[2];
            var patient = commandArgs[3];

            if (!departmentPeople.ContainsKey(department))
            {
                departmentPeople.Add(department, new List<string>());

            }
            departmentPeople[department].Add(patient);

            if (!doctorPeople.ContainsKey(doctor))
            {
                doctorPeople.Add(doctor, new List<string>());
            }
            doctorPeople[doctor].Add(patient);
        }


        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();

            if (commandArgs.Length == 1)
            {
                PrintPeopleFromDepartment(departmentPeople, input);
            }
            else
            {
                int room = 0;

                if (int.TryParse(commandArgs[1], out room))
                {
                    PrintPeopleFromRoomInDepartment(departmentPeople, commandArgs, room);
                }
                else
                {
                    PrintDoctorPatients(doctorPeople, input);
                }
            }
        }
    }

    private static void PrintDoctorPatients(Dictionary<string, List<string>> doctorPeople, string input)
    {
        var doctor = input.TrimEnd();

        foreach (var p in doctorPeople[doctor].OrderBy(a => a))
        {
            Console.WriteLine(p);
        }
    }

    private static void PrintPeopleFromRoomInDepartment(Dictionary<string, List<string>> departmentPeople, string[] commandArgs, int room)
    {
        var department = commandArgs[0];

        foreach (var p in departmentPeople[department].Skip((room - 1) * 3).Take(3).OrderBy(a => a))
        {
            Console.WriteLine(p);
        }
    }

    private static void PrintPeopleFromDepartment(Dictionary<string, List<string>> departmentPeople, string input)
    {
        foreach (var p in departmentPeople[input])
        {
            Console.WriteLine(p);
        }
    }
}