using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class Department : IEntity
    {
        /// <summary>
        /// CODDEP is db column for this field
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// NOMBRE is db column for this field
        /// </summary>
        public string Name { get; set; }
    }
}
