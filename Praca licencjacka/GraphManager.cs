using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class GraphManager
    {
        private PictureBox _drawingPanel;
        public GraphManager(PictureBox drawingPanel)
        {
            this._drawingPanel = drawingPanel;
        }

        public void AddNewVertex(Point coordinates)
        {
            Graph graph = Graph.GetInstance();
            if (graph.GetVertexColliding(coordinates) == null)
                graph.AddNewVertex(new Vertex(coordinates));
        }

        public Vertex GetStarting()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach(Vertex currentVertex in listedGraph)
            {
                if (currentVertex.STATUS.Equals("START"))
                    return currentVertex;
            }
            return null;
        }

        public Vertex GetEnding()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {
                if (currentVertex.STATUS.Equals("END"))
                    return currentVertex;
            }
            return null;
        }

        public void MarkStarted(Point coordinates)
        {
            Graph graph = Graph.GetInstance();
            Vertex toMark = null;
            Vertex previousStarting = null;
            if ((previousStarting = this.GetStarting()) != null)
                previousStarting.STATUS = "NORMAL";
            if ((toMark = graph.GetVertexColliding(coordinates)) != null)
            {
                toMark.STATUS = "START";
            }
        }

        public void MarkEnding(Point coordiantes)
        {
            Graph graph = Graph.GetInstance();
            Vertex toMark = null;
            Vertex previousEnding = null;
            if ((previousEnding= this.GetEnding()) != null)
                previousEnding.STATUS = "NORMAL";
            if ((toMark = graph.GetVertexColliding(coordiantes)) != null)
            {
                toMark.STATUS = "END";
            }
        }

        public void Redraw()
        {
            this.ClearDrawingPanel();
            this.DrawEdges();
            this.DrawVertexes();
            this.Refresh();
        }

        private void ClearDrawingPanel()
        {
            using (Graphics myGraphics = Graphics.FromImage(this._drawingPanel.Image))
            {
                myGraphics.Clear(Color.Wheat);
            }
        }

        private void Refresh()
        {
            this._drawingPanel.Refresh();
        }

        private void DrawVertexes()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            using (Graphics vertexDrawer = Graphics.FromImage(this._drawingPanel.Image))
            {
                vertexDrawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                foreach (Vertex currentVertex in listedGraph)
                {
                    Brush suitableBrush = this.GetSuitableBrush(currentVertex);
                    int elipseSize = currentVertex.vertexSizeInPixels;
                    vertexDrawer.FillEllipse(suitableBrush, currentVertex.GetX(), currentVertex.GetY(), elipseSize, elipseSize);
                }
            }
        }

        private void DrawEdges()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();

            using (Graphics edgeDrawer = Graphics.FromImage(this._drawingPanel.Image))
            {
                edgeDrawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                foreach (Vertex currentVertex in listedGraph)
                {
                    List<Edge> neighbours = currentVertex.GetEdges();
                    foreach(Edge currentEdge in neighbours)
                    {
                        // TO CHANGE
                        edgeDrawer.DrawLine(Pens.Black, currentVertex.GetVertexPosition(), currentEdge.GetDestination().GetVertexPosition());
                    }
                }
            }
        }
        // Gets suitable for any Vertex Brush color
        private Brush GetSuitableBrush(Vertex vertex)
        {
            if (vertex.STATUS.Equals("NORMAL"))
                return new SolidBrush(Color.Black);
            else if(vertex.STATUS.Equals("START"))
                return new SolidBrush(Color.Green);
            else if (vertex.STATUS.Equals("END"))
                return new SolidBrush(Color.Indigo);
            else return new SolidBrush(Color.Gray);
        }

        public void ClearGraph()
        {
            Graph graph = Graph.GetInstance();
            graph.ToVertexList().Clear();
        }
    }
}
