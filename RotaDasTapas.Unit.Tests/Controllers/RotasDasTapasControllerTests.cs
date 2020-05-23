using System;
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
            var listTapas = TapasRepositoryMocks.GetListOfTapasSingleOneWithAllFields();
            _mockTapasService.Setup(d => d.GetAllTapas()).Returns(listTapas);

            //Act
            var response = _rotaDasTapasController.GetTapas(headers) as OkObjectResult;
            var result = response.Value as IEnumerable<Tapa>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(listTapas, result);
        }

        [TestMethod]
        public void GetTapas_ListTapasNull_ShouldReturnInternalServerError()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            IEnumerable<Tapa> listTapas = null;
            _mockTapasService.Setup(d => d.GetAllTapas()).Returns(listTapas);

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
            var rotaDasTapasRequest = new RotaDasTapasByNameRequest
            {
                Name = "name"
            };
            var tapa = TapasRepositoryMocks.GetGetTapaAllFields();
            _mockTapasService.Setup(d => d.GetTapaByName(rotaDasTapasRequest.Name)).Returns(tapa);

            //Act
            var response = _rotaDasTapasController.GetTapaByName(headers, rotaDasTapasRequest) as OkObjectResult;
            var result = response.Value as Tapa;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(rotaDasTapasRequest.Name, result.Name);
        }

        [TestMethod]
        public void GetTapaByName_FakeName_ShouldReturnNotFoundError()
        {
            //Arrange
            var headers = new RotaDasTapasHeaders
            {
                ApiKey = "fakekey"
            };
            var rotaDasTapasRequest = new RotaDasTapasByNameRequest
            {
                Name = "fake"
            };
            Tapa tapa = null;
            _mockTapasService.Setup(d => d.GetTapaByName(rotaDasTapasRequest.Name)).Returns(tapa);

            //Act
            var response = _rotaDasTapasController.GetTapaByName(headers, rotaDasTapasRequest) as ObjectResult;
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
            var rotaDasTapasByCityRequest = new RotaDasTapasByCityRequest()
            {
                City = "Lisboa"
            };
            var tapa = TapasRepositoryMocks.GetListOfTapasSingleOneWithAllFields();
            _mockTapasService.Setup(d => d.GetTapaByCity(rotaDasTapasByCityRequest.City)).Returns(tapa);

            //Act
            var response = _rotaDasTapasController.GetTapasByCity(headers, rotaDasTapasByCityRequest) as ObjectResult;
            var result = response.Value as IEnumerable<Tapa>;

            //Assert
            Assert.IsNotNull(result);
            foreach (var res in result)
            {
                Assert.AreEqual(rotaDasTapasByCityRequest.City,res.City);
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
            var rotaDasTapasByCityRequest = new RotaDasTapasByCityRequest()
            {
                City = "fake"
            };
            var tapa = new List<Tapa>();
            _mockTapasService.Setup(d => d.GetTapaByCity(rotaDasTapasByCityRequest.City)).Returns(tapa);

            //Act
            var response = _rotaDasTapasController.GetTapasByCity(headers, rotaDasTapasByCityRequest) as ObjectResult;
            var result = response.Value as IEnumerable<Tapa>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Any());
        }
    }
}