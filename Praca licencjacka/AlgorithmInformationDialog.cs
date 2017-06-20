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
    public partial class AlgorithmInformationDialog : Form
    {
        private double[,] _adjacencyMatrix;
        public bool isFinishedByUser = false;
        public bool isSkippedByUser = false;
        public AlgorithmInformationDialog(double [,] adjacencyMatrix, int fontSize)
        {
            InitializeComponent();
            this._adjacencyMatrix = adjacencyMatrix;
            this.Font = new Font("Verdana", fontSize, FontStyle.Bold);
            this.LBL_QUESTION1.Font = LBL_QUESTION2.Font = LBL_QUESTION3.Font = new Font("Verdana", fontSize, FontStyle.Bold);
            this.IDFirst2.Font = IDThirth2.Font = new Font("Verdana", fontSize, FontStyle.Bold);
            this.answer.Font = new Font("Verdana", fontSize, FontStyle.Bold);
        }

        public void ShowCurrentAlgorithmProcess(int firstID, int secondID, int thirthID)
        {
            this.DisplayCurrentVertexesIDs(firstID, secondID, thirthID);
            this.DisplayNecessaryTravelCosts(firstID, secondID, thirthID);
        }

        private void DisplayCurrentVertexesIDs(int firstID, int secondID, int thirthID)
        {
            this.currentVertexesTXT.Text = firstID.ToString() + ", " + secondID.ToString() + ", oraz " + thirthID.ToString();
            this.IDFirst1.Text = firstID.ToString(); this.IDFirst2.Text = firstID.ToString();
            this.IDSecond1.Text = secondID.ToString(); this.IDSecond2.Text = secondID.ToString();
            this.IDThirth1.Text = thirthID.ToString(); this.IDThirth2.Text = thirthID.ToString();
            this.ineqFirst.Text = firstID.ToString();
            this.ineqThirth.Text = thirthID.ToString();
        }

        private void DisplayNecessaryTravelCosts(int firstID, int secondID, int thirthID)
        {
            double firstCost = Math.Round(this._adjacencyMatrix[firstID-1, secondID-1]);
            double secondCost = Math.Round(this._adjacencyMatrix[secondID - 1, thirthID - 1]);
            double finalCost = Math.Round(this._adjacencyMatrix[firstID - 1, thirthID - 1]);

         
            this.travelCostFirst.Text = firstCost.ToString();
            this.TravelCostSecond.Text = secondCost.ToString();
            if (!this.isInfinity(finalCost))
            {
                this.finalTravelCost.Text = finalCost.ToString();
            }
            else finalTravelCost.Text = "INF";
            this.ineqFirst.Text = firstCost.ToString();
            this.ineqThirth.Text = secondCost.ToString();
        }

        public void ShowAnswer(bool isPositiveAnswer)
        {
            if (isPositiveAnswer)
            {
                this.answer.ForeColor = Color.Green;
                this.answer.Text = "TAK! Więc zostaje ona zastąpiona drogą o mniejszym koszcie.";
            }else
            {
                this.answer.ForeColor = Color.Red;
                this.answer.Text = "NIE! Więc następuje przejście do następnego kroku.";
            }
        }

        private bool isInfinity(double value)
        {
            return value.Equals(Double.MaxValue);
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            this.isFinishedByUser = true;
            this.Hide();
        }

        private void skipAllBtn_Click(object sender, EventArgs e)
        {
            this.isSkippedByUser = true;
            this.Hide();
        }
    }
}
