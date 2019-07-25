using System;
using System.Drawing;

namespace GraphBuilderCSharp
{
    public class Edge
    {
        private const int H = 10;
        private const int W = 5;

        private Vertex IncidentFrom { get; } // выходит(начало) 
        private Vertex IncidentTo { get; }   // входит (конец)
        private int Weight { get; }        // Вес
        private int SecondWeight { get; }        // Вес

        public Edge(Vertex incidentFrom, Vertex incidentTo, int weight)
        {
            IncidentFrom = incidentFrom;
            IncidentTo = incidentTo;
            Weight = weight;
            SecondWeight = int.MaxValue;
        }

        public Edge(Vertex incidentFrom, Vertex incidentTo, int weight, int secondWeight)
        {
            IncidentFrom = incidentFrom;
            IncidentTo = incidentTo;
            Weight = weight;
            SecondWeight = secondWeight;
        }

        public void Draw(Graphics graphics)
        {
            float halfRadius = Vertex.Radius / 2;
            float xCenterFrom = IncidentFrom.X + halfRadius;
            float yCenterFrom = IncidentFrom.Y + halfRadius;
            float xCenterTo = IncidentTo.X + halfRadius;
            float yCenterTo = IncidentTo.Y + halfRadius;

            float diffX = xCenterTo - xCenterFrom;
            float diffY = yCenterTo - yCenterFrom;
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);

            float xFrom = xCenterFrom + diffX / (float)distance * halfRadius;
            float yFrom = yCenterFrom + diffY / (float)distance * halfRadius;
            float xTo = xCenterTo - diffX / (float)distance * halfRadius;
            float yTo = yCenterTo - diffY / (float)distance * halfRadius;

            Pen pen = new Pen(Brushes.DeepSkyBlue, 2);
            graphics.DrawLine(pen, xFrom, yFrom, xTo, yTo);

            double crossX = xTo - diffX / distance * H;
            double crossY = yTo - diffY / distance * H;

            double leftX = crossX + (diffY / distance) * W;
            double leftY = crossY + (-diffX / distance) * W;
            double rightX = crossX - (diffY / distance) * W;
            double rightY = crossY - (-diffX / distance) * W;

            graphics.DrawLine(pen, xTo, yTo, (float)leftX, (float)leftY);
            graphics.DrawLine(pen, xTo, yTo, (float)rightX, (float)rightY);

            double centerX = (xFrom + xTo) / 2;
            double centerY = (yCenterFrom + yTo) / 2;

            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF((float)centerX, (float)centerY);

            if (SecondWeight != int.MaxValue)
            {
                string str = Weight.ToString() + "/" + SecondWeight.ToString();
                graphics.DrawString(str, drawFont, drawBrush, drawPoint);
            }
            else
                graphics.DrawString(Weight.ToString(), drawFont, drawBrush, drawPoint);
        }
    }
}
