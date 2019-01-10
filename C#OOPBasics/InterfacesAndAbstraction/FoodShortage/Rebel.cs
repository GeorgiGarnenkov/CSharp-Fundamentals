public class Rebel : Citizen, IBuyer
{
    private int food = 0;

    public Rebel(string name, string age, string group) 
        : base(name, age, group)
    {
    }

    public override int Food
    {
        get => food;
        set => food = value;
    }

    public override void BuyFood()
    {
        this.Food += 5;
    }
}