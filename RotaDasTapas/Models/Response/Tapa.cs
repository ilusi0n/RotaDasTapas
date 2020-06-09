using RotaDasTapas.Constants;

namespace RotaDasTapas.Models.Response
{
    public class Tapa
    {
        /// <summary>
        ///     Unique Identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Name of the tapa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Title of the place
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Address of the place
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Description of the tapa
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     City of where Tapa is located
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Imageurl of the tapa
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Current schedule
        /// </summary>
        public Schedule Schedule { get; set; }
    }

    public class Schedule
    {
        public string Hours { get; set; }
        public string Status { get; set; }
        public bool Disable => Status == BusinessHoursConstants.ClosedToday;
    }
}