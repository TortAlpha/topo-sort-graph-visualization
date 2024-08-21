using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Lab15
{
    public partial class Form1 : Form
    {
        Graph graph { get; set; } = new Graph();


        Pen nodePen = new Pen(Color.Black, 4);
        Pen edgePen = new Pen(Color.Black, 2);
        Brush nodeBackGroundBrush = Brushes.Black; 

        Node currentlyDraggableNode = null;
        Node currentSourceNode = null;

        const int node_size = 25;

        Graphics g;

        Point newEdgePoint;


        public Form1()
        {
            InitializeComponent();
        }

        private void addNodeButton_Click(object sender, EventArgs e)
        {
            Node newNode = new Node(graph.GetGlobalId() + 1);
            Random rnd = new Random();
            newNode.position = new Point(rnd.Next(0, 1000), rnd.Next(0, 500));
            graph.AddNode(newNode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;


            Bitmap buffer = new Bitmap(Width, Height);
            g = Graphics.FromImage(buffer);
            g.Clear(Color.White);

            foreach (var node in graph.nodes)
            {
                foreach (var edge in node.edges)
                {
                    var first_point = new Point(edge.Source.position.X + 12, edge.Source.position.Y + 12);
                    var second_point = new Point(edge.Target.position.X + 12, edge.Target.position.Y + 12);

                    g.DrawLine(edgePen, first_point, second_point);
              

                    float angle = (float)(Math.Atan2(second_point.Y - first_point.Y, second_point.X - first_point.X) * 180 / Math.PI);
                   
                    float arrowSize = 10;
                    float endX = second_point.X - arrowSize * (float)Math.Cos(angle * Math.PI / 180);
                    float endY = second_point.Y - arrowSize * (float)Math.Sin(angle * Math.PI / 180);

                 
                    Pen arrowPen = new Pen(Color.Black);    
                    AdjustableArrowCap arrowCap = new AdjustableArrowCap(arrowSize, arrowSize, true);
                    arrowPen.CustomEndCap = arrowCap;
                    g.DrawLine(arrowPen, first_point, new Point((int)endX, (int)endY));

                }
            }

            foreach (var node in graph.nodes)
            {
                
                g.DrawEllipse(nodePen, node.position.X, node.position.Y, node_size, node_size);
                g.FillEllipse(nodeBackGroundBrush, node.position.X, node.position.Y, node_size, node_size);
                g.DrawString($"{node.Id}", new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point), Brushes.White, new Point(node.position.X + 6, node.position.Y + 3));
            }

            if (currentSourceNode != null)
            {
                var temp = new Point(currentSourceNode.position.X + 8, currentSourceNode.position.Y + 8);
                g.DrawLine(edgePen, temp, newEdgePoint);
            }

            
            pictureBox1.Image = buffer;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            var mouse_position = e.Location;
            if (currentlyDraggableNode != null && e.Button == MouseButtons.Left)
            {
                currentlyDraggableNode = null;
            }
            if (currentSourceNode != null && e.Button == MouseButtons.Right)
            {
                foreach (var node in graph.nodes)
                {
                    if (new Rectangle(node.position.X, node.position.Y, node_size, node_size).Contains(mouse_position))
                    {
                        node.AddEdgeFrom(currentSourceNode);
                    }
                }
                currentSourceNode = null;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var mouse_position = e.Location;

            {
                foreach (var node in graph.nodes)
                {
                    if (new Rectangle(node.position.X, node.position.Y, node_size, node_size).Contains(mouse_position))
                    {
                        if (currentlyDraggableNode == null && e.Button == MouseButtons.Left)
                        {
                            currentlyDraggableNode = node;
                        }
                        if (currentSourceNode == null && e.Button == MouseButtons.Right)
                        {
                            currentSourceNode = node;
                        }
                    }
                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var mouse_position = e.Location;
            if (currentlyDraggableNode != null)
            {
                currentlyDraggableNode.position = new Point(mouse_position.X - 12, mouse_position.Y - 12);
            }
            if (currentSourceNode != null)
            {
                newEdgePoint = mouse_position;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter("C:\\Users\\romanavanesov\\source\\repos\\Lab15\\Lab15\\G.grf");
                graph.SaveToFile(streamWriter);
                streamWriter.Close();


                MessageBox.Show(
                    "Graph successfully saved.",
                    "Saving",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                throw;
            }
            

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader streamReader = new StreamReader("C:\\Users\\romanavanesov\\source\\repos\\Lab15\\Lab15\\G.grf");
                graph = Graph.LoadFromFile(streamReader);
                streamReader.Close();

                MessageBox.Show(
                    "Graph successfully loaded.",
                    "Loading",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                throw;
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            var sortedGraph = graph.TopoSort();

            if (sortedGraph == null) { sortedTextBox.Text = "Graph is no acyclic!"; return;  }

            var result = "";
            for (int i = 0; i < sortedGraph.Count; ++i)
            {
                if (i != sortedGraph.Count - 1) result += $"{sortedGraph[i].Id},";
                else result += $"{sortedGraph[i].Id}";
            }
            sortedTextBox.Text = result;
        }
    }
}
