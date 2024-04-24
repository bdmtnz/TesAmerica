using TesAmerica.Domain.Base;

namespace TesAmerica.Domain
{
    public class Product : IEntity
    {
        /// <summary>
        /// CODPROD is db column for this field
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// NOMBRE is db column for this field
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// FAMILIA is db column for this field
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// PRECIO is db column for this field
        /// </summary>
        public double Price { get; set; }
    }
}
