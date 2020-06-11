using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Utils
{
    [TestClass]
    public class TravellingSalesmanProblemTests
    {
        private readonly ITravellingSalesmanProblem _travellingSalesmanProblem;

        public TravellingSalesmanProblemTests()
        {
            _travellingSalesmanProblem = new TravellingSalesmanProblem();
        }

        [TestMethod]
        public void Solve_ListOfTapas_ReturnsOptimalRoute()
        {
            //Arrange
            const int startVertice = 0;
            var listVertices = new List<Vertice>
            {
                CreateVertice(0), CreateVertice(1), CreateVertice(2), CreateVertice(3)
            };
            var matrix = new Path[4, 4]
            {
                {CreatePath(0), CreatePath(10), CreatePath(15), CreatePath(20)},
                {CreatePath(5), CreatePath(0), CreatePath(9), CreatePath(10)},
                {CreatePath(6), CreatePath(13), CreatePath(0), CreatePath(12)},
                {CreatePath(8), CreatePath(8), CreatePath(9), CreatePath(0)}
            };
            var expectedCost = 35.0;
            var expectedRoute = new List<Vertice>
            {
                CreateVertice(0),
                CreateVertice(1),
                CreateVertice(3),
                CreateVertice(2),
                CreateVertice(0)
            };

            //Act
            _travellingSalesmanProblem.Init(startVertice, listVertices, matrix);
            var result = _travellingSalesmanProblem.Solve(out var cost);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCost, cost);
            Assert.IsTrue(CheckArraysAreEqual(expectedRoute, result.ToList()));
        }

        private Vertice CreateVertice(int id)
        {
            return new Vertice
            {
                Id = id
            };
        }

        private Path CreatePath(double distance)
        {
            return new Path
            {
                Distance = distance
            };
        }

        private bool CheckArraysAreEqual(IReadOnlyList<Vertice> expectedRoute, IReadOnlyList<Vertice> actual)
        {
            if (expectedRoute.Count != actual.Count) return false;

            return !expectedRoute.Where((t, i) => t.Id != actual[i].Id).Any();
        }
    }
}