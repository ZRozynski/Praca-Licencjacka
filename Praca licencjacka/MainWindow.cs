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
        GraphManager _graphManager;
        string MODE = "OPERATION";
        public MainWindow()
        {
            InitializeComponent();
            this.InitializeDrawingDesk();
            this.InitializeGraphManager();
        }

        private void InitializeDrawingDesk()
        {
            this.DrawingDesk.Image = new Bitmap(this.DrawingDesk.Width, this.DrawingDesk.Height);
        }
        private void InitializeGraphManager()
        {
            this._graphManager = new GraphManager(this.DrawingDesk);
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
                this._graphManager.ClearGraph();
                this.ClearDrawingDesk();
            }
        }

        private void loadGraphFromFileBtn_Click(object sender, EventArgs e)
        {
            FileLoader fileLoader = new FileLoader();
            GraphLoader graphLoader = new GraphLoader();
            graphLoader.LoadGraphFromFileStream(fileLoader.ShowDialogAndGetSelectedFile());
        }

        private void DrawingDesk_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickedPoint = e.Location;
            // Clicked position error avoidance.
            clickedPoint.X -= 12;
            clickedPoint.Y -= 12;
            if (this.MODE.Equals("OPERATION"))
            {
                this._graphManager.AddNewVertex(clickedPoint);
            }
            if (this.MODE.Equals("MARK_STARTING"))
            {
                this._graphManager.MarkStarted(clickedPoint);
                this.MODE = "OPERATION";
            }
            if (this.MODE.Equals("MARK_ENDING"))
            {
                this._graphManager.MarkEnding(clickedPoint);
                this.MODE = "OPERATION";
            }
            this._graphManager.Redraw();
        }

        private void choseStartingPointBtn_Click(object sender, EventArgs e)
        {
            this.MODE = "MARK_STARTING";
        }

        private void chooseEndnigPointBtn_Click(object sender, EventArgs e)
        {
            this.MODE = "MARK_ENDING";
        }
    }
}
