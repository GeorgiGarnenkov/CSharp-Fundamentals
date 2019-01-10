using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IDrive, IRefuel
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }
        

        public virtual void Drive(double distance)
        {
            
        }

        public virtual void Refuel(double refuelAmount)
        {
            
        }
        
    }
}
