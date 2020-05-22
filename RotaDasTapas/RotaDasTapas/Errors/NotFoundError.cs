using System.Net;

namespace RotaDasTapas.Errors
{
    public class NotFoundError : ApiError
    {
        public NotFoundError()
            : base((int) HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString())
        {
        }


        public NotFoundError(string message)
            : base((int) HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }
}