namespace Lab15
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_TopoSort_AssertAcyclicSorted()
        {

            StreamReader streamReader = new StreamReader("C:\\Users\\romanavanesov\\source\\repos\\Lab15\\Lab15\\G.grf");
            Graph graph = Graph.LoadFromFile(streamReader);

            List<Node> sortedGraph = graph.TopoSort();
            List<int> ints = new List<int> { 4, 6, 3, 2, 5, 1, 7}; 

            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(sortedGraph[i].Id, ints[i]);
            }
        }

        [TestMethod]
        public void Test_TopoSort_AssertCyclic()
        {
            Graph graph = new Graph();
            graph.AddNode(new Node(1));
            graph.AddNode(new Node(2));
            graph.AddNode(new Node(3));
            graph.AddNode(new Node(4));

            graph.nodes[0].AddEdgeTo(graph.nodes[1]);
            graph.nodes[1].AddEdgeTo(graph.nodes[2]);
            graph.nodes[2].AddEdgeTo(graph.nodes[0]);

            Assert.AreEqual(graph.TopoSort(), null);
        }
    }
}