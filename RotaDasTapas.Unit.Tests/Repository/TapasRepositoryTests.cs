using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Repository;

namespace RotaDasTapas.Unit.Tests.Repository
{
    [TestClass]
    public class TapasRepositoryTests
    {
        private readonly ITapasRepository _tapasRepository;
        public TapasRepositoryTests()
        {
            _tapasRepository = new TapasRepository();
        }

        [TestMethod]
        public void GetAllTapas_NotArgument_ReturnValidModel()
        {
            //Arrange
            
            //Act
            var result = _tapasRepository.GetAllTapas();

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
            var result = _tapasRepository.GetTapaByName(name);

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
            var result = _tapasRepository.GetTapaByName(name);

            //Assert
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void GetTapaByCity_ValidCity_ReturnListOfTapas()
        {
            //Arrange
            var city = "Lisboa";
            
            //Act
            var result = _tapasRepository.GetTapasByCity(city);

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
            var result = _tapasRepository.GetTapasByCity(city);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }
    }
}