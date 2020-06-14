using System.ComponentModel.DataAnnotations;

namespace RotaDasTapas.Models.Request
{
    public class JourneyParameters : TapasParameters
    {
        /// <summary>
        ///     City where the journey will take place
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        ///     List of the selected tapas choosed by the user.
        ///     Should be at the minimum 3.
        /// </summary>
        [Required]
        public string ListSelectedTapas { get; set; }
    }
}