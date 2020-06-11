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
        /// <summary>
        ///     Schedule hours for the current day
        /// </summary>
        public string Hours { get; set; }

        /// <summary>
        ///     Status of the place. Could be open, close, opening soon and closing soon
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Value to inform that the tapa should be closed if it's not opening today
        /// </summary>
        public bool Disable => Status == BusinessHoursConstants.ClosedToday;
    }
}