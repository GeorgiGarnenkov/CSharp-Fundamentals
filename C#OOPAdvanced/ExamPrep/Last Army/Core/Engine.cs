using System;
using System.Text;

public class Engine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var input = reader.ReadLine();
        var gameController = new GameController(writer);
        
        while (!input.Equals(OutputMessages.InputTerminateString))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.StoreMessage(arg.Message);
            }
            input = reader.ReadLine();
        }

        gameController.RequestResult();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}