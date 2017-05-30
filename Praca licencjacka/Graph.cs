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
        public Vertex GetVertexById(int vertexId)
        {
            foreach(Vertex currentVertex in this._graph)
            {
                if (currentVertex._id.Equals(vertexId))
                    return currentVertex;
            }
            return null;
        }

        public List<Vertex> ToVertexList()
        {
            return this._graph;
        }

        public double [,] GetAdjacencyMatrix()
        {
            int graphSize = this._graph.Count;
            double[,] adjacencyMatrix = new double[graphSize, graphSize];
            for(int i = 0; i < graphSize; i++)
            {
                Vertex currentVertex = this.GetVertexById(i + 1);
                for (int j = 0; j < graphSize; j++)
                {
                    if (i.Equals(j))
                    {
                        adjacencyMatrix[i, j] = 0;
                        continue;
                    }

                    adjacencyMatrix[i, j] = Double.MaxValue;
                    Vertex possibleDestination = this.GetVertexById(j + 1);
                    Edge possibleEdge = currentVertex.GetEdgeByVertex(possibleDestination);
                    if (possibleEdge != null)
                    {
                        adjacencyMatrix[i, j] = possibleEdge.GetTravelCost();
                        adjacencyMatrix[j, i] = possibleEdge.GetTravelCost();
                    }
                }
                adjacencyMatrix[i, i] = 0;
            }
            return adjacencyMatrix;
        }
        public int GetSize()
        {
            return this._graph.Count();
        }
    }
}
