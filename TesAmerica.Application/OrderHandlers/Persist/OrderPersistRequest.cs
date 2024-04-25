using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;

namespace TesAmerica.Application.OrderHandlers.Persist
{
    public class OrderPersistRequest : IRequest<ApiResponse>
    {
        public Order Order { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
