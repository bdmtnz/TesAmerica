using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Application.Base;
using TesAmerica.Domain;

namespace TesAmerica.Application.ProductHandler.Get
{
    public class ProductGetRequest : IRequest<ApiResponse<IEnumerable<Product>>>
    {

    }
}
