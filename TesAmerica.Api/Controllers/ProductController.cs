using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesAmerica.Application.Base;
using TesAmerica.Application.ProductHandler.Get;
using TesAmerica.Application.ProductHandlers.GetByName;
using TesAmerica.Domain;

namespace TesAmerica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> Get()
        {
            var handled = await _mediator.Send(new ProductGetRequest());
            return Ok(handled);
        }

        [HttpPost(Name = "GetProductsByName")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProductsByName(ProductGetByNameRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}
