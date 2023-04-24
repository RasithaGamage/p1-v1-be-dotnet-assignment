using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string CustomerId { get; private set; }
        public string FligthRateId { get; private set; }
        public bool IsDraft { get; private set; }

        public CreateOrderCommand(string customerId, string fligthRateId, bool isDraft)
        {
            CustomerId = customerId;
            FligthRateId = fligthRateId;
            IsDraft = isDraft;
        }
    }
}