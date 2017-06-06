using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_licencjacka
{
    class GraphSaver
    {
        private FileSaver fSaver;
        public GraphSaver()
        {
            fSaver = new FileSaver();
        }
        public void SaveGraph()
        {
            string graphCommand = this.GetGraphCommand();
            this.fSaver.SaveToFile(graphCommand);
        }

        private string GetGraphCommand()
        {
            StringBuilder commandBuilder = new StringBuilder();
            Graph graph = Graph.GetInstance();
            List<Vertex> listedGraph = graph.ToVertexList();
            foreach(Vertex currentVertex in listedGraph)
            {
                commandBuilder.AppendLine("V:" + currentVertex.GetX() + ":" + currentVertex.GetY());
            }
            foreach(Vertex currentVertex in listedGraph)
            {
                List<Edge> neighbours = currentVertex.GetEdges();
                foreach(Edge currentNeighbour in neighbours)
                {
                    Vertex destination = currentNeighbour.GetDestination();
                    commandBuilder.AppendLine("E:" + currentVertex.GetX() + ":" + currentVertex.GetY() + 
                        ":" + destination.GetX() + ":" + destination.GetY() + ":"+ currentNeighbour.GetTravelCost());
                }
            }
            return commandBuilder.ToString();
        }
    }
}
