using System.Net;

namespace RotaDasTapas.Errors
{
    public class InternalServerError : ApiError
    {
        public InternalServerError(string message)
            : base((int) HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }
}