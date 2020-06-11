using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class TapasParameters
    {
        /// <summary>
        ///     Current datetime of the client used for schedule algorithm
        /// </summary>
        [Required]
        public string Localtime { get; set; }
    }
}