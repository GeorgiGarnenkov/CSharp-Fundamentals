using System;

namespace VehiclesExtension
{
    public class Bus : Vehicle, IDriveEmpty
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;


        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            set => this.fuelConsumption = value;
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
            
            var litersForDistance = distance * (this.FuelConsumption + 1.4);
            if (litersForDistance > this.FuelQuantity)
            {
                throw new ArgumentException("Bus needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Bus travelled {distance} km");
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
            return $"Bus: {this.FuelQuantity:f2}";
        }

        public override void DriveEmpty(double distance)
        {
            var litersForDistance = distance * this.FuelConsumption;
            if (litersForDistance > this.FuelQuantity)
            {
                throw new ArgumentException("Bus needs refueling");
            }
            else
            {
                this.FuelQuantity -= litersForDistance;
                throw new ArgumentException($"Bus travelled {distance} km");
            }
        }
    }
}
