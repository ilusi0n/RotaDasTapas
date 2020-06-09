namespace RotaDasTapas.Constants
{
    public static class ErrorConstants
    {
        public const string InternalError = "Something went wrong";
        public const string UnauthorizedError = "Unauthorized: you can't access this request";
        public const string InvalidDatetime = "Datetime provided is not valid";
        public const string InvalidCountry = "Country invalid or not supported";
        public const string InvalidLengthJourney = "Should have at least 3 Tapas to calculate the journey";
        public const string InvalidListFormat = "Invalid format";
    }
}