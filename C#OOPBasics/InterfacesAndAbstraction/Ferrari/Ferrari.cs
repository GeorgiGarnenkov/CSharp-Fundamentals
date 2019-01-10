public class Ferrari : ICar, IGas, IBrake
{
    public Ferrari(string driver)
    {
        this.Driver = driver;
    }
    public string Model
    {
        get => "488-Spider";
    }

    public string Driver { get; set; }


    public string PedalToTheMetal()
    {
        return "Zadu6avam sA!";
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{Brake()}/{PedalToTheMetal()}/{Driver}";
    }
}