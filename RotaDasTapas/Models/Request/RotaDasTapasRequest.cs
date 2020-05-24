namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasRequest
    {
        /// <summary>
        ///     The response will have the city and then a List of Tapas on that City
        /// </summary>
        public bool AggregateByCity { get; set; }
    }
}