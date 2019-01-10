using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird, IFeed
    {
        private double weight;
        private int foodEaten;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public override int FoodEaten
        {
            get => this.foodEaten;
            set => this.foodEaten = value;
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }

        public override void FeedTheAnimal(string foodType, int quantity)
        {
            if (foodType == "Meat")
            {
                this.FoodEaten += quantity;
                this.Weight += quantity * 0.25;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }
        }
    }
}
