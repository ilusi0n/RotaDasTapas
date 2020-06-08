using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Utils
{
    [TestClass]
    public class TapasUtilsTests
    {
        [TestMethod]
        public void Init_ValidModel_ReturnValidModel()
        {
            //Arrange

            //Act
            var result = TapasUtils.Init();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}