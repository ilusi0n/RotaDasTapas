namespace RotaDasTapas.Models.TSP
{
    public class Node
    {
        public Vertice Value { get; set; }
        public Node[] ChildNodes { get; set; }
        public bool Selected { get; set; }
    }
}