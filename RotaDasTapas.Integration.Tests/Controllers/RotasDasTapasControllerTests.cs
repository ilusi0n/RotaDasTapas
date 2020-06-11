using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Controllers;
using RotaDasTapas.Gateway;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles;
using RotaDasTapas.Profiles.TypeConverter;
using RotaDasTapas.Profiles.ValueResolver;
using RotaDasTapas.Services;
using RotaDasTapas.Unit.Tests.Mocks;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Integration.Tests.Controllers
{
    [TestClass]
    public class RotasDasTapasControllerTests
    {
        private readonly RotaDasTapasController _rotaDasTapasController;
        public RotasDasTapasControllerTests()
        {
            var businessHoursUtils = new BusinessHoursHoursUtils();
            var serviceProvider = new Mock<IServiceProvider>();
            var configuration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TapasResponseProfile());
                mc.ConstructServicesUsing(serviceProvider.Object.GetService);
            });

            var mapper = configuration.CreateMapper();
            serviceProvider.Setup(x => x.GetService(typeof(TapasResponseTypeConverter)))
                .Returns(new TapasResponseTypeConverter(mapper));
            serviceProvider.Setup(x => x.GetService(typeof(BusinessHoursResolver)))
                .Returns(new BusinessHoursResolver(businessHoursUtils));
            
            
            
            var tapasGateway = new TapasGateway();
            var tsp = new TravellingSalesmanProblem();
            var journeyUtils = new JourneyUtils(tsp);
            _rotaDasTapasController = new RotaDasTapasController(new TapasService(tapasGateway,mapper,journeyUtils));
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
                Localtime = new DateTime(2020,06,11,18,16,00).ToString()
            };
            var tapasResponse =  TapasServiceMocks.GetAllTapas();

            //Act
            var response = _rotaDasTapasController.GetTapas(headers, rotaDasTapasParameters) as OkObjectResult;
            var result = response.Value as TapasResponse;

            //Assert
            Assert.IsNotNull(result);
            AssertValues(tapasResponse,result);
        }
        
        private void AssertValues(TapasResponse expected, TapasResponse actual)
        {
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual.Tapas,typeof(IEnumerable<Tapa>));
            Assert.AreEqual(expected.Tapas.Count(),actual.Tapas.Count());
            var expectedTapas = expected.Tapas.ToList();
            var nExpected = 0;
            foreach (var result in actual.Tapas)
            {
                Assert.IsInstanceOfType(result,typeof(Tapa));
                Assert.AreEqual(expectedTapas[nExpected].Address, result.Address);
                Assert.AreEqual(expectedTapas[nExpected].City, result.City);
                Assert.AreEqual(expectedTapas[nExpected].Description, result.Description);
                Assert.AreEqual(expectedTapas[nExpected].Id, result.Id);
                Assert.AreEqual(expectedTapas[nExpected].Name, result.Name);
                Assert.AreEqual(expectedTapas[nExpected].Title, result.Title);
                Assert.AreEqual(expectedTapas[nExpected].ImageUrl, result.ImageUrl);
                Assert.IsNotNull(expectedTapas[nExpected].Schedule);
                Assert.AreEqual(expectedTapas[nExpected].Schedule.Hours, result.Schedule.Hours);
                Assert.AreEqual(expectedTapas[nExpected].Schedule.Status, result.Schedule.Status);
                Assert.AreEqual(expectedTapas[nExpected].Schedule.Disable, result.Schedule.Disable);
                nExpected++;
            }
        }
    }
}