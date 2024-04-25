using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;

namespace TesAmerica.Application.OrderHandlers.Get
{
    public class OrderGetRequest : IRequest<ApiResponse<IEnumerable<Order>>>
    {
    }
}
