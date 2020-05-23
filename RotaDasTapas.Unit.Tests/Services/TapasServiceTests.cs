using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Models;
using RotaDasTapas.Repository;
using RotaDasTapas.Services;
using RotaDasTapas.Unit.Tests.Mocks;

namespace RotaDasTapas.Unit.Tests.Services
{
    [TestClass]
    public class TapasServiceTests
    {
        private readonly ITapasService _tapasService;
        private readonly Mock<ITapasRepository> _tapasRepository;

        public TapasServiceTests()
        {
            _tapasRepository = new Mock<ITapasRepository>();
            _tapasService = new TapasService(_tapasRepository.Object);
        }

        [TestMethod]
        public void GetAllTapas_NoArgument_ReturnsOk()
        {
            //Arrange
            var expectedListTapas = TapasRepositoryMocks.GetListOfTapasSingleOneWithAllFields();

            _tapasRepository.Setup(d => d.GetAllTapas()).Returns(expectedListTapas);

            //Act
            var result = _tapasService.GetAllTapas();

            //Assert
            AssertTests(expectedListTapas, result);
        }

        [TestMethod]
        public void GetTapaByName_ValidRequest_ReturnsOk()
        {
            //Arrange
            var name = "name";
            var expectedTapa = TapasRepositoryMocks.GetGetTapaAllFields();

            _tapasRepository.Setup(d => d.GetTapaByName(name)).Returns(expectedTapa);

            //Act
            var result = _tapasService.GetTapaByName(name);

            //Assert
            AssertTests(expectedTapa, result);
        }

        private void AssertTests(IEnumerable<Tapa> expected, IEnumerable<Tapa> result)
        {
            var resultList = result.ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Count(), result.Count());
            var nExpect = 0;
            foreach (var exp in expected)
            {
                Assert.AreEqual(exp.Address, resultList[nExpect].Address);
                Assert.AreEqual(exp.Description, resultList[nExpect].Description);
                Assert.AreEqual(exp.Name, resultList[nExpect].Name);
                Assert.AreEqual(exp.Title, resultList[nExpect].Title);
                nExpect++;
            }
        }

        private void AssertTests(Tapa expected, Tapa result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Address, result.Address);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Title, result.Title);
        }
    }
}