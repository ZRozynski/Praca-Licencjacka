using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    class FileLoader
    {
        private OpenFileDialog _fileLoadingDialog;
        private Stream _fileContentStream;
        public FileLoader()
        {
            this._fileLoadingDialog = new OpenFileDialog();
            this._fileLoadingDialog.InitialDirectory = "c:\\";
            this._fileLoadingDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this._fileLoadingDialog.FilterIndex = 2;
            this._fileLoadingDialog.Title = "Wczytaj graf z pliku.";
            this._fileLoadingDialog.RestoreDirectory = true;
        }
        public Stream ShowDialogAndGetSelectedFile()
        {
            if (this._fileLoadingDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((this._fileContentStream = this._fileLoadingDialog.OpenFile()) != null)
                        return _fileContentStream;
                }
                catch (IOException IoException)
                {
                    MessageBox.Show("Błąd wczytywania pliku.");
                }
            }
            return null;
        }
    }
}
