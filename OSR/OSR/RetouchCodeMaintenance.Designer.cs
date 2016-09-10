namespace OSR
{
    partial class RetouchCodeMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetouchCodeMaintenance));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.retouchCodesCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retouchCodesLabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retouchCodesDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retouchTypeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.oSRDataSet = new OSR.OSRDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_RetouchCodesTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchCodesTableAdapter();
            this.oSR_RetouchTypeTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.retouchCodesCodeDataGridViewTextBoxColumn,
            this.retouchCodesLabelDataGridViewTextBoxColumn,
            this.retouchCodesDescriptionDataGridViewTextBoxColumn,
            this.retouchTypeCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(553, 410);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // retouchCodesCodeDataGridViewTextBoxColumn
            // 
            this.retouchCodesCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.retouchCodesCodeDataGridViewTextBoxColumn.DataPropertyName = "RetouchCodes_Code";
            this.retouchCodesCodeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.retouchCodesCodeDataGridViewTextBoxColumn.Name = "retouchCodesCodeDataGridViewTextBoxColumn";
            this.retouchCodesCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.retouchCodesCodeDataGridViewTextBoxColumn.Width = 57;
            // 
            // retouchCodesLabelDataGridViewTextBoxColumn
            // 
            this.retouchCodesLabelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.retouchCodesLabelDataGridViewTextBoxColumn.DataPropertyName = "RetouchCodes_Label";
            this.retouchCodesLabelDataGridViewTextBoxColumn.HeaderText = "Label";
            this.retouchCodesLabelDataGridViewTextBoxColumn.Name = "retouchCodesLabelDataGridViewTextBoxColumn";
            this.retouchCodesLabelDataGridViewTextBoxColumn.ReadOnly = true;
            this.retouchCodesLabelDataGridViewTextBoxColumn.Width = 58;
            // 
            // retouchCodesDescriptionDataGridViewTextBoxColumn
            // 
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.DataPropertyName = "RetouchCodes_Description";
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.Name = "retouchCodesDescriptionDataGridViewTextBoxColumn";
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.retouchCodesDescriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // retouchTypeCodeDataGridViewTextBoxColumn
            // 
            this.retouchTypeCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.retouchTypeCodeDataGridViewTextBoxColumn.DataPropertyName = "RetouchType_Code";
            this.retouchTypeCodeDataGridViewTextBoxColumn.DataSource = this.bindingSource2;
            this.retouchTypeCodeDataGridViewTextBoxColumn.DisplayMember = "RetouchType_Descript";
            this.retouchTypeCodeDataGridViewTextBoxColumn.HeaderText = "RetouchType_Code";
            this.retouchTypeCodeDataGridViewTextBoxColumn.Name = "retouchTypeCodeDataGridViewTextBoxColumn";
            this.retouchTypeCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.retouchTypeCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.retouchTypeCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.retouchTypeCodeDataGridViewTextBoxColumn.ValueMember = "RetouchType_Code";
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "OSR_RetouchType";
            this.bindingSource2.DataSource = this.oSRDataSet;
            // 
            // oSRDataSet
            // 
            this.oSRDataSet.DataSetName = "OSRDataSet";
            this.oSRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "OSR_RetouchCodes";
            this.bindingSource1.DataSource = this.oSRDataSet;
            // 
            // oSR_RetouchCodesTableAdapter
            // 
            this.oSR_RetouchCodesTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_RetouchTypeTableAdapter
            // 
            this.oSR_RetouchTypeTableAdapter.ClearBeforeFill = true;
            // 
            // RetouchCodeMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 410);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RetouchCodeMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Retouch Code Maintenance";
            this.Load += new System.EventHandler(this.RetouchCodeMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private OSRDataSet oSRDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OSRDataSetTableAdapters.OSR_RetouchCodesTableAdapter oSR_RetouchCodesTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter oSR_RetouchTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn retouchCodesCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retouchCodesLabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retouchCodesDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn retouchTypeCodeDataGridViewTextBoxColumn;
    }
}