using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Infrastructure.Repositores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightSearchRepository _flightRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IFlightSearchRepository flightRepository)
        {
            _orderRepository = orderRepository;
            _flightRepository = flightRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var flight = await _flightRepository.GetFlightByRateId(request.FligthRateId);

            if (flight == null) throw new ArgumentNullException("Flight not found");
           
            var flightRate = flight.Rates.FirstOrDefault(i => i.Id.ToString() == request.FligthRateId);

            var order = new Order(new Guid(request.CustomerId), flightRate.Id, request.IsDraft);

            _orderRepository.Add(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            await _flightRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return order;
        }
    }
}