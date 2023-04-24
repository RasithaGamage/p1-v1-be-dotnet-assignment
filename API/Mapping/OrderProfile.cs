using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}