using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using RotaDasTapas.Constants;
using RotaDasTapas.Errors;
using RotaDasTapas.Models.Configuration;

namespace RotaDasTapas.Filters
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IOptions<RotaDasTapasConfiguration> _rotaDasTapasConfiguration;

        public AuthorizationFilterAttribute(IOptions<RotaDasTapasConfiguration> rotaDasTapasConfiguration)
        {
            _rotaDasTapasConfiguration = rotaDasTapasConfiguration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["ApiKey"];
            var herokuKey = Environment.GetEnvironmentVariable("apikey") ?? _rotaDasTapasConfiguration.Value.ApiKey;

            if (!apiKey.Any()) return;
            if (!apiKey.Equals(herokuKey))
                context.Result = new ObjectResult(new UnauthorizedError(ErrorConstants.UnauthorizedError));
        }
    }
}