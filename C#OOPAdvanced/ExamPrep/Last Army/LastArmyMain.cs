public class LastArmyMain
{
    public static void Main()
    {
        Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        
        engine.Run();
    }
}