using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.SellerHandlers.Report
{
    public class SellerReportQuery : IRequestHandler<SellerReportRequest, ApiResponse<IEnumerable<SellerReport>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerReportQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<SellerReport>>> Handle(SellerReportRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetSellerReportRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<SellerReport>>(
                "Consultado con exito",
                productRepo.GetCommisions(request.Year, request.Month)
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
