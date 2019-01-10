using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private double weight;
        private int foodEaten;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
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
            return "Meow";
        }

        public override void FeedTheAnimal(string foodType, int quantity)
        {
            if (foodType == "Meat" || foodType == "Vegetable")
            {
                this.FoodEaten += quantity;
                this.Weight += quantity * 0.30;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }
        }
    }
}
