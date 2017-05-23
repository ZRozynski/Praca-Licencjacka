using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class GraphManager
    {
        private int timeInterval = 200;
        private PictureBox _drawingPanel;
        private ListBox _graphInformation;
        private Thread algorithmThread;
        public GraphManager(PictureBox drawingPanel, ListBox graphInformation)
        {
            this._drawingPanel = drawingPanel;
            this._graphInformation = graphInformation;
            this.algorithmThread = new Thread(this.ProceedDijkstra);
        }

        public void RunAlgorithm()
        {
            this.algorithmThread = new Thread(this.ProceedDijkstra);
            this.algorithmThread.Start();
        }

        public void SetTimeInterval(int miliseconds)
        {
            this.timeInterval = miliseconds;
        }
        public void AddNewVertex(Point coordinates)
        {
            Graph graph = Graph.GetInstance();
            if (graph.GetVertexColliding(coordinates) == null)
            {
                graph.AddNewVertex(new Vertex(coordinates));
            }
        }

        public Vertex GetFocused()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {
                if (currentVertex.STATUS.Equals("FOCUSED"))
                    return currentVertex;
            }
            return null;
        }

        public void ClearFocused()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {
                if (currentVertex.STATUS.Equals("FOCUSED"))
                {
                    currentVertex.STATUS = "NORMAL";
                    this.ClearMarkedChildred(currentVertex);
                    break;
                }

            }
        }

        private void ClearMarkedChildred(Vertex marked)
        {
            while(marked.PARENT != null)
            {
                marked.PARENT.ALGORITHM_BOUND = false;
                marked = marked.PARENT;
            }
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

        public void MarkFocused(Vertex toBeMarked)
        {
            this.ClearFocused();
            toBeMarked.STATUS = "FOCUSED";
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
            this.ClearEdgesStatistics();
            this.ClearDrawingPanel();
            this.DrawEdges();
            this.DrawVertexes();
            this.DrawPointNumbers();
            this.DrawTravelCosts();
            this.Refresh();
        }

        private void ClearEdgesStatistics()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach(Vertex currentVertex in listedGraph)
            {
                List<Edge> neighbours = currentVertex.GetEdges();
                foreach(Edge neighbour in neighbours)
                {
                    neighbour._drawn = false;
                }
            }
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
            if (this._drawingPanel.InvokeRequired)
            {
                this._drawingPanel.Invoke(new Action(this.Refresh));
            }else this._drawingPanel.Refresh();
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
                    currentVertex._id = pointNumber;
                    Point currentCoords = currentVertex.GetVertexPosition();
                    currentCoords.X += 5; currentCoords.Y += 5;
                    numberDrawer.DrawString(pointNumber.ToString(), new Font("Verdana", 10), myPen, currentCoords,drawingFormat);
                }
            }
        }

        public void UpdateGraphInformation()
        {
            this._graphInformation.Items.Clear();
            Graph myGraph = Graph.GetInstance();
            List<Vertex> listedGraph = myGraph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {  
                this._graphInformation.Items.Add("ID: " + currentVertex._id + ", krawędzi: " + currentVertex.GetEdges().Count + ".");
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
                        if(currentEdge.GetDestination().GetEdgeByVertex(currentVertex) != null &&
                            currentEdge.GetDestination().GetEdgeByVertex(currentVertex)._textDrawn &&
                            !currentEdge.IsChild(currentVertex))
                                continue;
                        currentEdge._textDrawn = true;
                        Vertex destination = currentEdge.GetDestination();
                        if (currentEdge.IsChild(currentVertex) && (currentEdge.GetDestination().STATUS.Equals("FOCUSED") ||
                            currentEdge.GetDestination().ALGORITHM_BOUND))
                        {
                            myPen = new SolidBrush(Color.Green);
                        }
                        else myPen = new SolidBrush(Color.White);

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
                        currentEdge._drawn = true;
                        if (currentEdge.GetDestination().GetEdgeByVertex(currentVertex) != null &&
                            currentEdge.GetDestination().GetEdgeByVertex(currentVertex)._drawn &&
                            !currentEdge.IsChild(currentVertex))
                            continue;
                        Pen myPen;
                        if (currentEdge.IsChild(currentVertex) && (currentEdge.GetDestination().STATUS.Equals("FOCUSED") ||
                            currentEdge.GetDestination().ALGORITHM_BOUND))
                        {
                            myPen = new Pen(new SolidBrush(Color.Green), 5);
                        }
                        else
                        {
                            myPen = new Pen(new SolidBrush(Color.Black), 3);
                        }
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
            if (vertex.ALGORITHM_BOUND)
                return new SolidBrush(Color.Green);
            else if (vertex.STATUS.Equals("START"))
                return new SolidBrush(Color.Green);
            else if (vertex.STATUS.Equals("END"))
                return new SolidBrush(Color.Indigo);
            else if (vertex.STATUS.Equals("SELECTED"))
                return new SolidBrush(Color.Red);
            else if (vertex.STATUS.Equals("FOCUSED"))
                return new SolidBrush(Color.Green);
            else if (vertex.VISITED)
                return new SolidBrush(Color.Gray);
            else return new SolidBrush(Color.Black);
        }

        public void ClearGraph()
        {
            Graph graph = Graph.GetInstance();
            graph.ToVertexList().Clear();
        }

        public void ProceedDijkstra()
        {
            Vertex starting = this.GetStarting();
            Vertex ending = this.GetEnding();
            if(starting == null || ending == null)
            {
                MessageBox.Show("Parametry algorytmu nie zostały poprawnie ustawione.");
                return;
            }
            Graph graph = Graph.GetInstance();
            List<Vertex> graphListed = graph.ToVertexList();
            List<Vertex> prioryQueue = new List<Vertex>();
            for(int i = 0; i < graphListed.Count; i++)
            {
                Vertex current = graphListed.ElementAt(i);
                current.DISTANCE = Double.MaxValue;
                current.PARENT = null;
                current.VISITED = false;
                current.ALGORITHM_BOUND = false;
            }
            starting.DISTANCE = 0;
            prioryQueue.Add(starting);
            while(prioryQueue.Count != 0)
            {
                Vertex current = prioryQueue.First();
                current.VISITED = true;
                if (current == ending)
                {
                    this.MarkFocused(current);
                    this.MarkAllChildren(current);
                    this.Redraw();
                    break;
                }
                prioryQueue.Remove(current);
                List<Edge> currentNeighbours = current.GetEdges();
                for(int i = 0; i < currentNeighbours.Count; i++)
                {
                    Edge currentEdge = currentNeighbours.ElementAt(i);
                    Vertex neighbour = currentEdge.GetDestination();
                    if (neighbour.VISITED)
                        continue;
                    this.MarkFocused(neighbour);
                    if (current.DISTANCE + currentEdge.GetTravelCost() < neighbour.DISTANCE)
                    {
                        neighbour.DISTANCE = (current.DISTANCE + currentEdge.GetTravelCost());
                        neighbour.PARENT = current;
                        prioryQueue.Add(neighbour);
                        prioryQueue.Sort();
                        this.MarkAllChildren(neighbour);
                        Thread.Sleep(this.timeInterval);
                        this.Redraw();
                    }
                }
            }
            MessageBox.Show("Najkrótsza ścieżka: "+ Math.Round(ending.DISTANCE).ToString());
        }

        private void MarkAllChildren(Vertex focused)
        {
            while(focused.PARENT != null)
            {
                focused.PARENT.ALGORITHM_BOUND = true;
                focused = focused.PARENT;
            }
        }
    }
}
