using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Errors;
using RotaDasTapas.Filters;

namespace RotaDasTapas.Unit.Tests.Filters
{
    [TestClass]
    public class ApiExceptionFilterAttributeTests
    {
        private readonly ApiExceptionFilterAttribute _filter;
        private readonly ActionContext _actionContext;
        public ApiExceptionFilterAttributeTests()
        {
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();
            _actionContext = new ActionContext(
                httpContext,
                routeData,
                actionDescriptor,
                modelState
            ) {HttpContext = new DefaultHttpContext()};
            _filter = new ApiExceptionFilterAttribute();
        }
        
        [TestMethod]
        public void onException_ThrowsException_InternalServerError()
        {
            //Arrange
            var expectedException = new Exception("InternalServer error");
            var exceptionContext = new ExceptionContext(_actionContext, new List<IFilterMetadata>())
            {
                Exception = expectedException
            };

            //Act
            _filter.OnException(exceptionContext);
            var result = exceptionContext.Result as JsonResult;
            var response = result.Value as InternalServerError;
            
            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError,response.StatusCode);
            Assert.AreEqual(expectedException.Message,response.Message);
        }
    }
}