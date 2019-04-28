using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using two_way_list;

namespace weighted_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Weighted_graph graph = new Weighted_graph();
            graph.download_Graph(@"C:\Users\Student241580\source\repos\weighted_graph\Graph_test.txt");
            Console.WriteLine(graph.NumberOfBranches);
            Console.WriteLine(graph.NumberOfVertices);
            Console.WriteLine(graph.StartingVertice);
            Console.ReadKey();

        }
    }
}
