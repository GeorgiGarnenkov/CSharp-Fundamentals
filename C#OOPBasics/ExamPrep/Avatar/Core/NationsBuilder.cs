using System;
using System.Collections.Generic;
using System.Text;

public class NationsBuilder
{
    private long warCount = 1;
    private FireNation fireNation;
    private WaterNation waterNation;
    private AirNation airNation;
    private EarthNation earthNation;

    public NationsBuilder()
    {
        this.fireNation = new FireNation();
        this.waterNation = new WaterNation();
        this.airNation = new AirNation();
        this.earthNation = new EarthNation();
    }

    private StringBuilder warStringBuilder = new StringBuilder();

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = long.Parse(benderArgs[2]);
        var secondaryParameter = decimal.Parse(benderArgs[3]);

        CreateBender(type, name, power, secondaryParameter);
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];

        var affinity = long.Parse(monumentArgs[2]);

        CreateMonument(type, name, affinity);
    }
    public string GetStatus(string nationsType)
    {
        return StatusCommand(nationsType);
    }
    public void IssueWar(string nationsType)
    {
        WarCommand(nationsType);
    }
    public string GetWarsRecord()
    {
        return warStringBuilder.ToString().TrimEnd();
    }

    private void CreateBender(string type, string name, long power, decimal secondaryParameter)
    {

        switch (type)
        {
            case "Fire":
                FireBender fireBender = new FireBender(name, power, secondaryParameter);
                this.fireNation.FireBenders.Add(fireBender);
                break;
            case "Water":
                WaterBender waterBender = new WaterBender(name, power, secondaryParameter);
                this.waterNation.WaterBenders.Add(waterBender);
                break;
            case "Air":
                AirBender airBender = new AirBender(name, power, secondaryParameter);
                this.airNation.AirBenders.Add(airBender);
                break;
            case "Earth":
                EarthBender earthBender = new EarthBender(name, power, secondaryParameter);
                this.earthNation.EarthBenders.Add(earthBender);
                break;
        }
    }

    private void CreateMonument(string type, string name, long affinity)
    {
        switch (type)
        {
            case "Fire":
                FireMonument fireMonument = new FireMonument(name, affinity);
                this.fireNation.FireMonuments.Add(fireMonument);
                break;
            case "Water":
                WaterMonument waterMonument = new WaterMonument(name, affinity);
                this.waterNation.WaterMonuments.Add(waterMonument);
                break;
            case "Air":
                AirMonument airMonument = new AirMonument(name, affinity);
                this.airNation.AirMonuments.Add(airMonument);
                break;
            case "Earth":
                EarthMonument earthMonument = new EarthMonument(name, affinity);
                this.earthNation.EarthMonuments.Add(earthMonument);
                break;
        }
    }

    private string StatusCommand(string nation)
    {
        switch (nation)
        {
            case "Fire":
                return this.fireNation.ToString();
                break;
            case "Water":
                return this.waterNation.ToString();
                break;
            case "Air":
                return this.airNation.ToString();
                break;
            case "Earth":
                return this.earthNation.ToString();
                break;
            default:
                return "Invalid nation";
                break;
        }
    }

    private void WarCommand(string nation)
    {
        warStringBuilder.AppendLine($"War {warCount} issued by {nation}");
        switch (nation)
        {
            case "Fire":
                WarWinner();
                break;
            case "Water":
                WarWinner();
                break;
            case "Air":
                WarWinner();
                break;
            case "Earth":
                WarWinner();
                break;
        }
    }

    private void WarWinner()
    {
        var fireNationTotalPower = this.fireNation.Check();
        var waterNationTotalPower = this.waterNation.Check();
        var airNationTotalPower = this.airNation.Check();
        var earthNationTotalPower = this.earthNation.Check();

        List<decimal> allNationsPowers = new List<decimal>();
        if (fireNationTotalPower != 0)
        {
            allNationsPowers.Add(fireNationTotalPower);
        }
        if (waterNationTotalPower != 0)
        {
            allNationsPowers.Add(waterNationTotalPower);
        }
        if (airNationTotalPower != 0)
        {
            allNationsPowers.Add(airNationTotalPower);
        }
        if (earthNationTotalPower != 0)
        {
            allNationsPowers.Add(earthNationTotalPower);
        }

        if (allNationsPowers.Count == 1)
        {
            if (fireNationTotalPower == allNationsPowers[0])
            {
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
            }
            else if (waterNationTotalPower == allNationsPowers[0])
            {
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
            }
            else if (airNationTotalPower == allNationsPowers[0])
            {
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();

            }
            else if (earthNationTotalPower == allNationsPowers[0])
            {
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
            }

            warCount++;
        }
        else if (allNationsPowers.Count > 1)
        {
            for (int i = 0; i < allNationsPowers.Count - 1; i++)
            {
                if (allNationsPowers[i] > allNationsPowers[i + 1])
                {
                    allNationsPowers.RemoveAt(i + 1);
                }
                else
                {
                    allNationsPowers.RemoveAt(i);
                }
            }


            if (fireNationTotalPower == allNationsPowers[0] && fireNation != null)
            {
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
            }
            else if (waterNationTotalPower == allNationsPowers[0] && waterNation != null)
            {
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
            }
            else if (airNationTotalPower == allNationsPowers[0] && airNation != null)
            {
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
            }
            else if (earthNationTotalPower == allNationsPowers[0] && earthNation != null)
            {
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
            }
            warCount++;
        }
    }
}