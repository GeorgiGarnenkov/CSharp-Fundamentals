using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    private string name;
    private List<Player> players;

    public FootballTeam(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }
    

    public string Name
    {
        get => name;
       private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private List<Player> Players
    {
        get => players;
        set => players = value;
    }

    public int Rating()
    {
        if (this.Players.Count == 0)
        {
            return 0;
        }
        return (int)Math.Round(this.Players.Average(a => a.SkillLevel()));
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (Players.All(a => a.Name != playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        var player = this.Players.First(a => a.Name == playerName);
        this.Players.Remove(player);
    }
}