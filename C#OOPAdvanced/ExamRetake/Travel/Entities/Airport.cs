﻿using System.Linq;

namespace Travel.Entities
{
	using System.Collections.Generic;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> confiscatedBags;
		private List<IBag> checkedInBags;
		private List<ITrip> trips;
		private List<IPassenger> passengers;

        public Airport()
        {
            this.confiscatedBags = new List<IBag>();
            this.checkedInBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.passengers = new List<IPassenger>();
        }

	    public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.AsReadOnly();

	    public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();



        public IPassenger GetPassenger(string username)
        {
            return this.Passengers.FirstOrDefault(n => n.Username == username);
        }

	    public ITrip GetTrip(string id)
	    {
	        return this.Trips.FirstOrDefault(i => i.Id == id);
        }

	    public void AddPassenger(IPassenger passenger)
	    {
	        this.passengers.Add(passenger);
	    }

	    public void AddTrip(ITrip trip)
	    {
	        this.trips.Add(trip);
	    }

	    public void AddCheckedBag(IBag bag)
	    {
	        this.checkedInBags.Add(bag);
	    }

	    public void AddConfiscatedBag(IBag bag)
	    {
	       this.confiscatedBags.Add(bag);
	    }
	}
}