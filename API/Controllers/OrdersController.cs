using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(order));
        }
    }
}