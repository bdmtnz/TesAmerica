using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.OrderHandlers.Get
{
    public class OrderGetQuery : IRequestHandler<OrderGetRequest, ApiResponse<IEnumerable<Order>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderGetQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<Order>>> Handle(OrderGetRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetOrderRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<Order>>(
                "Consultado con exito",
                productRepo.GetAll()
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
