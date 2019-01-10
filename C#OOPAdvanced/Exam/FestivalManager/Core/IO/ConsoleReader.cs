using System;
using FestivalManager.Core.IO.Contracts;

// we might want to read from files idk lol ¯\_(ツ)_/¯
namespace FestivalManager.Core.IO
{
	public class ConsoleReader : IReader
	{
	    public string ReadLine()
	    {
	        return Console.ReadLine();
	    }
	}
}