using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasByCityRequest
    {
        /// <summary>
        ///     City location of the tapa
        /// </summary>
        [Required]
        public string City { get; set; }
    }
}