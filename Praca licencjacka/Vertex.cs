using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_licencjacka
{
    class Vertex : IComparable<Vertex>
    {
        private int _xPos;
        private int _yPos;
        private List<Edge> _neighbours;
        public int vertexSizeInPixels = 25;
        public string STATUS = "NORMAL";
        public bool ALGORITHM_BOUND = false; 
        public double DISTANCE;
        public Vertex PARENT;
        public bool VISITED;
        public int _id { set; get; }

        public bool IsChild(Vertex another)
        {
            return PARENT == another;
        }

        public Vertex(int xPos, int yPos)
        {
            this._xPos = xPos;
            this._yPos = yPos;
            this._neighbours = new List<Edge>();
            this._id = 0;
        }
        
        public Vertex(Point coordinates)
        {
            this._xPos = coordinates.X;
            this._yPos = coordinates.Y;
            this._neighbours = new List<Edge>();
        }

        public void SetPosition(int newXPos, int newYPos)
        {
            this._xPos = newXPos;
            this._yPos = newYPos;
        }

        public int GetX()
        {
            return this._xPos;
        }

        public bool IsColliding(Point coordinates)
        {
            return (coordinates.X <= this._xPos + this.vertexSizeInPixels && coordinates.X >= this._xPos - this.vertexSizeInPixels
                && coordinates.Y >= this._yPos - this.vertexSizeInPixels && coordinates.Y <= this._yPos + this.vertexSizeInPixels) ;
        }

        public int GetY()
        {
            return this._yPos;
        }

        public void AddEdgeWithAutimaticDistanceCalculation(Vertex neighbour)
        {
            if (this.Equals(neighbour) || this.GetEdgeByVertex(neighbour) != null)
                return;
            double distanceBetween = this.CalculateDistance(neighbour);
            this._neighbours.Add(new Edge(neighbour, distanceBetween));
        }

        public double AddEdgeWithManualDistanceInsertionAndGetEnteredCost(Vertex neighbour)
        {
            DistanceReadingFromUserKeabordDialog distanceReadingDialog = new DistanceReadingFromUserKeabordDialog();
            distanceReadingDialog.ShowDialog();
            double distanceBetween = distanceReadingDialog._userWageEntered;
            this._neighbours.Add(new Edge(neighbour, distanceBetween));
            return distanceBetween;
        }

        public void AddEdgeWithManualDistanceInsertion(Vertex neighbour, double distanceBetween)
        {
            this._neighbours.Add(new Edge(neighbour, distanceBetween));
        }

        public void RemoveAllNeighbours()
        {
            foreach(Edge currentNeighbour in this._neighbours)
            {
                Vertex destination = currentNeighbour.GetDestination();
                destination.RemoveNeighbour(this);
            }
        }

        public void RemoveNeighbour(Vertex neighbour)
        {
            Edge chosenNeighbour;
            if((chosenNeighbour = this.GetEdgeByVertex(neighbour)).Equals(null)){
                this._neighbours.Remove(chosenNeighbour);
            }
        }

        // After changing Vertex position it is very important to change travel costs to all it's neighbours
        private void RecalculateTravelCost()
        {
            //TODO
        }

        public Point GetVertexPosition()
        {
            return new Point(this._xPos, this._yPos);
        }

        public double CalculateDistance(Vertex destination)
        {
            double xDistance = Math.Pow(Math.Abs(this._xPos - destination.GetX()), 2);
            double yDistance = Math.Pow(Math.Abs(this._yPos - destination.GetY()), 2);
            double destinationDistance = Math.Sqrt(xDistance + yDistance);
            return destinationDistance;
        }

        public Edge GetEdgeByVertex(Vertex neighbour)
        {
            foreach(Edge currentNeighbour in this._neighbours)
            {
                if (currentNeighbour.GetDestination().Equals(neighbour))
                    return currentNeighbour;
            }
            return null;
        }

        public List<Edge> GetEdges()
        {
            return this._neighbours;
        }

        public int CompareTo(Vertex another)
        {
            return this.DISTANCE.CompareTo(another.DISTANCE);
        }
    }
}
