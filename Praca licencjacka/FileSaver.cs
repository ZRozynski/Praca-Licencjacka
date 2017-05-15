using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class FileSaver
    {
        SaveFileDialog saveDialog;
        public FileSaver()
        {
            this.saveDialog = new SaveFileDialog();
            this.saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveDialog.FilterIndex = 2;
            this.saveDialog.Title = "Zapisz graf do pliku.";
            this.saveDialog.RestoreDirectory = true;     
        }
        public void SaveToFile(string content)
        {
            this.saveDialog.ShowDialog();
            if (!saveDialog.FileName.EndsWith(".txt"))
                saveDialog.FileName += ".txt";
            using(FileStream myFStream = (FileStream)saveDialog.OpenFile())
            {
                byte[] contentBytes = ASCIIEncoding.UTF8.GetBytes(content);
                myFStream.Write(contentBytes, 0, ASCIIEncoding.UTF8.GetByteCount(content));
                myFStream.Close();
            }
        }
    }
}
