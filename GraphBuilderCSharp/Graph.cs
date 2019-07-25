using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBuilderCSharp
{
    public class Graph
    {
        private List<Vertex> data { get; }
        public int Number { get; }

        public Graph(int number)
        {
            data = new List<Vertex>(number);
            for (int i = 1; i <= number; i++)
                data.Add(new Vertex(i));
            Number = number;
        }

        public void SetValue(int incidentFromIndex, int incidentToIndex, int weight)
        {
            Vertex vertexFrom = data[incidentFromIndex - 1];
            Vertex vertexTo = data[incidentToIndex - 1];
            Edge curEdge = new Edge(vertexFrom, vertexTo, weight);
            vertexFrom.AdjacencyList.Add(curEdge);
        }

        public List<Vertex> GetVertices()
        {
            return data;
        }
    }
}
