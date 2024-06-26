using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesAmerica.Application.Base;
using TesAmerica.Application.OrderHandlers.Get;
using TesAmerica.Application.OrderHandlers.Persist;
using TesAmerica.Domain;

namespace TesAmerica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpGet(Name = "Get")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Order>>>> Get()
        {
            var handled = await _mediator.Send(new OrderGetRequest());
            return Ok(handled);
        }

        [HttpPost(Name = "Post")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Order>>>> Post(OrderPersistRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}
