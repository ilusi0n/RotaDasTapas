using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RotaDasTapas.Errors;

namespace RotaDasTapas.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var apiError = new InternalServerError(ex.Message);
            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}