using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public class TravellingSalesmanProblem
    {
        #region Member Variables

        private readonly Path[,] _adjacencyMatrix;
        private readonly IEnumerable<Vertice> _vertices;

        #endregion

        #region Constructor

        public TravellingSalesmanProblem(IEnumerable<Vertice> vertices, Path[,] matrix)
        {
            _vertices = vertices;
            _adjacencyMatrix = matrix;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Vertice> Solve(out double cost)
        {
            var startVertex = _vertices.First();//source node is assumed to be the first
            var set = new HashSet<Vertice>(_vertices);
            set.Remove(startVertex);

            var root = new Node();
            cost = GetMinimumCostRoute(startVertex, set, root);
            return TraverseTree(root, startVertex);
        }

        #endregion

        #region Private Methods

        private double GetMinimumCostRoute(Vertice startVertex, HashSet<Vertice> set, Node root)
        {
            if (!set.Any())
            {
                //source node is assumed to be the first
                root.ChildNodes = new[] { new Node { Value = _vertices.First(), Selected = true } };
                return _adjacencyMatrix[startVertex.Id, 0].Distance;
            }

            double totalCost = double.MaxValue;
            int i = 0;
            int selectedIdx = i;
            root.ChildNodes = new Node[set.Count()];

            foreach (var destination in set)
            {
                root.ChildNodes[i] = new Node { Value = destination };

                var costOfVistingCurrentNode = _adjacencyMatrix[startVertex.Id, destination.Id];

                var newSet = new HashSet<Vertice>(set);
                newSet.Remove(destination);
                var costOfVisitingOtherNodes = GetMinimumCostRoute(destination, newSet, root.ChildNodes[i]);
                var currentCost = costOfVistingCurrentNode.Distance + costOfVisitingOtherNodes;

                if (totalCost > currentCost)
                {
                    totalCost = currentCost;
                    selectedIdx = i;
                }

                i++;
            }

            root.ChildNodes[selectedIdx].Selected = true;

            return totalCost;

        }

        private IEnumerable<Vertice> TraverseTree(Node root, Vertice startint)
        {
            var q = new Queue<Vertice>();
            q.Enqueue(startint);
            TraverseTreeUtil(root, q);
            return q;
        }

        private void TraverseTreeUtil(Node root, Queue<Vertice> vertices)
        {
            if (root.ChildNodes == null)
            {
                return;
            }

            foreach (var child in root.ChildNodes)
            {
                if (child.Selected)
                {
                    vertices.Enqueue(child.Value);
                    TraverseTreeUtil(child, vertices);
                }
            }
        }

        #endregion
    }
}