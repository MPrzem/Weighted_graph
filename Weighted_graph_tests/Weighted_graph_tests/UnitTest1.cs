using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using weighted_graph;
using Newtonsoft.Json;

namespace Weighted_graph_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            weighted_graph.Weighted_graph graph = new weighted_graph.Weighted_graph();
            graph.download_Graph(@"C:\Users\Student241580\source\repos\weighted_graph\Graph_test.txt");
            Assert.AreEqual(9,graph.NumberOfBranches);
            Assert.AreEqual(5,graph.NumberOfVertices);
            Assert.AreEqual(1,graph.StartingVertice);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Weighted_graph graph = new Weighted_graph();
            graph.download_Graph(@"C:\Users\Student241580\source\repos\weighted_graph\Graph_test.txt");
            string actualBranchJson = JsonConvert.SerializeObject(new Weighted_graph.Branch(2, 10));
            string expectedBranchJson = JsonConvert.SerializeObject(graph.Incidences_lists[1].Head.data);
            Assert.AreEqual(actualBranchJson,expectedBranchJson);
            Assert.AreEqual(5, graph.NumberOfVertices);
            Assert.AreEqual(1, graph.StartingVertice);
        }
    }
}