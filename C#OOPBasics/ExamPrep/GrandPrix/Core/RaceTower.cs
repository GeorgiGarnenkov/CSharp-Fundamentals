using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private Track track;

    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;


    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
    }

    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;   

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];

            int horsePower = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();

            Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);

            Car car = new Car(horsePower, fuelAmount, tyre);

            Driver driver = this.driverFactory.CreateDriver(driverType, driverName, car);

            this.racingDrivers.Add(driver);

        }
        catch { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = this.racingDrivers.
            FirstOrDefault(a => a.Name == driverName);

        string[] methodArgs = commandArgs.Skip(2).ToArray();

        if (boxReason == "Refuel")
        {
            driver.Refuel(methodArgs);

        }
        else if (boxReason == "ChangeTyres")
        {
            Tyre tyre = this.tyreFactory.CreateTyre(methodArgs);

            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.track.CurrentLap));
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            for (var index = 0; index < this.racingDrivers.Count; index++)
            {
                Driver driver = this.racingDrivers[index];

                try
                {
                    driver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException e)
                {
                    driver.Fail(e.Message);
                    this.failedDrivers.Push(driver);
                    this.racingDrivers.RemoveAt(index);
                    index--;
                }
            }
            this.track.CurrentLap++;


            List<Driver> orderedDrivers = this.racingDrivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int j = 0; j < orderedDrivers.Count - 1; j++)
            {
                Driver overtakingDriver = orderedDrivers[j];
                Driver targetDriver = orderedDrivers[j + 1];

                bool overtakeHappened = this.TryOverTake(overtakingDriver, targetDriver);

                if (overtakeHappened)
                {
                    j++;
                    builder.AppendLine(string.Format
                        (OutputMessages.OvertakeMessage, overtakingDriver.Name, targetDriver.Name, this.track.CurrentLap));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (this.IsRaceOver)
        {
            Driver winner = this.racingDrivers.OrderBy(a => a.TotalTime).First();

            builder.AppendLine(String.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
        }

        return builder.ToString().TrimEnd();

    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
                                overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranceDriver = overtakingDriver is EnduranceDriver &&
                               overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.track.Weather == Weather.Foggy) ||
                     (enduranceDriver && this.track.Weather == Weather.Rainy);

        if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(OutputMessages.Crash);
                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderboardDrivers = this.racingDrivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int position = 1;
        foreach (Driver driver in leaderboardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string result = builder.ToString().TrimEnd();

        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];

        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);

        if (!validWeather)
        {
            throw new ArgumentException(OutputMessages.InvalidWeatherType);
        }

        Weather weather = (Weather)weatherObj;
        this.track.Weather = weather;
    }

}