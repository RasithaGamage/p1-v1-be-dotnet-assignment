using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.ApiResponses;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;

namespace API.Application.Queries
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IFlightSearchRepository _flightRepository;

        public GetAvailableFlightsQueryHandler(IFlightSearchRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.SerchByDestination(request.DestinationAirportId);
            return (IEnumerable<Flight>)flights;
        }
    }
}