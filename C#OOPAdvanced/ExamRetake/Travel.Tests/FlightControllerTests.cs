// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING


using NUnit.Framework;
using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;
using Travel.Entities.Items;
using Travel.Entities.Items.Contracts;

namespace Travel.Tests
{
    [TestFixture]
    public class FlightControllerTests
    {
        private const int EjectionSeed = 1337;

        [Test]
        public void Test1()
        {
            IPassenger passenger1 = new Passenger("Pesho");
            
            IBag bag1 = new Bag(passenger1, new IItem[] { new Toothbrush(), new Jewelery()});
            IBag bag2 = new Bag(passenger1, new IItem[] { new CellPhone(), new Laptop() });

            IAirplane airplane = new LightAirplane();
            
            ITrip trip = new Trip("Sofia", "London", airplane);
            
            trip.Airplane.AddPassenger(passenger1);

            trip.Airplane.LoadBag(bag1);
            trip.Airplane.LoadBag(bag2);

            IAirport airport = new Airport();
            airport.AddTrip(trip);
            airport.AddPassenger(passenger1);
            airport.AddCheckedBag(bag1);
            

            FlightController flightController = new FlightController(airport);


            string result = flightController.TakeOff();

            string expectedResult = "SofiaLondon1:\r\n" +
                "Successfully transported 1 passengers from Sofia to London.\r\n" +
                "Confiscated bags: 0 (0 items) => $0";

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
