using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasByNameRequest
    {
        /// <summary>
        ///     Name of the tapa
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}