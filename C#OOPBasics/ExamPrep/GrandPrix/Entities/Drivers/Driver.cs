using System.Runtime.CompilerServices;

public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0.0;
        this.IsRacing = true;

    }

    public string Name { get; }

    public double TotalTime { get; set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsRacing { get; private set; }
    public string FailureReason { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    public void Refuel(string[] methodArgs)
    {
        this.TotalTime += 20;

        double fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.TotalTime += 20;

        this.Car.ChangeTyres(tyre);
    }
    
    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);

        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void Fail(string eMessage)
    {
        this.IsRacing = false;
        this.FailureReason = eMessage;
    }
}
