using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
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
