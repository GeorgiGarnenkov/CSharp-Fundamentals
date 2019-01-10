using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;

    private List<Harvester> harvesters;
    private List<Provider> providers;

    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(harvesterFactory.Create(arguments));
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        var type = arguments[0];
        var id = arguments[1];

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(providerFactory.Create(arguments));
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        var type = arguments[0];
        var id = arguments[1];

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double totalEnergyNeed = 0;
        double sumOreOutput = 0;

        double sumEnergyOutput = this.providers.Sum(a => a.EnergyOutput);
        this.totalEnergyStored += sumEnergyOutput;

        switch (this.mode)
        {
            case "Full":

                totalEnergyNeed = this.harvesters.Sum(a => a.EnergyRequirement);
                if (this.totalEnergyStored >= totalEnergyNeed)
                {
                    sumOreOutput = this.harvesters.Sum(h => h.OreOutput);
                    this.totalMinedOre += sumOreOutput;
                    this.totalEnergyStored -= totalEnergyNeed;
                }
                break;

            case "Half":

                totalEnergyNeed = this.harvesters.Sum(h => h.EnergyRequirement) * 0.60;
                if (this.totalEnergyStored >= totalEnergyNeed)
                {
                    sumOreOutput = this.harvesters.Sum(h => h.OreOutput) * 0.50;
                    this.totalMinedOre += sumOreOutput;
                    this.totalEnergyStored -= totalEnergyNeed;
                }
                break;

            case "Energy":
                break;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {sumEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {sumOreOutput}");

        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        var type = arguments[0];

        this.mode = type;

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (harvesters.Any(a => a.Id == id))
        {
            return this.harvesters.First(a => a.Id == id).ToString();
        }

        if (providers.Any(a => a.Id == id))
        {
            return this.providers.First(a => a.Id == id).ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }

}