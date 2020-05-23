using System.Net;

namespace RotaDasTapas.Errors
{
    public class NotFoundError : ApiError
    {
        public NotFoundError(string message)
            : base((int) HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }
}