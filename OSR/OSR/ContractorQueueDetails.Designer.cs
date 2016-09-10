namespace OSR
{
    partial class ContractorQueueDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractorQueueDetails));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oSRContractorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.osrDataSet1 = new OSR.OSRDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_OrdersTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_OrdersTableAdapter();
            this.oSR_ContractorTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ContractorTableAdapter();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_ErrorsTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ErrorsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRContractorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // oSRContractorBindingSource
            // 
            this.oSRContractorBindingSource.DataMember = "OSR_Contractor";
            this.oSRContractorBindingSource.DataSource = this.osrDataSet1;
            // 
            // osrDataSet1
            // 
            this.osrDataSet1.DataSetName = "OSRDataSet";
            this.osrDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "OSR_Orders";
            this.bindingSource1.DataSource = this.osrDataSet1;
            // 
            // oSR_OrdersTableAdapter
            // 
            this.oSR_OrdersTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_ContractorTableAdapter
            // 
            this.oSR_ContractorTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "OSR_Errors";
            this.bindingSource2.DataSource = this.osrDataSet1;
            // 
            // oSR_ErrorsTableAdapter
            // 
            this.oSR_ErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // ContractorQueueDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 299);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1098, 338);
            this.MinimumSize = new System.Drawing.Size(1098, 338);
            this.Name = "ContractorQueueDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Contractor Order Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContractorQueueDetails_FormClosed);
            this.Load += new System.EventHandler(this.ContractorQueueDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRContractorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrCodeDataGridViewTextBoxColumn;
        private OSRDataSet osrDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OSRDataSetTableAdapters.OSR_OrdersTableAdapter oSR_OrdersTableAdapter;
        private System.Windows.Forms.BindingSource oSRContractorBindingSource;
        private OSRDataSetTableAdapters.OSR_ContractorTableAdapter oSR_ContractorTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private OSRDataSetTableAdapters.OSR_ErrorsTableAdapter oSR_ErrorsTableAdapter;
    }
}