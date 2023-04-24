using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositores
{
    public class FlightSearchRepository : IFlightSearchRepository
    {
        private readonly FlightsContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightSearchRepository(FlightsContext context)
        {
            _context = context;
        }

        Flight IFlightRepository.Add(Flight flight)
        {
            throw new NotImplementedException();
        }

        void IFlightRepository.Update(Flight flight)
        {
            throw new NotImplementedException();
        }

        Task<Flight> IFlightRepository.GetAsync(Guid flightId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Flight>> IFlightSearchRepository.SerchByDestination(string destinationId)
        {
            return await _context.Flights.Where(i => i.DestinationAirportId.ToString() == destinationId)
                .Include(e=>e.Rates)
                .ToArrayAsync();

        }

        async Task<Flight> IFlightSearchRepository.GetFlightByRateId(string flightRateId)
        {
            return await _context.Flights.Include(r => r.Rates)
                .Where(f => f.Rates.Any(r => r.Id.ToString() == flightRateId))
                .FirstOrDefaultAsync();

        }
    }
}