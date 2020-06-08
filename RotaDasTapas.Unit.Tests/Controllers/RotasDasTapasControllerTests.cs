using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Controllers;
using RotaDasTapas.Errors;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Services;
using RotaDasTapas.Unit.Tests.Mocks;

namespace RotaDasTapas.Unit.Tests.Controllers
{
    [TestClass]
    public class RotasDasTapasControllerTests
    {
        private readonly RotaDasTapasController _rotaDasTapasController;
        private readonly Mock<ITapasService> _mockTapasService;

        public RotasDasTapasControllerTests()
        {
            _mockTapasService = new Mock<ITapasService>();
            _rotaDasTapasController = new RotaDasTapasController(_mockTapasService.Object);
        }

        [TestMethod]
        public void GetTapas_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            var tapasResponse = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockTapasService.Setup(d => d.GetAllTapas()).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapas(headers) as OkObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tapasResponse, result);
        }

        [TestMethod]
        public void GetTapasRoute_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            var tapasResponse = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockTapasService.Setup(d => d.GetTapasRoute(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapasRoute(headers, "city", "list") as OkObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tapasResponse, result);
        }

        [TestMethod]
        public void GetTapas_ListTapasNull_ShouldReturnInternalServerError()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            TapasResponse tapasResponse = null;
            _mockTapasService.Setup(d => d.GetAllTapas()).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapas(headers) as ObjectResult;
            var result = response.Value as InternalServerError;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int) HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(HttpStatusCode.InternalServerError.ToString(), result.StatusDescription);
            Assert.AreEqual(ErrorConstants.InternalError, result.Message);
        }
    }
}