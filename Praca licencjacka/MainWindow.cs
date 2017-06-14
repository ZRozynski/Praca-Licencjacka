using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private int _windowFontSize = 9;

        public MainWindow()
        {
            InitializeComponent();
            this.InitializeDrawingDesk();
            this.InitializeGraphManager();
            this.ChangeWindowFontSize();
        }

        private void InitializeDrawingDesk()
        {
            this.DrawingDesk.Image = new Bitmap(this.DrawingDesk.Width, this.DrawingDesk.Height);
            this.txtInterval.Text = "1000 milisekund.";
            this.chosenAlgorithmDijkstra.Checked = true;
        }
        private void InitializeGraphManager()
        {
            this._graphManager = new GraphManager(this.DrawingDesk, this.GraphInformation);
            this._graphManager.SetTimeInterval(this.intervalTB.Value);
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
                this._graphManager.Redraw();
                this._graphManager.UpdateGraphInformation();
            }
        }

        private void loadGraphFromFileBtn_Click(object sender, EventArgs e)
        {
            this._graphManager.ClearGraph();
            FileLoader fileLoader = new FileLoader();
            GraphLoader graphLoader = new GraphLoader();
            graphLoader.LoadGraphFromFileStream(fileLoader.ShowDialogAndGetSelectedFile());
            this._graphManager.Redraw();
            this._graphManager.UpdateGraphInformation();
            
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
                this._graphManager.MarkEnding (clickedPoint);
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
                if (draggedVertex != null && selectedVertex != null)
                {
                    if (e.Button.Equals(MouseButtons.Left))
                    {
                        selectedVertex.AddEdgeWithAutimaticDistanceCalculation(draggedVertex);
                    }
                    else if(e.Button.Equals(MouseButtons.Right))
                    {
                        double enteredCost = selectedVertex.
                            AddEdgeWithManualDistanceInsertionAndGetEnteredCost(draggedVertex);
                    }
                }
                this._graphManager.Unmark(selectedVertex);
            }
            this._graphManager.Redraw();
            this._graphManager.UpdateGraphInformation();

        }

        private void DrawingDesk_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._mouseButtonClicked && this._vertexSelected) {
                Vertex selected = this._graphManager.GetSelected();
                if (selected == null)
                    return;
                Point selectedPosition = selected.GetVertexPosition();
                this._graphManager.Redraw();
                this.DrawLine(selectedPosition, e.Location);
                this.RefreshDrawingDesk();
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
        }

        public void DrawLine(Point first, Point second)
        {
            first.X += 12; first.Y += 12;
            using(Graphics myGraphics = Graphics.FromImage(this.DrawingDesk.Image))
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(6, 6);
                Pen myPen = new Pen(new SolidBrush(Color.Gray),3);
                myPen.CustomEndCap = bigArrow;
                myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                myGraphics.DrawLine(myPen, first, second);
            }
        }

        private void saveGraphBtn_Click(object sender, EventArgs e)
        {
            GraphSaver gSaver = new GraphSaver();
            gSaver.SaveGraph();
        }

        private void beginBtn_Click(object sender, EventArgs e)
        {
            string algorithm = this.GetCheckedAlgorithm();
            this._graphManager.RunAlgorithm(algorithm);
        }

        private void intervalTB_ValueChanged(object sender, EventArgs e)
        {
            int value = this.intervalTB.Value;
            this.txtInterval.Text = value.ToString() + " milisekund.";
            this._graphManager.SetTimeInterval(value);
        }
        private string GetCheckedAlgorithm()
        {
            if (this.chosenAlgorithmDijkstra.Checked)
                return "DIJKSTRA";
            else if (this.chosenAlgorithmBFord.Checked)
                return "BFORD";
            else if (this.chosenAlgorithmFWarshall.Checked)
                return "FWARSHALL";
            else return String.Empty;
        }

        private void chosenAlgorithmDijkstra_CheckedChanged(object sender, EventArgs e)
        {
            if (chosenAlgorithmDijkstra.Checked)
            {
                chosenAlgorithmFWarshall.Checked = false;
                chosenAlgorithmBFord.Checked = false;
            }
        }

        private void chosenAlgorithmBFord_CheckedChanged(object sender, EventArgs e)
        {
            if (chosenAlgorithmBFord.Checked)
            {
                chosenAlgorithmDijkstra.Checked = false;
                chosenAlgorithmFWarshall.Checked = false;
            }
        }

        private void chosenAlgorithmFWarshall_CheckedChanged(object sender, EventArgs e)
        {
            if (chosenAlgorithmFWarshall.Checked)
            {
                chosenAlgorithmBFord.Checked = false;
                chosenAlgorithmDijkstra.Checked = false;
            }
        }

        private void ChangeWindowFontSize()
        {
            this.Font = new Font("Verdana", this._windowFontSize, FontStyle.Bold);
            this.chosenAlgorithmBFord.Font = new Font("Verdana", this._windowFontSize, FontStyle.Regular);
            this.chosenAlgorithmDijkstra.Font = new Font("Verdana", this._windowFontSize, FontStyle.Regular);
            this.chosenAlgorithmFWarshall.Font = new Font("Verdana", this._windowFontSize, FontStyle.Regular);
            this.LBL_INTERVAL.Font = new Font("Verdana", this._windowFontSize, FontStyle.Bold);
            this.txtInterval.Font = new Font("Verdana", this._windowFontSize, FontStyle.Bold); ;
            this.GraphInformation.Font = new Font("Verdana", this._windowFontSize, FontStyle.Regular); ;
        }

        private void changeFontBtn_Click(object sender, EventArgs e)
        {
            this._windowFontSize = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Podaj rozmiar czcionki(5 - 12):", "Zmień rozmiar czcionki.", "8"));
            if (this._windowFontSize < 5 || this._windowFontSize > 12)
            {
                MessageBox.Show("Niepoprawny rozmiar czcionki!");
                this._windowFontSize = 9;
            }
            this._graphManager.displayableFontSize = this._windowFontSize;
            this.ChangeWindowFontSize();
        }
    }
}
