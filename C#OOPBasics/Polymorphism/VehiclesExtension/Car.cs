using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapaciry)
            : base(fuelQuantity, fuelConsumption, tankCapaciry)
        {
        }

        public override double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                this.fuelQuantity = value;
            }
        }

        public override double FuelConsumption
        {
            get => this.fuelConsumption;
            set
            {
                this.fuelConsumption = value + 0.9;
            }
        }

        public override double TankCapacity
        {
            get => this.tankCapacity;
            set
            {
                this.tankCapacity = value;
                if (value < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }
            }
        }

        public override void Drive(double distance)
        {
            var litersForDistance = distance * this.FuelConsumption;
            if (litersForDistance > this.FuelQuantity)
            {
                throw new ArgumentException("Car needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Car travelled {distance} km");
            }
        }

        public override void Refuel(double refuelAmount)
        {
            if (refuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.TankCapacity < refuelAmount)
            {
                throw new ArgumentException($"Cannot fit {refuelAmount} fuel in the tank");
            }
            this.FuelQuantity += refuelAmount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
