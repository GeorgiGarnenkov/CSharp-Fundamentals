using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog: Mammal
    {
        private double weight;
        private int foodEaten;

        public Dog(string name, double weight,  string livingRegion) 
            : base(name, weight,  livingRegion)
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
            return "Woof!";
        }

        public override void FeedTheAnimal(string foodType, int quantity)
        {
            if (foodType == "Meat")
            {
                this.FoodEaten += quantity;
                this.Weight += quantity * 0.40;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
