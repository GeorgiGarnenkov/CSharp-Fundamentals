using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
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

    private int Endurance
    {
        get => endurance;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
            }

            this.endurance = value;
        }
    }

    private int Sprint
    {
        get => sprint;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
            }

            this.sprint = value;
        }
    }

    private int Dribble
    {
        get => dribble;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
            }

            this.dribble = value;
        }
    }

    private int Passing
    {
        get => passing;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
            }

            this.passing = value;
        }
    }

    private int Shooting
    {
        get => shooting;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                
            }

            this.shooting = value;
        }
    }

    public int SkillLevel()
    {
        return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.shooting) / 5.0);
    }
}