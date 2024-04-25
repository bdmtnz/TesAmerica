using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Application.ClientHandlers.GetByName
{
    public class ClientGetByNameQuery : IRequestHandler<ClientGetByNameRequest, ApiResponse<IEnumerable<Client>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientGetByNameQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<IEnumerable<Client>>> Handle(ClientGetByNameRequest request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetClientRepository();
            _unitOfWork.Open();
            var response = new ApiResponse<IEnumerable<Client>>(
                "Consultado con exito",
                productRepo.FindByForeignKey(request.Name)
            );
            _unitOfWork.Close();
            return Task.FromResult(response);
        }
    }
}
