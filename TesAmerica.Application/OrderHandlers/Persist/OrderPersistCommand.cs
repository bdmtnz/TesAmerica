using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;
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

        public async Task<ApiResponse> Handle(OrderPersistRequest request, CancellationToken cancellationToken)
        {
            ApiResponse response = null;
            _unitOfWork.Open();
            _unitOfWork.BeginTransaction();
            var orderRepo = _unitOfWork.GetOrderRepository();
            try
            {
                if (request == null)
                {
                    throw new Exception("Petición invalida");
                }
                var order = request.Order;
                if (order == null)
                {
                    throw new Exception("Pedido invalido");
                }
                order.Id = Guid.NewGuid().ToString().Substring(0, 10);
                orderRepo.Add(order);

                var itemRepo = _unitOfWork.GetItemRepository();
                var items = request.Items;

                if (items == null)
                {
                    throw new Exception("Items invalidos");
                }
                else if (items.Count <= 0)
                {
                    throw new Exception("La cantidad de items debe ser mayor a cero");
                }

                for (var i = 0; i < items.Count; i++)
                {
                    var item = items.ElementAt(i);
                    item.OrderId = order.Id;
                    itemRepo.Add(item);
                }
                await _unitOfWork.CommitAsync();
                response = new ApiResponse(
                    "Proceso realizado con exito",
                    default
                );
            }
            catch(Exception ex) {
                await _unitOfWork.RollbackAsync();
                response = new ApiResponse(
                    $"Ha ocurrido un error: {ex.Message}"
                );
            }
            _unitOfWork.Close();
            return response;
        }
    }
}
