namespace OSR
{
    partial class HeadCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadCount));
            this.btnCount = new System.Windows.Forms.Button();
            this.txtBoxCount = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(139, 153);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 1;
            this.btnCount.Text = "Enter";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.Location = new System.Drawing.Point(129, 127);
            this.txtBoxCount.Name = "txtBoxCount";
            this.txtBoxCount.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCount.TabIndex = 0;
            this.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(116, 111);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(127, 13);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Number of heads over 2: ";
            // 
            // HeadCount
            // 
            this.AcceptButton = this.btnCount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 286);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtBoxCount);
            this.Controls.Add(this.btnCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(375, 325);
            this.MinimumSize = new System.Drawing.Size(375, 325);
            this.Name = "HeadCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "O.S.R. Head Count";
            this.Load += new System.EventHandler(this.HeadCount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.TextBox txtBoxCount;
        private System.Windows.Forms.Label lblText;
    }
}