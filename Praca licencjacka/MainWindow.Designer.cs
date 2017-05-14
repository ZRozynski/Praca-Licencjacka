namespace Praca_licencjacka
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.DrawingDesk = new System.Windows.Forms.PictureBox();
            this.GraphInformation = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loadGraphFromFileBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.clearDrawingDeskBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingDesk)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingDesk
            // 
            this.DrawingDesk.BackColor = System.Drawing.Color.Wheat;
            this.DrawingDesk.Location = new System.Drawing.Point(12, 12);
            this.DrawingDesk.Name = "DrawingDesk";
            this.DrawingDesk.Size = new System.Drawing.Size(1062, 618);
            this.DrawingDesk.TabIndex = 0;
            this.DrawingDesk.TabStop = false;
            // 
            // GraphInformation
            // 
            this.GraphInformation.FormattingEnabled = true;
            this.GraphInformation.ItemHeight = 18;
            this.GraphInformation.Location = new System.Drawing.Point(1081, 213);
            this.GraphInformation.Name = "GraphInformation";
            this.GraphInformation.Size = new System.Drawing.Size(294, 382);
            this.GraphInformation.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(1081, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Wybierz punkt startowy.";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // loadGraphFromFileBtn
            // 
            this.loadGraphFromFileBtn.Location = new System.Drawing.Point(1080, 133);
            this.loadGraphFromFileBtn.Name = "loadGraphFromFileBtn";
            this.loadGraphFromFileBtn.Size = new System.Drawing.Size(294, 34);
            this.loadGraphFromFileBtn.TabIndex = 8;
            this.loadGraphFromFileBtn.Text = "Wczytaj z pliku.\r\n";
            this.loadGraphFromFileBtn.UseVisualStyleBackColor = true;
            this.loadGraphFromFileBtn.Click += new System.EventHandler(this.loadGraphFromFileBtn_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(1081, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(294, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "Rozpocznij!";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Indigo;
            this.button4.Location = new System.Drawing.Point(1081, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(294, 34);
            this.button4.TabIndex = 10;
            this.button4.Text = "Wybierz punkt końcowy.";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1080, 173);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(294, 34);
            this.button6.TabIndex = 11;
            this.button6.Text = "Zapisz graf do pliku.\r\n";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // clearDrawingDeskBtn
            // 
            this.clearDrawingDeskBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.clearDrawingDeskBtn.Location = new System.Drawing.Point(1081, 596);
            this.clearDrawingDeskBtn.Name = "clearDrawingDeskBtn";
            this.clearDrawingDeskBtn.Size = new System.Drawing.Size(294, 34);
            this.clearDrawingDeskBtn.TabIndex = 12;
            this.clearDrawingDeskBtn.Text = "Wyczyść planszę.";
            this.clearDrawingDeskBtn.UseVisualStyleBackColor = true;
            this.clearDrawingDeskBtn.Click += new System.EventHandler(this.clearDrawingDeskBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1387, 641);
            this.Controls.Add(this.clearDrawingDeskBtn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.loadGraphFromFileBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GraphInformation);
            this.Controls.Add(this.DrawingDesk);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "MainWindow";
            this.Text = "Wizualizacja algorytmów wyszukiwania najkrótszej ścieżki w grafach ważonych.";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingDesk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawingDesk;
        private System.Windows.Forms.ListBox GraphInformation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loadGraphFromFileBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button clearDrawingDeskBtn;
    }
}

