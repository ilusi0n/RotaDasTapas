using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Errors;
using RotaDasTapas.Filters;
using RotaDasTapas.Models.Configuration;

namespace RotaDasTapas.Unit.Tests.Filters
{
    [TestClass]
    public class AuthorizationFilterAttributeTests
    {
        private readonly AuthorizationFilterContext _context;
        private readonly Mock<IOptions<RotaDasTapasConfiguration>> _mockSearchConfiguration;
        public AuthorizationFilterAttributeTests()
        {
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();
            _mockSearchConfiguration = new Mock<IOptions<RotaDasTapasConfiguration>>();

            var actionContext = new ActionContext(
                httpContext,
                routeData,
                actionDescriptor,
                modelState
            );
            
            _context = new AuthorizationFilterContext(
                actionContext,
                new List<IFilterMetadata>()
                );
        }

        [TestMethod]
        public void OnAuthorization_FakeKey_ReturnsUnauthorizedErrorObjectResult()
        {
            //Arrange
            _mockSearchConfiguration
                .Setup(mock => mock.Value)
                .Returns(
                    new RotaDasTapasConfiguration()
                    {
                        ApiKey = "fakeKey"
                    }
                );
            var filter = new AuthorizationFilterAttribute(_mockSearchConfiguration.Object);
            _context.HttpContext.Request.Headers["ApiKey"] = "123";
            
            //Act
            filter.OnAuthorization(_context);
            var response = _context.Result as ObjectResult;
            var result = response.Value as UnauthorizedError;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int) HttpStatusCode.Unauthorized, result.StatusCode);
            Assert.AreEqual(HttpStatusCode.Unauthorized.ToString(), result.StatusDescription);
            Assert.AreEqual(ErrorConstants.UnauthorizedError, result.Message);
        }
        
        [TestMethod]
        public void OnAuthorization_Valid_NullResult()
        {
            //Arrange
            _mockSearchConfiguration
                .Setup(mock => mock.Value)
                .Returns(
                    new RotaDasTapasConfiguration()
                    {
                        ApiKey = "123"
                    }
                );
            var filter = new AuthorizationFilterAttribute(_mockSearchConfiguration.Object);
            _context.HttpContext.Request.Headers["ApiKey"] = "123";
            
            //Act
            filter.OnAuthorization(_context);
            var result = _context.Result;

            //Assert
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void OnAuthorization_NoKey_VoidResult()
        {
            //Arrange
            _mockSearchConfiguration
                .Setup(mock => mock.Value)
                .Returns(
                    new RotaDasTapasConfiguration()
                    {
                        ApiKey = null
                    }
                );
            var filter = new AuthorizationFilterAttribute(_mockSearchConfiguration.Object);

            //Act
            filter.OnAuthorization(_context);
            var result = _context.Result;

            //Assert
            Assert.IsNull(result);
        }
    }
}