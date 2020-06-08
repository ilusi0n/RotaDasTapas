using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Gateway;

namespace RotaDasTapas.Unit.Tests.Gateway
{
    [TestClass]
    public class TapasRepositoryTests
    {
        private readonly ITapasGateway _tapasGateway;
        public TapasRepositoryTests()
        {
            _tapasGateway = new TapasGateway();
        }

        [TestMethod]
        public void GetAllTapas_NotArgument_ReturnValidModel()
        {
            //Arrange
            
            //Act
            var result = _tapasGateway.GetAllTapas();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}