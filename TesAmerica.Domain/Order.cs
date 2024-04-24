using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class Order : IEntity
    {
        /// <summary>
        /// NUMPEDIDO is db column for this field
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// CLIENTE is db column for this field
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// FECHA is db column for this field
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// VENDEDOR is db column for this field
        /// </summary>
        public string SellerId { get; set; }
    }
}
