using System.Net;

namespace RotaDasTapas.Errors
{
    public class UnauthorizedError : ApiError
    {
        public UnauthorizedError(string message)
            : base((int) HttpStatusCode.Unauthorized, HttpStatusCode.Unauthorized.ToString(), message)
        {
        }
    }
}