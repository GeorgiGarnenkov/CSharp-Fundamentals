using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private double weight;
        private int foodEaten;

        public Hen(string name, double weight, double wingSize)
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
            return "Cluck";
        }

        public override void FeedTheAnimal(string foodType, int quantity)
        {
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.35;
        }
    }
}
