using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tiers;


    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tiers = tires;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public Engine Engine
    {
        get => engine;
        set => engine = value;
    }

    public Cargo Cargo
    {
        get => cargo;
        set => cargo = value;
    }

    public List<Tire> Tiers
    {
        get => tiers;
        set => tiers = value;
    }
}
