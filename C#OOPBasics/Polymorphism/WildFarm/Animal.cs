namespace WildFarm
{
    public abstract class Animal : IProduceSound, IFeed
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public virtual double Weight
        {
            get => weight;
            set => weight = value;
        }

        public virtual int FoodEaten
        {
            get => foodEaten;
            set => foodEaten = value;
        }

        public virtual string MakeSound()
        {
            return "";
        }

        public virtual void FeedTheAnimal(string foodType, int quantity)
        {
        }
    }
}
