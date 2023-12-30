using Flights.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Flights.Data
{
    public class Entities
    {
         public IList<Passenger> Passengers = new List<Passenger>();

         public List<Flight> Flights = new List<Flight>;
    }
}
