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
    public partial class AskingAboutGraphRemovalWindow : Form
    {
        private bool _remove;
        public AskingAboutGraphRemovalWindow()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            this._remove = true;
            this.Close();
        }

        public bool IsToRemove()
        {
            return this._remove;
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            this._remove = false;
            this.Close();
        }
    }
}
