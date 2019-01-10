using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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
                this.fuelConsumption = value + 1.6;
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
                throw new ArgumentException("Truck needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Truck travelled {distance} km");
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
            refuelAmount -= (refuelAmount * 0.05);
            this.FuelQuantity += refuelAmount;

        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
