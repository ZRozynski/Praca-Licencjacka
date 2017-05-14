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
        bool _mouseButtonClicked = false;
        bool _vertexSelected = false;

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
            clickedPoint.X -= 12;
            clickedPoint.Y -= 12;
            if (this.MODE.Equals("OPERATION"))
            {
                if(!this._vertexSelected)
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

        private void DrawingDesk_MouseUp(object sender, MouseEventArgs e)
        {
            Point clickedPoint = e.Location;
            clickedPoint.X -= 12;
            clickedPoint.Y -= 12;
            this._mouseButtonClicked = false;
            if (this._vertexSelected)
            {
                this._vertexSelected = false;
                Vertex selectedVertex = this._graphManager.GetSelected();
                Vertex draggedVertex = Graph.GetInstance().GetVertexColliding(clickedPoint);
                if(draggedVertex != null && selectedVertex != null)
                    selectedVertex.AddNewNeighbour(draggedVertex);
                this._graphManager.Unmark(selectedVertex);
            }
            this._graphManager.Redraw();

        }

        private void DrawingDesk_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._mouseButtonClicked && this._vertexSelected) {
 
                this._graphManager.Redraw();
                Vertex selected = this._graphManager.GetSelected();
                if (selected == null)
                    return;
                Point selectedPosition = selected.GetVertexPosition();
                this.DrawLine(selectedPosition, e.Location);
                Refresh();
            }  
        }

        private void DrawingDesk_MouseDown(object sender, MouseEventArgs e)
        {
            this._mouseButtonClicked = true;
            Point clickedPoint = e.Location;
            // Clicked position error avoidance.
            clickedPoint.X -= 12;
            clickedPoint.Y -= 12;
            Vertex colliding = Graph.GetInstance().GetVertexColliding(clickedPoint);
            if(colliding != null)
            {
                this._vertexSelected = true;
                if(!colliding.STATUS.Equals("START") && !colliding.STATUS.Equals("END"))
                    this._graphManager.MarkSelected(clickedPoint);
            }
            this._graphManager.Redraw();
        }

        public void DrawLine(Point first, Point second)
        {
            first.X += 12; first.Y += 12;
            using(Graphics myGraphics = Graphics.FromImage(this.DrawingDesk.Image))
            {
                Pen myPen = new Pen(new SolidBrush(Color.Green),5);
                myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                myGraphics.DrawLine(myPen, first, second);
            }
        }
    }
}
