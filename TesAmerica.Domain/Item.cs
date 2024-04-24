using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class Item : IEntity
    {
        /// <summary>
        /// NUMPEDIDO is db column for this field
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// PRODUCTO is db column for this field
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// PRECIO is db column for this field
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// CANTIDAD is db column for this field
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// SUBTOTAL is db column for this field
        /// </summary>
        public double Subtotal { get; set; }
    }
}
