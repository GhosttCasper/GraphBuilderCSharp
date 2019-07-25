using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBuilderCSharp
{
    public class Vertex
    {
        //public string Name { get; }
        public int Index { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public const int Radius = 20;

        public List<Edge> AdjacencyList { get; }

        private static Random random = new Random();
        private static Pen pen = null;

        public Vertex(int index)
        {
            Index = index;
            X = random.Next(Radius, 715);
            Y = random.Next(Radius, 390);
            AdjacencyList = new List<Edge>();
        }

        internal void Draw(Graphics graphics)
        {
            pen = new Pen(Brushes.DeepSkyBlue, 2);
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF(X + 3, Y + 1);

            graphics.DrawEllipse(pen, X, Y, Radius, Radius);
            graphics.DrawString(Index.ToString(), drawFont, drawBrush, drawPoint);

            foreach (var edge in AdjacencyList)
                edge.Draw(graphics);
        }

        public bool IsItMe(int mouseX, int mouseY)
        {
            if (mouseX >= X && mouseX <= X + Radius && mouseY >= Y && mouseY <= Y + Radius)
                return true;
            return false;
        }
    }
}
