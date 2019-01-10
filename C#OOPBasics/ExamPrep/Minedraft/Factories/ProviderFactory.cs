using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
                break;

            case "Pressure":
                return  new PressureProvider(id, energyOutput);
                break;

            default:
                throw new ArgumentException("Cannot create Provider!");
                break;
        }
    }
}