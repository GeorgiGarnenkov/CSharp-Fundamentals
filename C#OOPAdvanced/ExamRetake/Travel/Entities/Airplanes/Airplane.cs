using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Entities.Contracts;

	// migrated from java. please do the needful kind sir


    public abstract class Airplane : IAirplane
    {
        private readonly List<IPassenger> passengers;
        private readonly List<IBag> baggageCompartment;
        

        public Airplane(int seats, int baggageCompartment)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartment;
            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;





        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }
        public IPassenger RemovePassenger(int seatIndex)
        {
            // mdrchd
            IPassenger passenger = this.passengers[seatIndex];

            this.passengers.RemoveAt(seatIndex);

            return passenger;
        }
        
        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IBag[] passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            List<IBag> removedBags = new List<IBag>();

            foreach (var bag in passengerBags)
            {
                removedBags.Add(bag);
                this.baggageCompartment.Remove(bag);
            }

            return removedBags;
        }
        
        public void LoadBag(IBag bag)
        {
            bool isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;

            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
        
            this.baggageCompartment.Add(bag);
        }
    }
}