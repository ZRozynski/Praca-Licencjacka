using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_licencjacka
{
    class Graph
    {
        private static Graph _instance;
        private List<Vertex> _graph;

        public void AddNewVertex(Vertex newVertex)
        {
            this._graph.Add(newVertex);
        }

        public void RemoveVertex(Vertex toRemove)
        {
            toRemove.RemoveAllNeighbours();
            this._graph.Remove(toRemove);       
        }
    
        public Vertex GetVertexColliding(Point coordinates)
        {
            foreach(Vertex currentVertex in this._graph)
            {
                if (currentVertex.IsColliding(coordinates))
                    return currentVertex;
            }
            return null;
        }

        private Graph()
        {
            this._graph = new List<Vertex>();
        }

        public static Graph GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Graph();
                return _instance;
            }
            return _instance;
        }

        public List<Vertex> ToVertexList()
        {
            return this._graph;
        }
    }
}
