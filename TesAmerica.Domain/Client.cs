using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class Client : IEntity
    {
        /// <summary>
        /// CODCLI is db column for this field
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// NOMBRE is db column for this field
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// DIRECTION is db column for this field
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// TELEFONO is db column for this field
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// CUPO is db column for this field
        /// </summary>
        public int Quota { get; set; }
        /// <summary>
        /// FECHACREACION is db column for this field
        /// </summary>
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// CANAL is db column for this field
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// VENDEDOR is db column for this field
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// CIUDAD is db column for this field
        /// </summary>
        public string CityId { get; set; }
        /// <summary>
        /// PADRE is db column for this field
        /// </summary>
        public string DadId { get; set; }
    }
}
