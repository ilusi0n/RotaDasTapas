using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Controllers;
using RotaDasTapas.Errors;
using RotaDasTapas.Models;
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

        [TestMethod]
        public void GetTapaByName_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            const string name = "name";
            
            var tapasResponse = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetGetTapaAllFields()
            };
            _mockTapasService.Setup(d => d.GetTapaByName(name)).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapaByName(headers, name) as OkObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tapas);
            Assert.AreEqual(1,result.Tapas.Count());
            Assert.AreEqual(name, result.Tapas.First().Name);
        }

        [TestMethod]
        public void GetTapaByName_FakeName_ShouldReturnNotFoundError()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            const string name = "fake";
            var tapasResponse = new TapasResponse()
            {
                Tapas = new List<Tapa>()
            };
            _mockTapasService.Setup(d => d.GetTapaByName(name)).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapaByName(headers, name) as ObjectResult;
            var result = response.Value as NotFoundError;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int) HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(HttpStatusCode.NotFound.ToString(), result.StatusDescription);
            Assert.AreEqual(ErrorConstants.NotFound, result.Message);
        }
        
        [TestMethod]
        public void GetTapaByCity_ValidCity_ShouldReturnOk()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            
            const string city = "Lisboa";
            var tapasResponse = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockTapasService.Setup(d => d.GetTapaByCity(city)).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapasByCity(headers, city) as ObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tapas);
            foreach (var res in result.Tapas)
            {
                Assert.AreEqual(city,res.City);
            }
        }
        
        [TestMethod]
        public void GetTapaByCity_CityDoesntExist_ShouldReturnOkEmptyList()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            const string city = "fake";

            var tapasResponse = new TapasResponse()
            {
                Tapas = new List<Tapa>()
            };
            _mockTapasService.Setup(d => d.GetTapaByCity(city)).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapasByCity(headers, city) as ObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tapas);
            Assert.IsTrue(!result.Tapas.Any());
        }
    }
}