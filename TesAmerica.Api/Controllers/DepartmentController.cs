using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesAmerica.Application.Base;
using TesAmerica.Application.DepartmentHandlers.Report;
using TesAmerica.Domain;

namespace TesAmerica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost(Name = "GetSoldsByDepartments")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Department>>>> GetSoldsByDepartments(DepartmentReportRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}
