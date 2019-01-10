using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite;

public class StartUp
{
    public static void Main()
    {
        var soldiers = new List<ISoldier>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();

            var soldierType = commandArgs[0];
            int id = int.Parse(commandArgs[1]);
            string firstName = commandArgs[2];
            string lastName = commandArgs[3];
            decimal salary = decimal.Parse(commandArgs[4]);

            ISoldier soldier = null;

            try
            {
                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LeutenantGeneral":
                        var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < commandArgs.Length; i++)
                        {
                            var privateId = int.Parse(commandArgs[i]);
                            ISoldier @private = soldiers.First(p => p.Id == privateId);
                            leutenant.AddPrivate(@private);
                        }
                        soldier = leutenant;
                        break;
                    case "Engineer":
                        string engineerCorps = commandArgs[5];
                        var engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                        for (int i = 6; i < commandArgs.Length; i++)
                        {
                            string partName = commandArgs[i];
                            var hoursWorked = int.Parse(commandArgs[++i]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddReapir(repair);
                        }
                        soldier = engineer;
                        break;
                    case "Commando":
                        string commandoCorps = commandArgs[5];
                        var commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                        for (int i = 6; i < commandArgs.Length; i++)
                        {
                            string codeName = commandArgs[i];
                            string missionState = commandArgs[++i];
                            try
                            {
                                IMission mission = new Mission(codeName, missionState);
                                commando.AddMission(mission);
                            }
                            catch{}
                        }

                        soldier = commando;
                        break;
                    case "Spy":
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    default:
                        throw new ArgumentException("Invalid soldier type!");
                }

                soldiers.Add(soldier);
            }
            catch{}
        }
        foreach (var s in soldiers)
        {
            Console.WriteLine(s);
        }
    }
}