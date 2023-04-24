using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace API.Application.ViewModels
{
    public class FlightViewModel
    {
        public Guid DepartureAirportCode { get; set; }
        public Guid ArrivalAirportCode { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public List<FlightRate> Prices { get; set; }

    }
}