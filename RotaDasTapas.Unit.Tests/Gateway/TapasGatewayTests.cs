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
        
        [TestMethod]
        public void GetTapaByname_ValidName_ReturnValidModel()
        {
            //Arrange
            var name = "Name1";
            
            //Act
            var result = _tapasGateway.GetTapaByName(name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name,result.Name);
        }
        
        [TestMethod]
        public void GetTapaByName_InvalidName_ReturnNull()
        {
            //Arrange
            var name = "fake";
            
            //Act
            var result = _tapasGateway.GetTapaByName(name);

            //Assert
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void GetTapaByCity_ValidCity_ReturnListOfTapas()
        {
            //Arrange
            var city = "Lisboa";
            
            //Act
            var result = _tapasGateway.GetTapasByCity(city);

            //Assert
            Assert.IsNotNull(result);
            foreach (var res in result)
            {
                Assert.AreEqual(city,res.City);
            }
        }
        
        [TestMethod]
        public void GetTapaByCity_CityDoesntExist_ReturnEmptyList()
        {
            //Arrange
            var city = "fake";
            
            //Act
            var result = _tapasGateway.GetTapasByCity(city);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }
    }
}