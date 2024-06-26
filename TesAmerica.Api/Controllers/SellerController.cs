using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesAmerica.Application.Base;
using TesAmerica.Application.ProductHandlers.GetByName;
using TesAmerica.Application.SellerHandlers.GetByName;
using TesAmerica.Application.SellerHandlers.Report;
using TesAmerica.Domain;

namespace TesAmerica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SellerController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost("Report", Name = "GetCommisionsByMonth")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Seller>>>> GetCommisionsByMonth(SellerReportRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }


        [HttpPost("GetByName", Name = "GetSellersByName")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetSellersByName(SellerGetByNameRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}
