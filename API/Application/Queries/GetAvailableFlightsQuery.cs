using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public class GetAvailableFlightsQuery : IRequest<IEnumerable<Flight>>
    {
        public string DestinationAirportId { get; private set; }

        public GetAvailableFlightsQuery(string destinationAirportId)
        {
            DestinationAirportId = destinationAirportId;
        }

    }
}