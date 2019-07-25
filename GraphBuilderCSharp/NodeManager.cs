using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBuilderCSharp
{
    public class NodeManager
    {
        private Graph Graph { get; set; }

        public void Paint(Graphics graphics)
        {
            if (Graph != null)
                foreach (var vertex in Graph.GetVertices())
                {
                    vertex.Draw(graphics);
                }
        }

        public void LoadTxtFormatGraph(string graphFile)
        {
            FileStream ifs = new FileStream(graphFile, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            string[] tokens = null;

            line = sr.ReadLine();
            line = line.Trim();

            tokens = line.Split(' ');
            int numVertices = int.Parse(tokens[0]); // Convert.ToInt32
            if (numVertices < 0)
                throw new Exception("Number nodes is a negative");

            Graph = new Graph(numVertices);

            while (!string.IsNullOrEmpty(line = sr.ReadLine()))
            {
                line = line.Trim();
                tokens = line.Split(' ');
                int incidentFromIndex = int.Parse(tokens[0]);
                int incidentToIndex = int.Parse(tokens[1]);
                int weight = int.Parse(tokens[2]);

                if (incidentFromIndex < 1 || incidentFromIndex > numVertices || incidentToIndex < 1 ||
                    incidentToIndex > numVertices)
                    throw new Exception("The vertex parameter is not in the range 0...this.numVertices");

                Graph.SetValue(incidentFromIndex, incidentToIndex, weight);
            }

            sr.Close();
            ifs.Close();
        }

        public Vertex GetMovingVertex(int mouseX, int mouseY)
        {
            return Graph?.GetVertices().FirstOrDefault(v => v.IsItMe(mouseX, mouseY));
        }
    }
}
