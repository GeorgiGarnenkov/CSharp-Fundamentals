using System;

public class StartUp
{
    public static void Main()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        Engine engine = new Engine(raceTower);
        engine.Run();
    }
}