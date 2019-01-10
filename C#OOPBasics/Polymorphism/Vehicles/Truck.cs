using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;


        public Truck(double fuelQuantity, double fuelConsumption) 
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
                this.fuelConsumption = value + 1.6;
            }
        }


        public override void Drive(double distance)
        {
            var litersForDistance = distance * this.FuelConsumption;
            if (litersForDistance > this.FuelQuantity)
            {
                throw new ArgumentException($"Truck needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Truck travelled {distance} km");
            }
        }

        public override void Refuel(double refuelAmount)
        {
            refuelAmount -= (refuelAmount * 0.05);
            this.FuelQuantity += refuelAmount;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
