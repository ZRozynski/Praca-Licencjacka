namespace Praca_licencjacka
{
    partial class DistanceReadingFromUserKeabordDialog
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
            this.acceptWageBtn = new System.Windows.Forms.Button();
            this.LBL_WAGE = new System.Windows.Forms.Label();
            this.txtWage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // acceptWageBtn
            // 
            this.acceptWageBtn.ForeColor = System.Drawing.Color.Green;
            this.acceptWageBtn.Location = new System.Drawing.Point(202, 49);
            this.acceptWageBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acceptWageBtn.Name = "acceptWageBtn";
            this.acceptWageBtn.Size = new System.Drawing.Size(153, 28);
            this.acceptWageBtn.TabIndex = 0;
            this.acceptWageBtn.Text = "OK!";
            this.acceptWageBtn.UseVisualStyleBackColor = true;
            this.acceptWageBtn.Click += new System.EventHandler(this.acceptWageBtn_Click);
            // 
            // LBL_WAGE
            // 
            this.LBL_WAGE.AutoSize = true;
            this.LBL_WAGE.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LBL_WAGE.Location = new System.Drawing.Point(12, 18);
            this.LBL_WAGE.Name = "LBL_WAGE";
            this.LBL_WAGE.Size = new System.Drawing.Size(67, 18);
            this.LBL_WAGE.TabIndex = 1;
            this.LBL_WAGE.Text = "Waga: ";
            // 
            // txtWage
            // 
            this.txtWage.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtWage.Location = new System.Drawing.Point(98, 13);
            this.txtWage.Name = "txtWage";
            this.txtWage.Size = new System.Drawing.Size(257, 27);
            this.txtWage.TabIndex = 2;
            // 
            // DistanceReadingFromUserKeabordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(365, 82);
            this.Controls.Add(this.txtWage);
            this.Controls.Add(this.LBL_WAGE);
            this.Controls.Add(this.acceptWageBtn);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DistanceReadingFromUserKeabordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Podaj wagę!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptWageBtn;
        private System.Windows.Forms.Label LBL_WAGE;
        private System.Windows.Forms.TextBox txtWage;
    }
}