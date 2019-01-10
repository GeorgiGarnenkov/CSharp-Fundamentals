using System;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public double Weight { get; }
    }
}