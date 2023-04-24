using System;
using System.Collections.Generic;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public bool IsDraft { get; private set; }
        public Guid FlightRateId { get; private set; }

        protected Order()
        {
        }

        public Order(Guid customerId, Guid flightRateId, bool isDraft ) : this()
        {
            CustomerId = customerId;
            FlightRateId = flightRateId;
            IsDraft = isDraft;
        }

    }
}