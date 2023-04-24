using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap <Flight, FlightViewModel>()
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.OriginAirportId))
                .ForMember(dest => dest.ArrivalAirportCode, opt => opt.MapFrom(src => src.DestinationAirportId))
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => src.Rates)); 
        }
    }
}