public class Human : Citizen ,IBuyer
{
    private int food = 0;

    public Human(string name, string age, string id, string birthdate) 
        : base(name, age, id, birthdate)
    {
    }

    public override int Food
    {
        get => this.food;
        set => this.food = value;
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}