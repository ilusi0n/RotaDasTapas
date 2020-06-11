using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Controllers;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Services;
using RotaDasTapas.Unit.Tests.Mocks;

namespace RotaDasTapas.Unit.Tests.Controllers
{
    [TestClass]
    public class RotasDasTapasControllerTests
    {
        private readonly Mock<ITapasService> _mockTapasService;
        private readonly RotaDasTapasController _rotaDasTapasController;

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
            var rotaDasTapasParameters = new TapasParameters
            {
                Localtime = DateTime.Now.ToString()
            };
            var tapasResponse = new TapasResponse
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockTapasService.Setup(d => d.GetAllTapas(It.IsAny<TapasParameters>())).Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapas(headers, rotaDasTapasParameters) as OkObjectResult;
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
            var journeyParameters = new JourneyParameters
            {
                City = "city",
                ListSelectedTapas = "list"
            };
            var tapasResponse = new TapasResponse
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockTapasService.Setup(d => d.GetTapasRoute(It.IsAny<JourneyParameters>()))
                .Returns(tapasResponse);

            //Act
            var response = _rotaDasTapasController.GetTapasRoute(headers, journeyParameters) as OkObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tapasResponse, result);
        }
    }
}