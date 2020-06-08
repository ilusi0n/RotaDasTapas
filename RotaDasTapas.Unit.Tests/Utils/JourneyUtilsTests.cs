using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Unit.Tests.Mocks;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Utils
{
    [TestClass]
    public class JourneyUtilsTests
    {
        [TestMethod]
        public void Solve_ValidSelectedTapasStartLisboa_2_ReturnOptimalJourney()
        {
            //arrange
            var selectedTapas = new List<string>()
            {
                "Lisbon_1", "Lisbon_2", "Lisbon_3"
            };

            var startTapaId = "Lisbon_1";
            var tapasByCity = TapasGatewayMocks.GetAllTapasWithPath();

            //act

            var journeyUtils = new JourneyUtils();
            journeyUtils.Init(selectedTapas, startTapaId, tapasByCity);
            var result = journeyUtils.SolveProblem();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lisbon_1", result.ToList()[0].TapaDto.Id);
            Assert.AreEqual("Lisbon_2", result.ToList()[1].TapaDto.Id);
            Assert.AreEqual("Lisbon_3", result.ToList()[2].TapaDto.Id);
            Assert.AreEqual("Lisbon_1", result.ToList()[3].TapaDto.Id);
        }

        [TestMethod]
        public void Solve_ValidSelectedTapasStartLisbon_2_ReturnOptimalJourney()
        {
            //arrange
            var selectedTapas = new List<string>()
            {
                "Lisbon_1", "Lisbon_2", "Lisbon_3"
            };

            var startTapaId = "Lisbon_2";
            var tapasByCity = TapasGatewayMocks.GetAllTapasWithPath();

            //act

            var journeyUtils = new JourneyUtils();
            journeyUtils.Init(selectedTapas, startTapaId, tapasByCity);
            var result = journeyUtils.SolveProblem();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lisbon_2", result.ToList()[0].TapaDto.Id);
            Assert.AreEqual("Lisbon_1", result.ToList()[1].TapaDto.Id);
            Assert.AreEqual("Lisbon_3", result.ToList()[2].TapaDto.Id);
            Assert.AreEqual("Lisbon_2", result.ToList()[3].TapaDto.Id);
        }
    }
}