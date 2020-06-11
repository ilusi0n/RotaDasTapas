namespace RotaDasTapas.Models.Gateway
{
    /// <summary>
    ///     Path class that holds information of the path between the current tapa to the next one (tapaId)
    /// </summary>
    public class Path
    {
        /// <summary>
        ///     Name of the final tapa this tapa belongs too
        /// </summary>
        public string TapaId { get; set; }

        /// <summary>
        ///     Distance from one this tapa to TapaId
        /// </summary>
        public double Distance { get; set; }
    }
}