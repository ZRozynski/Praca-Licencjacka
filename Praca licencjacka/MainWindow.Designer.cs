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
            this.choseStartingPointBtn = new System.Windows.Forms.Button();
            this.loadGraphFromFileBtn = new System.Windows.Forms.Button();
            this.beginBtn = new System.Windows.Forms.Button();
            this.chooseEndnigPointBtn = new System.Windows.Forms.Button();
            this.saveGraphBtn = new System.Windows.Forms.Button();
            this.clearDrawingDeskBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingDesk)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingDesk
            // 
            this.DrawingDesk.BackColor = System.Drawing.Color.Wheat;
            this.DrawingDesk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawingDesk.Location = new System.Drawing.Point(12, 12);
            this.DrawingDesk.Name = "DrawingDesk";
            this.DrawingDesk.Size = new System.Drawing.Size(1062, 618);
            this.DrawingDesk.TabIndex = 0;
            this.DrawingDesk.TabStop = false;
            this.DrawingDesk.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingDesk_MouseClick);
            this.DrawingDesk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingDesk_MouseDown);
            this.DrawingDesk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingDesk_MouseMove);
            this.DrawingDesk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingDesk_MouseUp);
            // 
            // GraphInformation
            // 
            this.GraphInformation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GraphInformation.FormattingEnabled = true;
            this.GraphInformation.ItemHeight = 16;
            this.GraphInformation.Location = new System.Drawing.Point(1081, 213);
            this.GraphInformation.Name = "GraphInformation";
            this.GraphInformation.Size = new System.Drawing.Size(294, 372);
            this.GraphInformation.TabIndex = 1;
            // 
            // choseStartingPointBtn
            // 
            this.choseStartingPointBtn.ForeColor = System.Drawing.Color.Green;
            this.choseStartingPointBtn.Location = new System.Drawing.Point(1081, 13);
            this.choseStartingPointBtn.Name = "choseStartingPointBtn";
            this.choseStartingPointBtn.Size = new System.Drawing.Size(294, 34);
            this.choseStartingPointBtn.TabIndex = 5;
            this.choseStartingPointBtn.Text = "Wybierz punkt startowy.";
            this.choseStartingPointBtn.UseVisualStyleBackColor = true;
            this.choseStartingPointBtn.Click += new System.EventHandler(this.choseStartingPointBtn_Click);
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
            // beginBtn
            // 
            this.beginBtn.Enabled = false;
            this.beginBtn.Location = new System.Drawing.Point(1081, 93);
            this.beginBtn.Name = "beginBtn";
            this.beginBtn.Size = new System.Drawing.Size(294, 34);
            this.beginBtn.TabIndex = 9;
            this.beginBtn.Text = "Rozpocznij!";
            this.beginBtn.UseVisualStyleBackColor = true;
            // 
            // chooseEndnigPointBtn
            // 
            this.chooseEndnigPointBtn.ForeColor = System.Drawing.Color.Indigo;
            this.chooseEndnigPointBtn.Location = new System.Drawing.Point(1081, 53);
            this.chooseEndnigPointBtn.Name = "chooseEndnigPointBtn";
            this.chooseEndnigPointBtn.Size = new System.Drawing.Size(294, 34);
            this.chooseEndnigPointBtn.TabIndex = 10;
            this.chooseEndnigPointBtn.Text = "Wybierz punkt końcowy.";
            this.chooseEndnigPointBtn.UseVisualStyleBackColor = true;
            this.chooseEndnigPointBtn.Click += new System.EventHandler(this.chooseEndnigPointBtn_Click);
            // 
            // saveGraphBtn
            // 
            this.saveGraphBtn.Location = new System.Drawing.Point(1080, 173);
            this.saveGraphBtn.Name = "saveGraphBtn";
            this.saveGraphBtn.Size = new System.Drawing.Size(294, 34);
            this.saveGraphBtn.TabIndex = 11;
            this.saveGraphBtn.Text = "Zapisz graf do pliku.\r\n";
            this.saveGraphBtn.UseVisualStyleBackColor = true;
            this.saveGraphBtn.Click += new System.EventHandler(this.saveGraphBtn_Click);
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
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1362, 641);
            this.Controls.Add(this.clearDrawingDeskBtn);
            this.Controls.Add(this.saveGraphBtn);
            this.Controls.Add(this.chooseEndnigPointBtn);
            this.Controls.Add(this.beginBtn);
            this.Controls.Add(this.loadGraphFromFileBtn);
            this.Controls.Add(this.choseStartingPointBtn);
            this.Controls.Add(this.GraphInformation);
            this.Controls.Add(this.DrawingDesk);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wizualizacja algorytmów wyszukiwania najkrótszej ścieżki w grafach ważonych.";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingDesk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawingDesk;
        private System.Windows.Forms.ListBox GraphInformation;
        private System.Windows.Forms.Button choseStartingPointBtn;
        private System.Windows.Forms.Button loadGraphFromFileBtn;
        private System.Windows.Forms.Button beginBtn;
        private System.Windows.Forms.Button chooseEndnigPointBtn;
        private System.Windows.Forms.Button saveGraphBtn;
        private System.Windows.Forms.Button clearDrawingDeskBtn;
    }
}

