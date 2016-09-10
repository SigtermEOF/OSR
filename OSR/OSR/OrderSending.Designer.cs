namespace OSR
{
    partial class OrderSending
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSending));
            this.txtboxRefNum = new System.Windows.Forms.TextBox();
            this.lblRefNum = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.rtxtNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboxType = new System.Windows.Forms.ComboBox();
            this.lblRetouchType = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.oSRDataSet = new OSR.OSRDataSet();
            this.oSRRetouchTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_RetouchTypeTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtboxRefNum
            // 
            this.txtboxRefNum.Location = new System.Drawing.Point(117, 32);
            this.txtboxRefNum.Name = "txtboxRefNum";
            this.txtboxRefNum.Size = new System.Drawing.Size(110, 20);
            this.txtboxRefNum.TabIndex = 0;
            // 
            // lblRefNum
            // 
            this.lblRefNum.AutoSize = true;
            this.lblRefNum.Location = new System.Drawing.Point(10, 35);
            this.lblRefNum.Name = "lblRefNum";
            this.lblRefNum.Size = new System.Drawing.Size(101, 13);
            this.lblRefNum.TabIndex = 1;
            this.lblRefNum.Text = "Production Number:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(894, 283);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(232, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(309, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(10, 67);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 5;
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNotes.Location = new System.Drawing.Point(697, 32);
            this.rtxtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.ReadOnly = true;
            this.rtxtNotes.Size = new System.Drawing.Size(210, 65);
            this.rtxtNotes.TabIndex = 6;
            this.rtxtNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(594, 57);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(90, 13);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Contractor Notes:";
            // 
            // cboxType
            // 
            this.cboxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxType.DataSource = this.oSRRetouchTypeBindingSource;
            this.cboxType.DisplayMember = "RetouchType_Descript";
            this.cboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxType.Enabled = false;
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Location = new System.Drawing.Point(697, 8);
            this.cboxType.Margin = new System.Windows.Forms.Padding(2);
            this.cboxType.Name = "cboxType";
            this.cboxType.Size = new System.Drawing.Size(210, 21);
            this.cboxType.TabIndex = 8;
            this.cboxType.ValueMember = "RetouchType_Code";
            // 
            // lblRetouchType
            // 
            this.lblRetouchType.AutoSize = true;
            this.lblRetouchType.Location = new System.Drawing.Point(555, 11);
            this.lblRetouchType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetouchType.Name = "lblRetouchType";
            this.lblRetouchType.Size = new System.Drawing.Size(130, 13);
            this.lblRetouchType.TabIndex = 9;
            this.lblRetouchType.Text = "Contractor Retouch Type:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(338, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(221, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // oSRDataSet
            // 
            this.oSRDataSet.DataSetName = "OSRDataSet";
            this.oSRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oSRRetouchTypeBindingSource
            // 
            this.oSRRetouchTypeBindingSource.DataMember = "OSR_RetouchType";
            this.oSRRetouchTypeBindingSource.DataSource = this.oSRDataSet;
            // 
            // oSR_RetouchTypeTableAdapter
            // 
            this.oSR_RetouchTypeTableAdapter.ClearBeforeFill = true;
            // 
            // OrderSending
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 381);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblRetouchType);
            this.Controls.Add(this.cboxType);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.rtxtNotes);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblRefNum);
            this.Controls.Add(this.txtboxRefNum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(932, 425);
            this.Name = "OrderSending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Order Queueing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderSending_FormClosing);
            this.Load += new System.EventHandler(this.OrderSending_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxRefNum;
        private System.Windows.Forms.Label lblRefNum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.RichTextBox rtxtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cboxType;
        private System.Windows.Forms.Label lblRetouchType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private OSRDataSet oSRDataSet;
        private System.Windows.Forms.BindingSource oSRRetouchTypeBindingSource;
        private OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter oSR_RetouchTypeTableAdapter;
    }
}