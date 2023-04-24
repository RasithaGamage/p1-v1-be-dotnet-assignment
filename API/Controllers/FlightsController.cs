using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public FlightsController(
        ILogger<FlightsController> logger,
        IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IEnumerable<FlightResponse>> GetAvailableFlights(string destinationAirportId)
    {
        IEnumerable<Flight> flights = await _mediator.Send(new GetAvailableFlightsQuery(destinationAirportId));

        IEnumerable<FlightResponse> response  = flights?.Select( flight => new FlightResponse(
                flight.OriginAirportId.ToString(),
                flight.DestinationAirportId.ToString(),
                flight.Departure,
                flight.Arrival,
                flight.Rates.MinBy(i=>i.Price.Value).Price.Value
            ) );

        return response;
    }
}
