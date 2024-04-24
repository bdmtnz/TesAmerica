using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;

namespace TesAmerica.Application.SellerHandlers.Report
{
    public class SellerReportRequest : IRequest<ApiResponse<IEnumerable<SellerReport>>>
    {
        public int? Year { get; set; }
        public int Month { get; set; }
    }
}
