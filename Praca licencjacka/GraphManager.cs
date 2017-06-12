using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class GraphManager
    {
        public int displayableFontSize = 12;
        private int timeInterval = 100;
        private PictureBox _drawingPanel;
        private ListBox _graphInformation;
        private Thread algorithmThread;
        public GraphManager(PictureBox drawingPanel, ListBox graphInformation)
        {
            this._drawingPanel = drawingPanel;
            this._graphInformation = graphInformation;
            this.algorithmThread = new Thread(this.ProceedDijkstra);
        }

        public void RunAlgorithm(string algorithmName)
        {
            if (algorithmName.Equals("DIJKSTRA"))
            {
                this.algorithmThread = new Thread(this.ProceedDijkstra);
            }
            else if (algorithmName.Equals("BFORD"))
            {
                this.algorithmThread = new Thread(this.ProceedBellmanFord);
            }
            else if (algorithmName.Equals("FWARSHALL"))
            {
                this.algorithmThread = new Thread(this.ProceedFloydWarshall);
            }
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
            if (this.ContainsInstanceLoop(marked))
            {
                return;
            }
            while(marked.PARENT != null)
            {
                marked.PARENT.ALGORITHM_BOUND = false;
                marked = marked.PARENT;
            }
        }

        private int GetGraphSize()
        {
            Graph graph = Graph.GetInstance();
            return graph.GetSize();
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

        private void ClearVertexesStatistics()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach (Vertex currentVertex in listedGraph)
            {
                currentVertex.ALGORITHM_BOUND = false;
                currentVertex.DISTANCE = Double.MaxValue;
                currentVertex.PARENT = null;
                currentVertex.VISITED = false;
                currentVertex.DISTANCE = Double.MaxValue;
            }
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
            this.ClearTravelCostStatistics();
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
                        if (!currentEdge.CanBeDrawn(currentVertex))
                            continue;
                        currentEdge._textDrawn = true;
                        Vertex destination = currentEdge.GetDestination();
                        if (currentEdge.IsParent(currentVertex) && (currentEdge.GetDestination().STATUS.Equals("FOCUSED") ||
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
            if (number < 0)
                pixels = pixels + 13;
            while (true)
            {
                if ((number).Equals(0))
                    break;
                number = number / 10;
                pixels += 13;
            }
            return pixels;
        }

        private void DrawEdgeDirectionOnly(Vertex beggining, Edge edge)
        {
            Pen myPen = new Pen(new SolidBrush(Color.Gray), 3);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(6, 6);
            myPen.CustomEndCap = bigArrow;
            Point startingPosition = beggining.GetVertexPosition();
            Point endingPosition = edge.GetDestination().GetVertexPosition();
            startingPosition.X += 12; startingPosition.Y += 12;
            endingPosition.X += 12; endingPosition.Y += 12;
            using(Graphics myGraphics = Graphics.FromImage(this._drawingPanel.Image))
            {
                myGraphics.SmoothingMode = SmoothingMode.HighQuality;
                myGraphics.DrawLine(myPen, startingPosition, endingPosition);
            }
        }
        private bool IsAlgorithmBound(Vertex vertex, Edge edge)
        {
            return (edge.IsParent(vertex) && (edge.GetDestination().STATUS.Equals("FOCUSED") ||
                            edge.GetDestination().ALGORITHM_BOUND));
        }

        private void DrawEdges()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(6, 6);
            using (Graphics edgeDrawer = Graphics.FromImage(this._drawingPanel.Image))
            {
                edgeDrawer.SmoothingMode = SmoothingMode.HighQuality;
                foreach (Vertex currentVertex in listedGraph)
                {
                    List<Edge> neighbours = currentVertex.GetEdges();
                    foreach(Edge currentEdge in neighbours)
                    {
                        if (!currentEdge.CanBeDrawn(currentVertex))
                        {
                            continue;
                        }
                        currentEdge._drawn = true;
                        Pen myPen = Pens.Black; 
                        if (this.IsAlgorithmBound(currentVertex,currentEdge))
                        {
                            myPen = new Pen(new SolidBrush(Color.Green), 3);
                        }
                        else
                        {
                            myPen = new Pen(new SolidBrush(Color.Gray), 3);
                        }
                        myPen.CustomEndCap = bigArrow;
                        Point startingPosition = currentVertex.GetVertexPosition();
                        Point endingPosition = currentEdge.GetDestination().GetVertexPosition();
                        startingPosition.X += 12; startingPosition.Y += 12;
                        endingPosition.X += 12; endingPosition.Y += 12;
                        Vertex neighbour = currentEdge.GetDestination();
                        Edge reversedEdge = neighbour.GetEdgeByVertex(currentVertex);
                        if(neighbour != null && reversedEdge != null)
                            this.DrawEdgeDirectionOnly(neighbour, reversedEdge);
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
                return new SolidBrush(Color.Chocolate);
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
            if(!ending.DISTANCE.Equals(Double.MaxValue))
                MessageBox.Show("Najkrótsza ścieżka: "+ Math.Round(ending.DISTANCE).ToString());
            else MessageBox.Show("Ścieżka nie istnieje!");
            this.ClearEdgesStatistics();
            this.ClearVertexesStatistics();
            this.MarkEnding(ending.GetVertexPosition());
        }

        public void ProceedFloydWarshall()
        {
            this.ClearVertexesStatistics();
            double[,] adjacencyMatrix = Graph.GetInstance().GetAdjacencyMatrix();
            int graphSize = Graph.GetInstance().GetSize();
            AlgorithmInformationDialog algInfoDialog = new AlgorithmInformationDialog(adjacencyMatrix,this.displayableFontSize);
            for (int k = 0; k < graphSize; k++)
            {
                for(int i = 0; i < graphSize; i++)
                {
                    for(int j = 0; j < graphSize; j++)
                    {
                        if (algInfoDialog.isfinishedByUser)
                            return;
                        if (adjacencyMatrix[k, j].Equals(Double.MaxValue) || adjacencyMatrix[i, k].Equals(Double.MaxValue))
                            continue;
                        algInfoDialog.ShowCurrentAlgorithmProcess(i + 1, k + 1, j + 1);
                        Vertex first, second, third;
                        first = Graph.GetInstance().GetVertexById(k + 1);
                        second = Graph.GetInstance().GetVertexById(i + 1);
                        third = Graph.GetInstance().GetVertexById(j + 1);

                        first.ALGORITHM_BOUND = true;
                        second.ALGORITHM_BOUND = true;
                        third.ALGORITHM_BOUND = true;

                        double actualValue = Math.Round(adjacencyMatrix[i, j]);
                        double proposedValue = Math.Round((adjacencyMatrix[i, k] +
                            adjacencyMatrix[k, j]));
                        if (actualValue > proposedValue)
                        {
                            algInfoDialog.ShowAnswer(true);
                            adjacencyMatrix[i, j] = proposedValue;
                        }
                        else algInfoDialog.ShowAnswer(false);

                        this.Redraw();
                        first.ALGORITHM_BOUND = false;
                        second.ALGORITHM_BOUND = false;
                        third.ALGORITHM_BOUND = false;
                        if(!algInfoDialog.isSkippedByUser)
                            algInfoDialog.ShowDialog();
                        Thread.Sleep(this.timeInterval);
                    }
                }
            }
            int startingID = this.GetStarting()._id;
            int endingID = this.GetEnding()._id;
            double travelCost = adjacencyMatrix[startingID - 1, endingID - 1];
            if (!travelCost.Equals(Double.MaxValue))
                MessageBox.Show("Najkrótsza ścieżka: " + Math.Round(travelCost).ToString());
            else MessageBox.Show("Ścieżka nie istnieje!");
            this.ClearEdgesStatistics();
            this.ClearVertexesStatistics();
        }

        public void ProceedBellmanFord()
        {
            this.ClearVertexesStatistics();
            List<Vertex> listedGraph = Graph.GetInstance().ToVertexList();
            Vertex starting = this.GetStarting();
            Vertex ending = this.GetEnding();
            starting.DISTANCE = 0;

            int graphSize = this.GetGraphSize();
            for (int i = 1; i < graphSize; i++)
            {
                bool test = true;
                foreach (Vertex currentVertex in listedGraph)
                {
                    List<Edge> neighbours = currentVertex.GetEdges();
                    foreach (Edge currentNeighbour in neighbours)
                    {
                        this.MarkFocused(currentNeighbour.GetDestination());
                        double currentValue = currentNeighbour.GetDestination().DISTANCE;
                        double proposedValue = currentVertex.DISTANCE + currentNeighbour.GetTravelCost();
                        if (currentValue <= proposedValue)
                            continue;
                        test = false;
                        currentNeighbour.GetDestination().DISTANCE = proposedValue;
                        currentNeighbour.GetDestination().PARENT = currentVertex;
                        this.MarkAllChildren(currentNeighbour.GetDestination());
                        this.Redraw();
                        Thread.Sleep(this.timeInterval);
                    }
                }
                this.MarkEnding(ending.GetVertexPosition());
                this.MarkStarted(starting.GetVertexPosition());
                if (test)
                {
                    this.MarkStarted(starting.GetVertexPosition());
                    this.MarkFocused(ending);
                    this.MarkAllChildren(ending);
                    this.Redraw();
                    this.MarkEnding(ending.GetVertexPosition());
                    if (!ending.DISTANCE.Equals(Double.MaxValue))
                        MessageBox.Show("Najktótsza ścieżka: " + Math.Round(this.GetEnding().DISTANCE).ToString());
                    else MessageBox.Show("Ścieżka nie istnieje!");
                    this.ClearVertexesStatistics();
                    return;
                }
            }
            foreach (Vertex currentVertex in listedGraph)
            {
                List<Edge> neighbours = currentVertex.GetEdges();
                foreach (Edge currentNeighbour in neighbours)
                {
                    if(currentNeighbour.GetDestination().DISTANCE > currentVertex.DISTANCE + currentNeighbour.GetTravelCost())
                    {
                        MessageBox.Show("W grafie znajdują się ujemne cykle, wynik może być niepoprawny!");
                        this.ClearVertexesStatistics();
                        this.Redraw();
                        return;
                    }
                }
            }
        }
        private void MarkAllChildren(Vertex focused)
        {
            if (this.ContainsInstanceLoop(focused))
                return;
            while(focused.PARENT != null)
            {
                focused.PARENT.ALGORITHM_BOUND = true;
                focused = focused.PARENT;
            }
        }

        private bool ContainsInstanceLoop(Vertex focused)
        {
            List<int> existingIDs = new List<int>();
            existingIDs.Add(focused._id); 
            while(focused.PARENT != null)
            {
                focused = focused.PARENT;
                if (existingIDs.Contains(focused._id))
                    return true;
                existingIDs.Add(focused._id);
            }
            existingIDs.Clear();
            return false;
        }
  
        private void ClearTravelCostStatistics()
        {
            Graph graph = Graph.GetInstance();
            List<Vertex> graphListed = graph.ToVertexList();
            foreach(Vertex currentVertex in graphListed)
            {
                List<Edge> neighbours = currentVertex.GetEdges();
                foreach(Edge currentEdge in neighbours)
                {
                    currentEdge._textDrawn = false;
                }
            }
        }

        public double[,] GetAdjacenyMatrix()
        {
            return Graph.GetInstance().GetAdjacencyMatrix();
        }
    }
}
