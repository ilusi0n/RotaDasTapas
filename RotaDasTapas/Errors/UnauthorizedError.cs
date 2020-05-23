using System.Net;

namespace RotaDasTapas.Errors
{
    public class UnauthorizedError: ApiError
    {
        public UnauthorizedError(string message)
            : base((int) HttpStatusCode.Forbidden, HttpStatusCode.Forbidden.ToString(), message)
        {
        }
    }
}