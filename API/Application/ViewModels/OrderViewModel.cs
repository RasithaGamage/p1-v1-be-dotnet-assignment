using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; private set; }
        public bool IsDraft { get; private set; }
        public Guid FlightRateId { get; private set; }

    }
}