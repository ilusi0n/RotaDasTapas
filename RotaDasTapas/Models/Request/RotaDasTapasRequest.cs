using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasRequest
    {
        /// <summary>
        ///     Name of the tapa
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}