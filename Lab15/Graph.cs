using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Lab15
{
    public class Graph
    {

        public List<Node> nodes;

        public Graph() 
        {
            nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        private char[] colors;
        private bool[] visited;
        
        private void AcyclicGraph_DFS(Node currentNode)
        {
            colors[currentNode.Id - 1] = 'G';
            foreach (Edge edge in currentNode.edges) 
            {
                if (colors[edge.Target.Id - 1] == 'W') AcyclicGraph_DFS(edge.Target);
                if (colors[edge.Target.Id - 1] == 'G') isAcyclic = false;
            }
            colors[currentNode.Id - 1] = 'B';
        }

        private bool isAcyclic = true;

        private void TopoSort_DFS(Node node, List<Node> sorted_graph)
        {
            if (visited[node.Id - 1] == true) { return; }
            foreach (Edge edge in node.edges)
            {
                TopoSort_DFS(edge.Target, sorted_graph);
            }
            visited[node.Id - 1] = true;
            sorted_graph.Insert(0, node);
        }

        public List<Node> TopoSort()
        {
           
            colors = new char[nodes.Count];
            visited = new bool[nodes.Count];    
            for (int i = 0; i < nodes.Count; ++i)
            {
                colors[i] = 'W';
            }
            foreach(var node in nodes)
            {
                if (colors[node.Id - 1] == 'W') AcyclicGraph_DFS(node);
            }

            if (!isAcyclic) { return null; }

            string result = string.Empty;

            for (int i = 0; i < nodes.Count; ++i)
            {
                visited[i] = false;
            }

            var sortedGraph = new List<Node>();
            foreach (Node node in nodes)
            {
                TopoSort_DFS(node, sortedGraph);
            }
            return sortedGraph;
        }

        public Int32 GetGlobalId()
        {
            int maxId = 0;
            foreach (Node node in nodes)
            {
                if (node.Id > maxId) { maxId = node.Id; }
            }
            return maxId;
        }

        public void SaveToFile(StreamWriter sw)
        {
            try
            {
                if (sw == null) { throw new NullReferenceException("Проблема при сохранении в файл."); }
                foreach (Node node in nodes) 
                {
                    string line = $"{node.Id}";
                    foreach(var edge in node.edges)
                    {
                        line += $" {edge.Target.Id}";
                    }
                    sw.WriteLine(line);
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        static public Graph LoadFromFile(StreamReader sr)
        {
            try
            {
                if (sr == null) { throw new NullReferenceException("Проблема при открытии файла."); }
                Graph newGraph = new Graph();

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');

                    
                    Node firstNode = new Node(int.Parse(line[0]));
                    bool nodeIsAlreadyExist = false;
                    foreach (var node in newGraph.nodes)
                    {
                        if (node.Id == firstNode.Id) { nodeIsAlreadyExist = true; break; }
                    }
                    if (!nodeIsAlreadyExist) newGraph.AddNode(firstNode);


                    for (int i = 1; i < line.Length; ++i)
                    {
                        nodeIsAlreadyExist = false;
                        int newNodeId = int.Parse(line[i]);

                        Node currentNode = null;
                        foreach (var node in newGraph.nodes)
                        {
                            if (node.Id == newNodeId) {nodeIsAlreadyExist = true; currentNode = node; break; }
                        }
                        if (nodeIsAlreadyExist) firstNode.AddEdgeTo(currentNode);
                        else
                        {
                            currentNode = new Node(newNodeId);
                            newGraph.AddNode(currentNode);
                            firstNode.AddEdgeTo(currentNode);
                        }

                    }
                    
                }

                foreach (var node in newGraph.nodes)
                {
                    Random rnd = new Random();
                    node.position = new Point(rnd.Next(0, 1000), rnd.Next(0, 500));
                }

                return newGraph;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
