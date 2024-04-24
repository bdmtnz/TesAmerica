using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;

namespace TesAmerica.Application.DepartmentHandlers.Report
{
    public class DepartmentReportRequest : IRequest<ApiResponse<IEnumerable<DepartmentReport>>>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
