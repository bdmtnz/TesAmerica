using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class SellerReport
    {
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public double Subtotal { get; set; }
        public double Comission { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }

    public class Seller : IEntity
    {
        /// <summary>
        /// CODVEND is db column for this field
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// NAME is db column for this field
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// STATE is db column for this field
        /// </summary>
        public string State { get; set; }
    }
}
