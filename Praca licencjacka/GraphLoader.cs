using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class GraphLoader
    {
        public GraphLoader()
        {}
        public void LoadGraphFromFileStream(Stream graphStream)
        {
            try
            {
                using (BinaryReader binaryReader = new BinaryReader(graphStream))
                {
                    byte[] streamBytes = binaryReader.ReadBytes((int)graphStream.Length);
                    string[] graphInputLines = ASCIIEncoding.UTF8.GetString(streamBytes).Split('\n');
                    this.InterpreteCommands(graphInputLines);
                }
            }catch(ArgumentNullException argNullExc)
            {
                //TODO
            }
        }

        private void InterpreteCommands(string[] inputCommands)
        {
            Graph graph = Graph.GetInstance();
            foreach(string singleLine in inputCommands)
            {
                if (singleLine.Equals(String.Empty))
                    continue;
                if (singleLine.Contains("V"))
                {
                    this.AddVertex(singleLine);
                }
                else this.AddNeighbour(singleLine);
            }
        }

        private void AddVertex(string vertexInfo)
        {
            Graph graph = Graph.GetInstance();
            string[] parameters = vertexInfo.Split(':');
            int paramX = Convert.ToInt32(parameters[1]);
            int paramY = Convert.ToInt32(parameters[2]);
            graph.AddNewVertex(new Vertex(new Point(paramX, paramY)));
        }

        private void AddNeighbour(string neighbourInfo)
        {
            Graph graph = Graph.GetInstance();
            string[] parameters = neighbourInfo.Split(':');
            int firstX = Convert.ToInt32(parameters[1]);
            int firstY = Convert.ToInt32(parameters[2]);
            int secondX = Convert.ToInt32(parameters[3]);
            int secondY = Convert.ToInt32(parameters[4]);
            Point first = new Point(firstX, firstY);
            Point second = new Point(secondX, secondY);
            Vertex fVertex = graph.GetVertexColliding(first);
            Vertex sVertex = graph.GetVertexColliding(second);
            fVertex.AddNewNeighbour(sVertex);
        }
    }
}
