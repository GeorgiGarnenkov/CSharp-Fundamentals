using System;
using System.Collections.Generic;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            var carInput = Console.ReadLine().Split();
            var fuelQuantityC = double.Parse(carInput[1]);
            var fuelConsumptionC = double.Parse(carInput[2]);
            var tankCapacityC = double.Parse(carInput[3]);

            vehicles.Add(new Car(fuelQuantityC, fuelConsumptionC, tankCapacityC));

            var truckInput = Console.ReadLine().Split();
            var fuelQuantityT = double.Parse(truckInput[1]);
            var fuelConsumptionT = double.Parse(truckInput[2]);
            var tankCapacityT = double.Parse(truckInput[3]);

            vehicles.Add(new Truck(fuelQuantityT, fuelConsumptionT, tankCapacityT));


            var busInput = Console.ReadLine().Split();
            var fuelQuantityB = double.Parse(busInput[1]);
            var fuelConsumptionB = double.Parse(busInput[2]);
            var tankCapacityB = double.Parse(busInput[3]);

            vehicles.Add(new Bus(fuelQuantityB, fuelConsumptionB, tankCapacityB));


            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commands = Console.ReadLine().Split();

                var command = commands[0];
                var vehicleType = commands[1];
                var distanceOrFuel = double.Parse(commands[2]);
                try
                {
                    switch (command)
                    {
                        case "Drive":
                            if (vehicleType == "Car")
                            {
                                vehicles[0].Drive(distanceOrFuel);
                            }
                            else if (vehicleType == "Truck")
                            {
                                vehicles[1].Drive(distanceOrFuel);
                            }
                            else if (vehicleType == "Bus")
                            {
                                vehicles[2].Drive(distanceOrFuel);
                            }
                            break;
                        case "Refuel":
                            if (vehicleType == "Car")
                            {
                                vehicles[0].Refuel(distanceOrFuel);
                            }
                            else if (vehicleType == "Truck")
                            {
                                vehicles[1].Refuel(distanceOrFuel);
                            }
                            else if (vehicleType == "Bus")
                            {
                                vehicles[2].Refuel(distanceOrFuel);
                            }
                            break;
                        case "DriveEmpty":
                            vehicles[2].DriveEmpty(distanceOrFuel);
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
