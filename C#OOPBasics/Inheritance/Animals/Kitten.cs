public class Kitten : Cat
{
    private string gender = "Female";

    public Kitten(string name, int age, string gender)
        : base(name, age, gender)
    {
        this.Gender = gender;
    }

    public override string Gender
    {
        get { return this.gender; }
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}