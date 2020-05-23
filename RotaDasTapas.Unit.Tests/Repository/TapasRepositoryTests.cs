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
        }
    }
}