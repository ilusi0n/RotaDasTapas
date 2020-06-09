namespace RotaDasTapas.Models.Request
{
    public class JourneyParameters : TapasParameters
    {
        public string City { get; set; }
        public string ListSelectedTapas { get; set; }
    }
}