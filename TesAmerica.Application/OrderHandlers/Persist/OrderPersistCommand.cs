using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.OrderHandlers.Persist
{
    public class OrderPersistCommand : IRequestHandler<OrderPersistRequest, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderPersistCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse> Handle(OrderPersistRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
