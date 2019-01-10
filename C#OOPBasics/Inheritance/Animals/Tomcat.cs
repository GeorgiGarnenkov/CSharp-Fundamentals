using System.Reflection.Metadata.Ecma335;

public class Tomcat : Cat
{
    private string gender = "Male";

    public Tomcat(string name, int age, string gender)
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
        return "MEOW";
    }
}