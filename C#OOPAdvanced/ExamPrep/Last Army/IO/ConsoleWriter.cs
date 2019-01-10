using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder stringBuilder;

    public ConsoleWriter()
    {
        this.stringBuilder = new StringBuilder();
    }

    public string StoredMessage => this.stringBuilder.ToString();

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public void StoreMessage(string message)
    {
        this.stringBuilder.AppendLine(message.Trim());
    }
}