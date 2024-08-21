using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Edge
    {
        public Node Source { get; set; }
        public Node Target { get; set; }

        public Edge(Node source, Node target)
        {
            Source = source;
            Target = target;
        }
    }
}
