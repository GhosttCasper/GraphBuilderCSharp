using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilderCSharp
{
    public enum FileFormat : byte { DIMACS, TXT };

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

        /// <summary>
        /// Проверка файла данных графа до создания экземпляра объекта графа
        /// </summary>
        public bool ValidateGraphFile(string graphFile, FileFormat fileFormat, StreamReader reader)
        {
            switch (fileFormat)
            {
                //case FileFormat.DIMACS: // Discrete Mathematics and Theoretical Computer Science
                //    ValidateDimacsGraphFile(graphFile);
                //    break;
                case FileFormat.TXT:
                    return ValidateTXTGraphFile(graphFile, reader);
                default:
                    throw new Exception("Format " + fileFormat + " not supported");
            }
        }

        private bool ValidateTXTGraphFile(string graphFile, StreamReader sr)
        {
            string line = "";
            string[] tokens = null;

            line = sr.ReadLine();
            tokens = line.Split(' ');
            int numNodes = int.Parse(tokens[0]);

            line = sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                try
                {
                    tokens = line.Split(' ');
                    int incidentFromIndex = int.Parse(tokens[0]);
                    int incidentToIndex = int.Parse(tokens[1]);
                    int weight = int.Parse(tokens[2]);
                    int secondWeight = Int32.MaxValue;
                    if (tokens.Length == 4)
                        secondWeight = int.Parse(tokens[3]);
                }
                catch
                {
                    string message = "Error parsing line = " + line + " in " + graphFile;
                    string caption = "Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                line = sr.ReadLine();
            }

            sr.Close();
            return true;
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
                int secondWeight = 0;
                if (tokens.Length == 4)
                    secondWeight = int.Parse(tokens[3]);

                if (incidentFromIndex < 1 || incidentFromIndex > numVertices || incidentToIndex < 1 ||
                    incidentToIndex > numVertices)
                    throw new Exception("The vertex parameter is not in the range 0...this.numVertices");

                if (tokens.Length == 4)
                    Graph.SetValue(incidentFromIndex, incidentToIndex, weight, secondWeight);
                else
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
