using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle : IDrive, IRefuel, IDriveEmpty
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

        public virtual double TankCapacity
        {
            get => this.tankCapacity;
            set => this.tankCapacity = value;
        }


        public virtual void Drive(double distance)
        {
            
        }

        public virtual void Refuel(double refuelAmount)
        {
            
        }


        public virtual void DriveEmpty(double distance)
        {

        }
    }
}
