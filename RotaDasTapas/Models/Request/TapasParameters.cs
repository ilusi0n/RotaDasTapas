using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class TapasParameters
    {
        [Required] public string Localtime { get; set; }
    }
}