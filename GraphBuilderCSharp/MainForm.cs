using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilderCSharp
{
    public partial class MainForm : Form
    {
        private int maxWidth;
        private int maxHeight;

        NodeManager Manager { get; } = new NodeManager();

        private Vertex MovingVertex { get; set; }
        private int DifferenceX { get; set; }
        private int DifferenceY { get; set; }

        public MainForm()
        {
            InitializeComponent();
            maxWidth = GraphFieldPanel.Width - Vertex.Radius;
            maxHeight = GraphFieldPanel.Height - Vertex.Radius;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void GraphFieldPanel_Paint(object sender, PaintEventArgs e)
        {
            Manager.Paint(e.Graphics);
        }

        private void Redraw()
        {
            maxWidth = GraphFieldPanel.Width - Vertex.Radius;
            maxHeight = GraphFieldPanel.Height - Vertex.Radius;
            GraphFieldPanel.Invalidate();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\voval\\Desktop\\1.txt";// "c:\\";
                openFileDialog.Filter = @"Text files(*.txt)|*.txt|DIMACS files(*.clq)|*.clq|All files(*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;   //Get the path of specified file
                else
                    return;
            }

            Manager.LoadTxtFormatGraph(filePath);
            Redraw();
        }

        private int GetMouseX()
        {
            return MousePosition.X - Location.X - GraphFieldPanel.Location.X - 10; // extraX;
        }

        private int GetMouseY()
        {
            return MousePosition.Y - Location.Y - GraphFieldPanel.Location.Y - 30; // extraY;
        }

        private void GraphFieldPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (MovingVertex == null)
                return;

            MovingVertex.X = GetMouseX() - DifferenceX;
            MovingVertex.Y = GetMouseY() - DifferenceY;

            if (MovingVertex.X < 0)
                MovingVertex.X = 0;

            if (MovingVertex.Y < 0)
                MovingVertex.Y = 0;

            if (MovingVertex.X > maxWidth)
                MovingVertex.X = maxWidth - 1;

            if (MovingVertex.Y > maxHeight)
                MovingVertex.Y = maxHeight - 1;

            Redraw();
        }

        private void GraphFieldPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = GetMouseX();
            int mouseY = GetMouseY();

            MovingVertex = Manager.GetMovingVertex(mouseX, mouseY);
            if (MovingVertex != null)
            {
                DifferenceX = mouseX - MovingVertex.X;
                DifferenceY = mouseY - MovingVertex.Y;
            }
        }

        private void GraphFieldPanel_MouseUp(object sender, MouseEventArgs e)
        {
            MovingVertex = null;
        }

        private void MainForm_AutoSizeChanged(object sender, EventArgs e)
        {
            GraphFieldPanel.Height = GraphFieldPanel.Height;
        }
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);
        }
    }
}
