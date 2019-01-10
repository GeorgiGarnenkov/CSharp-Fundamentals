using System;

public class Song
{
    private string songArtist;
    private string songName;
    private int songMinutes;
    private int songSeconds;

    public Song(string songArtist, string songName, int songMinutes, int songSeconds)
    {
        this.SongArtist = songArtist;
        this.SongName = songName;
        this.SongMinutes = songMinutes;
        this.SongSeconds = songSeconds;
    }
    public string SongArtist
    {
        get => songArtist;
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.songArtist = value;
        }
    }

    public string SongName
    {
        get => songName;
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidSongNameException();
            }

            this.songName = value;
        }
    }
    
    public int SongMinutes
    {
        get => songMinutes;
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            this.songMinutes = value;
        }
    }

    public int SongSeconds
    {
        get => songSeconds;
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.songSeconds = value;
        }
    }

    public int SongLength
    {
        get
        {
            return CalculateSongLenght();
        }
    }

    private int CalculateSongLenght()
    {
        int result = SongMinutes * 60 + SongSeconds;
        return result;
    }
}