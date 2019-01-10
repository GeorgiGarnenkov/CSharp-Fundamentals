using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var numberOfSongs = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();
        for (int i = 0; i < numberOfSongs; i++)
        {
            try
            {
                var inputSong = Console.ReadLine().Split(';');

                var artistName = inputSong[0];
                var songName = inputSong[1];
                var songLength = inputSong[2];

                var minAndSec = songLength.Split(':');
                int min;
                int sec;
                if (int.TryParse(minAndSec[0], out min) && int.TryParse(minAndSec[1], out sec))
                {
                    Song song = new Song(artistName, songName, min, sec);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Console.WriteLine($"Songs added: {songs.Count}");

        int lengthInSec = songs.Sum(s => s.SongLength);
        TimeSpan time = TimeSpan.FromSeconds(lengthInSec);
        string str = time.ToString(@"hh\:mm\:ss");
        Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
    }
}