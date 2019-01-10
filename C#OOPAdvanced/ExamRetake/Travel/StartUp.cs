using Travel.Core;
using Travel.Core.Controllers;

namespace Travel
{
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;

	// god loves ugly
	public static class StartUp
	{
		public static void Main()
		{
			IReader reader = new ConsoleReader();

			IWriter writer = new ConsoleWriter();

			var airport = new Airport();
			var airportController = new AirportController(airport);
			var flightController = new FlightController(airport);

			var engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}