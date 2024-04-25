using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.ProductHandlers.GetByName
{
    public class ProductGetByNameQuery : IRequestHandler<ProductGetByNameRequest, ApiResponse<IEnumerable<Product>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductGetByNameQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<Product>>> Handle(ProductGetByNameRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetProductRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<Product>>(
                "Consultado con exito",
                productRepo.FindByForeignKey(request.Name)
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
