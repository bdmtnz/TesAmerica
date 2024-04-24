using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.DepartmentHandlers.Report
{
    public class DepartmentReportQuery : IRequestHandler<DepartmentReportRequest, ApiResponse<IEnumerable<DepartmentReport>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentReportQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<DepartmentReport>>> Handle(DepartmentReportRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetDepartmentReportRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<DepartmentReport>>(
                "Consultado con exito",
                productRepo.GetSales(request.Start, request.End)
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
