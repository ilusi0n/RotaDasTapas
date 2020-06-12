using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public class TravellingSalesmanProblem : ITravellingSalesmanProblem
    {
        #region Constructor

        public void Init(TspModel tspModel)
        {
            _vertices = tspModel.vertices;
            _adjacencyMatrix = tspModel.matrix;
            _startVerticeIndex = tspModel.StartVerticeId;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Vertice> Solve(out double cost)
        {
            var startVertex = _vertices.ToList()[_startVerticeIndex];
            var set = new HashSet<Vertice>(_vertices);
            set.Remove(startVertex);

            var root = new Node();
            cost = GetMinimumCostRoute(startVertex, set, root);
            return TraverseTree(root, startVertex);
        }

        #endregion

        #region Member Variables

        private Path[,] _adjacencyMatrix;
        private IEnumerable<Vertice> _vertices;
        private int _startVerticeIndex;

        #endregion

        #region Private Methods

        private double GetMinimumCostRoute(Vertice startVertex, HashSet<Vertice> set, Node root)
        {
            if (!set.Any())
            {
                root.ChildNodes = new[] {new Node {Value = _vertices.ToList()[_startVerticeIndex], Selected = true}};
                return _adjacencyMatrix[startVertex.Id, 0].Distance;
            }

            var totalCost = double.MaxValue;
            var i = 0;
            var selectedIdx = i;
            root.ChildNodes = new Node[set.Count];

            foreach (var destination in set)
            {
                root.ChildNodes[i] = new Node {Value = destination};

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
            if (root.ChildNodes == null) return;

            foreach (var child in root.ChildNodes)
                if (child.Selected)
                {
                    vertices.Enqueue(child.Value);
                    TraverseTreeUtil(child, vertices);
                }
        }

        #endregion
    }
}