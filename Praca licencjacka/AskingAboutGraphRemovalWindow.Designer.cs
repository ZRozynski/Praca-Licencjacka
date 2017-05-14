namespace Praca_licencjacka
{
    partial class AskingAboutGraphRemovalWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AskingAboutGraphRemovalWindow));
            this.YesBtn = new System.Windows.Forms.Button();
            this.NoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YesBtn
            // 
            this.YesBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.YesBtn.Location = new System.Drawing.Point(12, 12);
            this.YesBtn.Name = "YesBtn";
            this.YesBtn.Size = new System.Drawing.Size(162, 39);
            this.YesBtn.TabIndex = 0;
            this.YesBtn.Text = "Tak.";
            this.YesBtn.UseVisualStyleBackColor = true;
            this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
            // 
            // NoBtn
            // 
            this.NoBtn.ForeColor = System.Drawing.Color.Green;
            this.NoBtn.Location = new System.Drawing.Point(180, 12);
            this.NoBtn.Name = "NoBtn";
            this.NoBtn.Size = new System.Drawing.Size(162, 39);
            this.NoBtn.TabIndex = 1;
            this.NoBtn.Text = "Nie.";
            this.NoBtn.UseVisualStyleBackColor = true;
            this.NoBtn.Click += new System.EventHandler(this.NoBtn_Click);
            // 
            // AskingAboutGraphRemovalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(354, 62);
            this.Controls.Add(this.NoBtn);
            this.Controls.Add(this.YesBtn);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "AskingAboutGraphRemovalWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Czy jestes pewny/pewna?";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button YesBtn;
        private System.Windows.Forms.Button NoBtn;
    }
}