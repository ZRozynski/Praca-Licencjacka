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
            this.intervalTB = new System.Windows.Forms.TrackBar();
            this.LBL_INTERVAL = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.Label();
            this.chosenAlgorithmDijkstra = new System.Windows.Forms.CheckBox();
            this.chosenAlgorithmBFord = new System.Windows.Forms.CheckBox();
            this.chosenAlgorithmFWarshall = new System.Windows.Forms.CheckBox();
            this.changeFontBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingDesk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTB)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingDesk
            // 
            this.DrawingDesk.BackColor = System.Drawing.Color.Wheat;
            this.DrawingDesk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawingDesk.Location = new System.Drawing.Point(12, 41);
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
            this.GraphInformation.Location = new System.Drawing.Point(1081, 242);
            this.GraphInformation.Name = "GraphInformation";
            this.GraphInformation.Size = new System.Drawing.Size(294, 404);
            this.GraphInformation.TabIndex = 1;
            // 
            // choseStartingPointBtn
            // 
            this.choseStartingPointBtn.ForeColor = System.Drawing.Color.Chocolate;
            this.choseStartingPointBtn.Location = new System.Drawing.Point(1081, 41);
            this.choseStartingPointBtn.Name = "choseStartingPointBtn";
            this.choseStartingPointBtn.Size = new System.Drawing.Size(294, 34);
            this.choseStartingPointBtn.TabIndex = 5;
            this.choseStartingPointBtn.Text = "Wybierz punkt startowy.";
            this.choseStartingPointBtn.UseVisualStyleBackColor = true;
            this.choseStartingPointBtn.Click += new System.EventHandler(this.choseStartingPointBtn_Click);
            // 
            // loadGraphFromFileBtn
            // 
            this.loadGraphFromFileBtn.Location = new System.Drawing.Point(1080, 162);
            this.loadGraphFromFileBtn.Name = "loadGraphFromFileBtn";
            this.loadGraphFromFileBtn.Size = new System.Drawing.Size(294, 34);
            this.loadGraphFromFileBtn.TabIndex = 8;
            this.loadGraphFromFileBtn.Text = "Wczytaj z pliku.\r\n";
            this.loadGraphFromFileBtn.UseVisualStyleBackColor = true;
            this.loadGraphFromFileBtn.Click += new System.EventHandler(this.loadGraphFromFileBtn_Click);
            // 
            // beginBtn
            // 
            this.beginBtn.Location = new System.Drawing.Point(1081, 122);
            this.beginBtn.Name = "beginBtn";
            this.beginBtn.Size = new System.Drawing.Size(294, 34);
            this.beginBtn.TabIndex = 9;
            this.beginBtn.Text = "Rozpocznij!";
            this.beginBtn.UseVisualStyleBackColor = true;
            this.beginBtn.Click += new System.EventHandler(this.beginBtn_Click);
            // 
            // chooseEndnigPointBtn
            // 
            this.chooseEndnigPointBtn.ForeColor = System.Drawing.Color.Indigo;
            this.chooseEndnigPointBtn.Location = new System.Drawing.Point(1081, 82);
            this.chooseEndnigPointBtn.Name = "chooseEndnigPointBtn";
            this.chooseEndnigPointBtn.Size = new System.Drawing.Size(294, 34);
            this.chooseEndnigPointBtn.TabIndex = 10;
            this.chooseEndnigPointBtn.Text = "Wybierz punkt końcowy.";
            this.chooseEndnigPointBtn.UseVisualStyleBackColor = true;
            this.chooseEndnigPointBtn.Click += new System.EventHandler(this.chooseEndnigPointBtn_Click);
            // 
            // saveGraphBtn
            // 
            this.saveGraphBtn.Location = new System.Drawing.Point(1080, 202);
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
            this.clearDrawingDeskBtn.Location = new System.Drawing.Point(1081, 653);
            this.clearDrawingDeskBtn.Name = "clearDrawingDeskBtn";
            this.clearDrawingDeskBtn.Size = new System.Drawing.Size(294, 34);
            this.clearDrawingDeskBtn.TabIndex = 12;
            this.clearDrawingDeskBtn.Text = "Wyczyść planszę.";
            this.clearDrawingDeskBtn.UseVisualStyleBackColor = true;
            this.clearDrawingDeskBtn.Click += new System.EventHandler(this.clearDrawingDeskBtn_Click);
            // 
            // intervalTB
            // 
            this.intervalTB.LargeChange = 100;
            this.intervalTB.Location = new System.Drawing.Point(12, 665);
            this.intervalTB.Maximum = 2000;
            this.intervalTB.Name = "intervalTB";
            this.intervalTB.Size = new System.Drawing.Size(349, 45);
            this.intervalTB.SmallChange = 25;
            this.intervalTB.TabIndex = 13;
            this.intervalTB.Value = 1000;
            this.intervalTB.ValueChanged += new System.EventHandler(this.intervalTB_ValueChanged);
            // 
            // LBL_INTERVAL
            // 
            this.LBL_INTERVAL.AutoSize = true;
            this.LBL_INTERVAL.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_INTERVAL.Location = new System.Drawing.Point(367, 668);
            this.LBL_INTERVAL.Name = "LBL_INTERVAL";
            this.LBL_INTERVAL.Size = new System.Drawing.Size(78, 16);
            this.LBL_INTERVAL.TabIndex = 14;
            this.LBL_INTERVAL.Text = "Interwał: ";
            // 
            // txtInterval
            // 
            this.txtInterval.AutoSize = true;
            this.txtInterval.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtInterval.Location = new System.Drawing.Point(445, 668);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(0, 16);
            this.txtInterval.TabIndex = 15;
            // 
            // chosenAlgorithmDijkstra
            // 
            this.chosenAlgorithmDijkstra.AutoSize = true;
            this.chosenAlgorithmDijkstra.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chosenAlgorithmDijkstra.Location = new System.Drawing.Point(577, 667);
            this.chosenAlgorithmDijkstra.Name = "chosenAlgorithmDijkstra";
            this.chosenAlgorithmDijkstra.Size = new System.Drawing.Size(106, 20);
            this.chosenAlgorithmDijkstra.TabIndex = 16;
            this.chosenAlgorithmDijkstra.Text = "Alg. Dijkstry";
            this.chosenAlgorithmDijkstra.UseVisualStyleBackColor = true;
            this.chosenAlgorithmDijkstra.CheckedChanged += new System.EventHandler(this.chosenAlgorithmDijkstra_CheckedChanged);
            // 
            // chosenAlgorithmBFord
            // 
            this.chosenAlgorithmBFord.AutoSize = true;
            this.chosenAlgorithmBFord.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chosenAlgorithmBFord.Location = new System.Drawing.Point(689, 667);
            this.chosenAlgorithmBFord.Name = "chosenAlgorithmBFord";
            this.chosenAlgorithmBFord.Size = new System.Drawing.Size(158, 20);
            this.chosenAlgorithmBFord.TabIndex = 17;
            this.chosenAlgorithmBFord.Text = "Alg. Bellmana-Forda";
            this.chosenAlgorithmBFord.UseVisualStyleBackColor = true;
            this.chosenAlgorithmBFord.CheckedChanged += new System.EventHandler(this.chosenAlgorithmBFord_CheckedChanged);
            // 
            // chosenAlgorithmFWarshall
            // 
            this.chosenAlgorithmFWarshall.AutoSize = true;
            this.chosenAlgorithmFWarshall.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chosenAlgorithmFWarshall.Location = new System.Drawing.Point(853, 667);
            this.chosenAlgorithmFWarshall.Name = "chosenAlgorithmFWarshall";
            this.chosenAlgorithmFWarshall.Size = new System.Drawing.Size(169, 20);
            this.chosenAlgorithmFWarshall.TabIndex = 18;
            this.chosenAlgorithmFWarshall.Text = "Alg. Floyda-Warshalla";
            this.chosenAlgorithmFWarshall.UseVisualStyleBackColor = true;
            this.chosenAlgorithmFWarshall.CheckedChanged += new System.EventHandler(this.chosenAlgorithmFWarshall_CheckedChanged);
            // 
            // changeFontBtn
            // 
            this.changeFontBtn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeFontBtn.Location = new System.Drawing.Point(12, 11);
            this.changeFontBtn.Name = "changeFontBtn";
            this.changeFontBtn.Size = new System.Drawing.Size(199, 24);
            this.changeFontBtn.TabIndex = 19;
            this.changeFontBtn.Text = "Zmień rozmiar czcionki!";
            this.changeFontBtn.UseVisualStyleBackColor = true;
            this.changeFontBtn.Click += new System.EventHandler(this.changeFontBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1385, 694);
            this.Controls.Add(this.changeFontBtn);
            this.Controls.Add(this.chosenAlgorithmFWarshall);
            this.Controls.Add(this.chosenAlgorithmBFord);
            this.Controls.Add(this.chosenAlgorithmDijkstra);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.LBL_INTERVAL);
            this.Controls.Add(this.intervalTB);
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
            ((System.ComponentModel.ISupportInitialize)(this.intervalTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TrackBar intervalTB;
        private System.Windows.Forms.Label LBL_INTERVAL;
        private System.Windows.Forms.Label txtInterval;
        private System.Windows.Forms.CheckBox chosenAlgorithmDijkstra;
        private System.Windows.Forms.CheckBox chosenAlgorithmBFord;
        private System.Windows.Forms.CheckBox chosenAlgorithmFWarshall;
        private System.Windows.Forms.Button changeFontBtn;
    }
}

