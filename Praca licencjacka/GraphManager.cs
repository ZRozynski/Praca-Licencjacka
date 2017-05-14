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

        public Vertex GetSelected()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {
                if (currentVertex.STATUS.Equals("SELECTED"))
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

        public void MarkSelected(Point coordiantes)
        {
            Graph graph = Graph.GetInstance();
            Vertex toMark = null;
            if ((toMark = graph.GetVertexColliding(coordiantes)) != null)
            {
                toMark.STATUS = "SELECTED";
            }
        }

        public void Unmark(Vertex toUnmark)
        {
            if (toUnmark != null)
                toUnmark.STATUS = "NORMAL";
        }

        public void Redraw()
        {
            this.ClearDrawingPanel();
            this.DrawEdges();
            this.DrawVertexes();
            this.DrawPointNumbers();
            this.DrawTravelCosts();
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

        private void DrawPointNumbers()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            using(Graphics numberDrawer = Graphics.FromImage(this._drawingPanel.Image))
            {
                numberDrawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                Brush myPen = new SolidBrush(Color.White);
                StringFormat drawingFormat = new StringFormat();
                int pointNumber = 0;
                foreach(Vertex currentVertex in listedGraph)
                {
                    pointNumber++;
                    Point currentCoords = currentVertex.GetVertexPosition();
                    currentCoords.X += 5; currentCoords.Y += 5;
                    numberDrawer.DrawString(pointNumber.ToString(), new Font("Verdana", 10), myPen, currentCoords,drawingFormat);
                }
            }
        }

        public void DrawTravelCosts()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            using (Graphics costsDrawer = Graphics.FromImage(this._drawingPanel.Image))
            {
                Brush myPen = new SolidBrush(Color.White);
                Brush backGround = new SolidBrush(Color.Black);
                Font drawingFont = new Font("Arial", 14 , FontStyle.Bold);
                
                foreach(Vertex currentVertex in listedGraph)
                {
                    List<Edge> neighbours = currentVertex.GetEdges();
                    foreach(Edge currentEdge in neighbours)
                    {
                        Vertex destination = currentEdge.GetDestination();
                        double distance = currentEdge.GetTravelCost();
                        distance = Math.Round(distance);
                        Point drawingPosition = new Point();
                        drawingPosition.X = (currentVertex.GetX() + destination.GetX()) / 2;
                        drawingPosition.Y = (currentVertex.GetY() + destination.GetY()) / 2;
                        costsDrawer.FillRectangle(backGround, new Rectangle(drawingPosition.X, drawingPosition.Y, this.GetPixelsAmount((int)distance), 20));
                        costsDrawer.DrawString(distance.ToString(), drawingFont, myPen, drawingPosition, new StringFormat());
                    }
                }
            }
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

        private int GetPixelsAmount(int number)
        {
            int pixels = 0;
            while (true)
            {
                if ((number).Equals(0))
                    break;
                number = number / 10;
                pixels += 13;
            }
            return pixels;
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
                        Pen myPen = new Pen(new SolidBrush(Color.Black), 3);
                        Point startingPosition = currentVertex.GetVertexPosition();
                        Point endingPosition = currentEdge.GetDestination().GetVertexPosition();
                        startingPosition.X += 12; startingPosition.Y += 12;
                        endingPosition.X += 12; endingPosition.Y += 12;
                        edgeDrawer.DrawLine(myPen, startingPosition, endingPosition);
                    }
                }
            }
        }
        // Gets suitable for any Vertex Brush color
        private Brush GetSuitableBrush(Vertex vertex)
        {
            if (vertex.STATUS.Equals("NORMAL"))
                return new SolidBrush(Color.Black);
            else if (vertex.STATUS.Equals("START"))
                return new SolidBrush(Color.Green);
            else if (vertex.STATUS.Equals("END"))
                return new SolidBrush(Color.Indigo);
            else if (vertex.STATUS.Equals("SELECTED"))
                return new SolidBrush(Color.Red);
            else return new SolidBrush(Color.Gray);
        }

        public void ClearGraph()
        {
            Graph graph = Graph.GetInstance();
            graph.ToVertexList().Clear();
        }
    }
}
