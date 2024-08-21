using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Node
    {

        public List<Edge> edges;
        
        public Point position {  get; set; }
        
        public Int32 Id { get; set; }

        public Node(Int32 id) 
        {
            edges = new List<Edge>();
            Id = id;
        }

        public void AddEdgeTo(Node node)
        {
            Edge edge = new Edge(this, node);
            edges.Add(edge);
        }

        public void AddEdgeFrom(Node node)
        {
            Edge edge = new Edge(node, this);
            node.edges.Add(edge);
        }

    }
}
