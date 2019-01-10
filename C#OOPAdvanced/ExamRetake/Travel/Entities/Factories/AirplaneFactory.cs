using System;
using System.Linq;
using System.Reflection;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;

	public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
		    var airplaneType = Assembly.GetCallingAssembly().GetTypes()
		        .Where(t => typeof(IAirplane).IsAssignableFrom(t))
		        .FirstOrDefault(t => t.Name == type);

		    var airplane = (IAirplane)Activator.CreateInstance(airplaneType);

		    return airplane;
            
		}
	}
}