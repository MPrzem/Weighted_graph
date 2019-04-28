using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using two_way_list;

namespace weighted_graph
{
    class Weighted_graph
    {
        public My_list<Branch>[] Incidences_list { get; private set; }
        const char Separator = '\t';
        public int NumberOfVertices { get;private set; }
        public int NumberOfBranches { get;private set; }
        public int StartingVertice { get;private set; }

        public class Branch
        {
            int vertice;
            int weight;
            public Branch(int vertice,int weight)
            {
                this.vertice = vertice;
                this.weight = weight;
            }
        }
        public void download_Graph(string file_Name)
        {
            try
            {
                FileStream gs = new FileStream(file_Name, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(gs);
                string tmp;
                if (!sr.EndOfStream)
                    decodeFirstLine(sr.ReadLine());
                while (!sr.EndOfStream)
                {
                    decodeNormalLine(tmp = sr.ReadLine());
                }
                sr.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Zły format pliku, to nie liczba");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        /// <summary>
        /// There the array is also incialized
        /// </summary>
        /// <param name="line"></param>
        private void decodeFirstLine(string line)
        {
            string[] tmp_strings;
            tmp_strings = line.Split(Separator);
            if (tmp_strings.GetLength(0) != 3)
                throw (new IOException("zły format pliku"));
            NumberOfBranches = Int32.Parse(tmp_strings[0]);
            NumberOfVertices = Int32.Parse(tmp_strings[1]);
            StartingVertice = Int32.Parse(tmp_strings[2]);
            Incidences_lists = new My_list<Branch>[NumberOfVertices];
        }
        private void decodeNormalLine(string line)
        {
            string[] tmp_strings;
            tmp_strings = line.Split(Separator);
            if (tmp_strings.GetLength(0) != 3)
                throw (new IOException("zły format pliku"));
            int startingVertice = Int32.Parse(tmp_strings[0]);
            int endingVertice = Int32.Parse(tmp_strings[1]);
            int branchWeight= Int32.Parse(tmp_strings[2]);
            Incidences_lists[startingVertice].InsertLast(new Branch(endingVertice, branchWeight));
        }
    }
}
