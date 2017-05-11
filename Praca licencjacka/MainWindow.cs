using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_licencjacka
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.InitializeDrawingDesk();
        }

        private void InitializeDrawingDesk()
        {
            this.DrawingDesk.Image = new Bitmap(this.DrawingDesk.Width, this.DrawingDesk.Height);
        }

        private void RefreshDrawingDesk()
        {
            this.DrawingDesk.Refresh();
        }

        private void ClearDrawingDesk()
        {
            using(Graphics myGraphics = Graphics.FromImage(this.DrawingDesk.Image))
            {
                myGraphics.Clear(Color.Wheat);
                this.RefreshDrawingDesk();
            }
        }

        private void clearDrawingDeskBtn_Click(object sender, EventArgs e)
        {
            AskingAboutGraphRemovalWindow askingWindow = new AskingAboutGraphRemovalWindow();
            askingWindow.ShowDialog();
            if (askingWindow.IsToRemove())
            {
                this.ClearDrawingDesk();
            }
        }

        private void loadGraphFromFileBtn_Click(object sender, EventArgs e)
        {
            FileLoader fileLoader = new FileLoader();
            GraphLoader graphLoader = new GraphLoader();
            graphLoader.LoadGraphFromFileStream(fileLoader.ShowDialogAndGetSelectedFile());
        }
    }
}
