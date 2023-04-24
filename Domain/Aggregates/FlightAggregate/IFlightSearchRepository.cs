using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightSearchRepository : IFlightRepository
    {
        Task<IEnumerable<Flight>> SerchByDestination(string destinationId);
        Task<Flight> GetFlightByRateId(string flightRateId);
    }
}