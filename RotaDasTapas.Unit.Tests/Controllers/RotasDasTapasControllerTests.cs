using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Controllers;
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
            var listTapas = TapasRepositoryMocks.GetListOfTapasSingleOneWithAllFields();
            _mockTapasService.Setup(d => d.GetAllTapas()).Returns(listTapas);
            
            //Act
            var result = _rotaDasTapasController.GetTapas();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}