using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesAmerica.Application.Base;
using TesAmerica.Application.ProductHandlers.GetByName;
using TesAmerica.Application.ClientHandlers.GetByName;
using TesAmerica.Domain;

namespace TesAmerica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost("GetByName", Name = "GetClientsByName")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetClientsByName(ClientGetByNameRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}
