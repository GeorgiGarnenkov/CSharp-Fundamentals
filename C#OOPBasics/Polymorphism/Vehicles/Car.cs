using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;


        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }


        public override double FuelConsumption
        {
            get => this.fuelConsumption;
            set
            {
                this.fuelConsumption = value + 0.9;
            }
        }

        public override void Drive(double distance)
        {
            var litersForDistance = distance * this.FuelConsumption;
            if (litersForDistance > this.FuelQuantity)
            {
                throw new ArgumentException($"Car needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Car travelled {distance} km");
            }
        }

        public override void Refuel(double refuelAmount)
        {
            this.FuelQuantity += refuelAmount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
