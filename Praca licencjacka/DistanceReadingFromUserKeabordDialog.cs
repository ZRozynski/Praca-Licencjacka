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
    public partial class DistanceReadingFromUserKeabordDialog : Form
    {
        public double _wageEntered;
        public DistanceReadingFromUserKeabordDialog()
        {
            InitializeComponent();
            this.txtWage.Focus();
        }

        private double ConvertWageFromStringToDouble()
        {
            try
            {
                return Convert.ToDouble(this.txtWage.Text);
            }catch(FormatException formatException)
            {
                throw;
            }
        }

        private void acceptWageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this._wageEntered = this.ConvertWageFromStringToDouble();
                this.Hide();
            }
            catch(FormatException formatException)
            {
                MessageBox.Show("Niepoprawny format wpisanej wagi krawędzi!");
            }
        }
    }
}
