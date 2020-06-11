using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Models.TSP;
using RotaDasTapas.Unit.Tests.Mocks;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Utils
{
    [TestClass]
    public class JourneyUtilsTests
    {
        private readonly Mock<ITravellingSalesmanProblem> _TSPmock;
        public JourneyUtilsTests()
        {
            _TSPmock = new Mock<ITravellingSalesmanProblem>();
        }
        [TestMethod]
        public void Solve_ValidSelectedTapasStartLisboa_2_ReturnOptimalJourney()
        {
            //arrange
            var selectedTapas = new List<string>
            {
                "Lisbon_1", "Lisbon_2", "Lisbon_3"
            };
            
            var listVertices = new List<Vertice>();

            var startTapaId = "Lisbon_1";
            var tapasByCity = TapasGatewayMocks.GetAllTapasWithPath();
            double cost;
            _TSPmock.Setup(el => el.Solve(out cost)).Returns(listVertices);

            //act
            var journeyUtils = new JourneyUtils(_TSPmock.Object);
            journeyUtils.Init(selectedTapas, startTapaId, tapasByCity);
            var result = journeyUtils.SolveProblem();

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Solve_ValidSelectedTapasStartLisbon_2_ReturnOptimalJourney()
        {
            //arrange
            var selectedTapas = new List<string>
            {
                "Lisbon_1", "Lisbon_2", "Lisbon_3"
            };
            var listVertices = new List<Vertice>();
            double cost;
            _TSPmock.Setup(el => el.Solve(out cost)).Returns(listVertices);

            var startTapaId = "Lisbon_2";
            var tapasByCity = TapasGatewayMocks.GetAllTapasWithPath();

            //act
            var journeyUtils = new JourneyUtils(_TSPmock.Object);
            journeyUtils.Init(selectedTapas, startTapaId, tapasByCity);
            var result = journeyUtils.SolveProblem();

            //assert
            Assert.IsNotNull(result);
        }
    }
}