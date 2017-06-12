using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_licencjacka
{
    class Edge
    {
        public bool _drawn = false;
        public bool _textDrawn = false;
        private Vertex _destinationVertex;
        private double _travelCost;

        public Edge(Vertex destination, double travelCost)
        {
            this._destinationVertex = destination;
            this._travelCost = travelCost;
        }

        public void SetDestinationAndCost(Vertex destination, double travelCost)
        {
            this._destinationVertex = destination;
            this._travelCost = travelCost;
        }

        public void SetTravelCost(double travelCost)
        {
            this._travelCost = travelCost;
        }

        public double GetTravelCost()
        {
            return this._travelCost;
        }

        public bool IsParent(Vertex possibleParent)
        {
            return this._destinationVertex.IsParent(possibleParent);
        }
        public bool CanBeDrawn(Vertex destination)
        {
            return !(this.GetDestination().GetEdgeByVertex(destination) != null &&
                    this.GetDestination().GetEdgeByVertex(destination)._drawn &&
                    !this.IsParent(destination));
        }
        public Vertex GetDestination()
        {
            return this._destinationVertex;
        }
    }
}
