using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasRequest
    {
        [Required]
        public string Name { get; set; }
    }
}