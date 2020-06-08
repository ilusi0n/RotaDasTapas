using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Gateway;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles;
using RotaDasTapas.Services;
using RotaDasTapas.Unit.Tests.Mocks;

namespace RotaDasTapas.Unit.Tests.Services
{
    [TestClass]
    public class TapasServiceTests
    {
        private readonly ITapasService _tapasService;
        private readonly Mock<ITapasGateway> _tapasGateway;
        private readonly Mock<IMapper> _mockMapper;

        public TapasServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMapper
                .Setup(s => s.ConfigurationProvider)
                .Returns(new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new TapasResponseProfile());
                }));
            _tapasGateway = new Mock<ITapasGateway>();
            _tapasService = new TapasService(_tapasGateway.Object,_mockMapper.Object);
        }

        [TestMethod]
        public void GetAllTapas_NoArgument_ReturnsOk()
        {
            //Arrange
            var expectedListTapas = TapasGatewayMocks.GetListOfTapasSingleOneWithAllFields();
            var expectedMock = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockMapper.Setup(m =>
                    m.Map<TapasResponse>(It.IsAny<IEnumerable<TapaDto>>()))
                .Returns(expectedMock);
            _tapasGateway.Setup(d => d.GetAllTapas()).Returns(expectedListTapas);

            //Act
            var result = _tapasService.GetAllTapas();

            //Assert
            AssertTests(expectedMock, result);
        }
        
        [TestMethod]
        public void GetTapasRoute_LisbonValidIds_ReturnsOk()
        {
            //Arrange
            var expectedListTapas = TapasGatewayMocks.GetAllTapasWithPath();
            var listSelected = "Lisbon_1|Lisbon_2|Lisbon_3";
            var expectedMock = new TapasResponse()
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };
            _mockMapper.Setup(m =>
                    m.Map<TapasResponse>(It.IsAny<IEnumerable<TapaDto>>()))
                .Returns(expectedMock);
            _tapasGateway.Setup(d => d.GetTapasRoute("Lisbon")).Returns(expectedListTapas);

            //Act
            var result = _tapasService.GetTapasRoute("Lisbon",listSelected);

            //Assert
            AssertTests(expectedMock, result);
        }

        private void AssertTests(TapasResponse expected, TapasResponse result)
        {
            var resultList = result.Tapas.ToList();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tapas);
            Assert.AreEqual(expected.Tapas.Count(), result.Tapas.Count());
            var nExpect = 0;
            foreach (var exp in expected.Tapas)
            {
                AssertTests(exp,resultList[nExpect++]);
            }
        }

        private void AssertTests(Tapa expected, Tapa result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Address, result.Address);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Title, result.Title);
            Assert.AreEqual(expected.City, result.City);
            Assert.AreEqual(expected.ImageUrl, result.ImageUrl);
            Assert.AreEqual(expected.Id, result.Id);
        }
    }
}