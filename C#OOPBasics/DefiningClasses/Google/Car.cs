public class Car
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public string Model { get => model; set => model = value; }
    public int Speed { get => speed; set => speed = value; }
}
