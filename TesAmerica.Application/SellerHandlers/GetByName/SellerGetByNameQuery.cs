using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.SellerHandlers.GetByName
{
    public class SellerGetByNameQuery : IRequestHandler<SellerGetByNameRequest, ApiResponse<IEnumerable<Seller>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerGetByNameQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<Seller>>> Handle(SellerGetByNameRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetSellerRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<Seller>>(
                "Consultado con exito",
                productRepo.FindByForeignKey(request.Name)
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
