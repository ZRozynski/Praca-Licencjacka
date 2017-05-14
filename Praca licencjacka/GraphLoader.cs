using System;
using System.Collections.Generic;
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
                }
            }catch(ArgumentNullException argNullExc)
            {
                //TODO
            }
        }
    }
}
