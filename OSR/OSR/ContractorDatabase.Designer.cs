namespace OSR
{
    partial class ContractorDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractorDatabase));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cntrctrIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrFNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrLNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrAdd1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrAdd2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statesIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.oSRStatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.osrDataSet1 = new OSR.OSRDataSet();
            this.cntrctrZipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrEmail1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrEmail2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrPhone1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carriers_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.oSRCarriersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cntrctrPhone2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntrctrMaxFilesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeStatusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.oSRActiveStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.retouchTypeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.oSRRetouchTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cntrctrCreatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cntrctr_DeactivatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cntrctr_ReactivatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_ContractorTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ContractorTableAdapter();
            this.oSR_StatesTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_StatesTableAdapter();
            this.oSR_ActiveStatusTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ActiveStatusTableAdapter();
            this.oSR_RetouchTypeTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter();
            this.oSR_CarriersTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_CarriersTableAdapter();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_ErrorsTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ErrorsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRStatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRCarriersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRActiveStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cntrctrIDDataGridViewTextBoxColumn,
            this.cntrctrFNameDataGridViewTextBoxColumn,
            this.cntrctrLNameDataGridViewTextBoxColumn,
            this.cntrctrAdd1DataGridViewTextBoxColumn,
            this.cntrctrAdd2DataGridViewTextBoxColumn,
            this.cntrctrCityDataGridViewTextBoxColumn,
            this.statesIDDataGridViewTextBoxColumn,
            this.cntrctrZipDataGridViewTextBoxColumn,
            this.cntrctrEmail1DataGridViewTextBoxColumn,
            this.cntrctrEmail2DataGridViewTextBoxColumn,
            this.cntrctrPhone1DataGridViewTextBoxColumn,
            this.Carriers_ID,
            this.cntrctrPhone2DataGridViewTextBoxColumn,
            this.cntrctrMaxFilesDataGridViewTextBoxColumn,
            this.activeStatusCodeDataGridViewTextBoxColumn,
            this.retouchTypeCodeDataGridViewTextBoxColumn,
            this.cntrctrCreatedDateDataGridViewTextBoxColumn,
            this.Cntrctr_DeactivatedDate,
            this.Cntrctr_ReactivatedDate});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1261, 320);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // cntrctrIDDataGridViewTextBoxColumn
            // 
            this.cntrctrIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrIDDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_ID";
            this.cntrctrIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.cntrctrIDDataGridViewTextBoxColumn.Name = "cntrctrIDDataGridViewTextBoxColumn";
            this.cntrctrIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrIDDataGridViewTextBoxColumn.Width = 43;
            // 
            // cntrctrFNameDataGridViewTextBoxColumn
            // 
            this.cntrctrFNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrFNameDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_FName";
            this.cntrctrFNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.cntrctrFNameDataGridViewTextBoxColumn.Name = "cntrctrFNameDataGridViewTextBoxColumn";
            this.cntrctrFNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrFNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // cntrctrLNameDataGridViewTextBoxColumn
            // 
            this.cntrctrLNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrLNameDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_LName";
            this.cntrctrLNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.cntrctrLNameDataGridViewTextBoxColumn.Name = "cntrctrLNameDataGridViewTextBoxColumn";
            this.cntrctrLNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrLNameDataGridViewTextBoxColumn.Width = 77;
            // 
            // cntrctrAdd1DataGridViewTextBoxColumn
            // 
            this.cntrctrAdd1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrAdd1DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Add1";
            this.cntrctrAdd1DataGridViewTextBoxColumn.HeaderText = "Address 1";
            this.cntrctrAdd1DataGridViewTextBoxColumn.Name = "cntrctrAdd1DataGridViewTextBoxColumn";
            this.cntrctrAdd1DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrAdd1DataGridViewTextBoxColumn.Width = 73;
            // 
            // cntrctrAdd2DataGridViewTextBoxColumn
            // 
            this.cntrctrAdd2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrAdd2DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Add2";
            this.cntrctrAdd2DataGridViewTextBoxColumn.HeaderText = "Address 2";
            this.cntrctrAdd2DataGridViewTextBoxColumn.Name = "cntrctrAdd2DataGridViewTextBoxColumn";
            this.cntrctrAdd2DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrAdd2DataGridViewTextBoxColumn.Width = 73;
            // 
            // cntrctrCityDataGridViewTextBoxColumn
            // 
            this.cntrctrCityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrCityDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_City";
            this.cntrctrCityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cntrctrCityDataGridViewTextBoxColumn.Name = "cntrctrCityDataGridViewTextBoxColumn";
            this.cntrctrCityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrCityDataGridViewTextBoxColumn.Width = 49;
            // 
            // statesIDDataGridViewTextBoxColumn
            // 
            this.statesIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statesIDDataGridViewTextBoxColumn.DataPropertyName = "States_ID";
            this.statesIDDataGridViewTextBoxColumn.DataSource = this.oSRStatesBindingSource;
            this.statesIDDataGridViewTextBoxColumn.DisplayMember = "States_Code";
            this.statesIDDataGridViewTextBoxColumn.HeaderText = "State";
            this.statesIDDataGridViewTextBoxColumn.Name = "statesIDDataGridViewTextBoxColumn";
            this.statesIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statesIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statesIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statesIDDataGridViewTextBoxColumn.ValueMember = "States_ID";
            this.statesIDDataGridViewTextBoxColumn.Width = 57;
            // 
            // oSRStatesBindingSource
            // 
            this.oSRStatesBindingSource.DataMember = "OSR_States";
            this.oSRStatesBindingSource.DataSource = this.osrDataSet1;
            // 
            // osrDataSet1
            // 
            this.osrDataSet1.DataSetName = "OSRDataSet";
            this.osrDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cntrctrZipDataGridViewTextBoxColumn
            // 
            this.cntrctrZipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrZipDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Zip";
            this.cntrctrZipDataGridViewTextBoxColumn.HeaderText = "Zip Code";
            this.cntrctrZipDataGridViewTextBoxColumn.Name = "cntrctrZipDataGridViewTextBoxColumn";
            this.cntrctrZipDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrZipDataGridViewTextBoxColumn.Width = 69;
            // 
            // cntrctrEmail1DataGridViewTextBoxColumn
            // 
            this.cntrctrEmail1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrEmail1DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Email1";
            this.cntrctrEmail1DataGridViewTextBoxColumn.HeaderText = "Email 1";
            this.cntrctrEmail1DataGridViewTextBoxColumn.Name = "cntrctrEmail1DataGridViewTextBoxColumn";
            this.cntrctrEmail1DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrEmail1DataGridViewTextBoxColumn.Width = 61;
            // 
            // cntrctrEmail2DataGridViewTextBoxColumn
            // 
            this.cntrctrEmail2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrEmail2DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Email2";
            this.cntrctrEmail2DataGridViewTextBoxColumn.HeaderText = "Email 2";
            this.cntrctrEmail2DataGridViewTextBoxColumn.Name = "cntrctrEmail2DataGridViewTextBoxColumn";
            this.cntrctrEmail2DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrEmail2DataGridViewTextBoxColumn.Width = 61;
            // 
            // cntrctrPhone1DataGridViewTextBoxColumn
            // 
            this.cntrctrPhone1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrPhone1DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Phone1";
            this.cntrctrPhone1DataGridViewTextBoxColumn.HeaderText = "Cell Phone";
            this.cntrctrPhone1DataGridViewTextBoxColumn.Name = "cntrctrPhone1DataGridViewTextBoxColumn";
            this.cntrctrPhone1DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrPhone1DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cntrctrPhone1DataGridViewTextBoxColumn.Width = 77;
            // 
            // Carriers_ID
            // 
            this.Carriers_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Carriers_ID.DataPropertyName = "Carriers_ID";
            this.Carriers_ID.DataSource = this.oSRCarriersBindingSource;
            this.Carriers_ID.DisplayMember = "Carriers_Name";
            this.Carriers_ID.HeaderText = "Carriers_ID";
            this.Carriers_ID.Name = "Carriers_ID";
            this.Carriers_ID.ReadOnly = true;
            this.Carriers_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Carriers_ID.ValueMember = "Carriers_ID";
            this.Carriers_ID.Width = 84;
            // 
            // oSRCarriersBindingSource
            // 
            this.oSRCarriersBindingSource.DataMember = "OSR_Carriers";
            this.oSRCarriersBindingSource.DataSource = this.osrDataSet1;
            // 
            // cntrctrPhone2DataGridViewTextBoxColumn
            // 
            this.cntrctrPhone2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrPhone2DataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_Phone2";
            this.cntrctrPhone2DataGridViewTextBoxColumn.HeaderText = "Home Phone";
            this.cntrctrPhone2DataGridViewTextBoxColumn.Name = "cntrctrPhone2DataGridViewTextBoxColumn";
            this.cntrctrPhone2DataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrPhone2DataGridViewTextBoxColumn.Width = 87;
            // 
            // cntrctrMaxFilesDataGridViewTextBoxColumn
            // 
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_MaxFiles";
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.HeaderText = "Max Files";
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.Name = "cntrctrMaxFilesDataGridViewTextBoxColumn";
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrMaxFilesDataGridViewTextBoxColumn.Width = 70;
            // 
            // activeStatusCodeDataGridViewTextBoxColumn
            // 
            this.activeStatusCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.activeStatusCodeDataGridViewTextBoxColumn.DataPropertyName = "ActiveStatus_Code";
            this.activeStatusCodeDataGridViewTextBoxColumn.DataSource = this.oSRActiveStatusBindingSource;
            this.activeStatusCodeDataGridViewTextBoxColumn.DisplayMember = "ActiveStatus_Descript";
            this.activeStatusCodeDataGridViewTextBoxColumn.HeaderText = "Active Status";
            this.activeStatusCodeDataGridViewTextBoxColumn.Name = "activeStatusCodeDataGridViewTextBoxColumn";
            this.activeStatusCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.activeStatusCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activeStatusCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.activeStatusCodeDataGridViewTextBoxColumn.ValueMember = "ActiveStatus_Code";
            this.activeStatusCodeDataGridViewTextBoxColumn.Width = 87;
            // 
            // oSRActiveStatusBindingSource
            // 
            this.oSRActiveStatusBindingSource.DataMember = "OSR_ActiveStatus";
            this.oSRActiveStatusBindingSource.DataSource = this.osrDataSet1;
            // 
            // retouchTypeCodeDataGridViewTextBoxColumn
            // 
            this.retouchTypeCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.retouchTypeCodeDataGridViewTextBoxColumn.DataPropertyName = "RetouchType_Code";
            this.retouchTypeCodeDataGridViewTextBoxColumn.DataSource = this.oSRRetouchTypeBindingSource;
            this.retouchTypeCodeDataGridViewTextBoxColumn.DisplayMember = "RetouchType_Descript";
            this.retouchTypeCodeDataGridViewTextBoxColumn.HeaderText = "Retouch Type";
            this.retouchTypeCodeDataGridViewTextBoxColumn.Name = "retouchTypeCodeDataGridViewTextBoxColumn";
            this.retouchTypeCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.retouchTypeCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.retouchTypeCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.retouchTypeCodeDataGridViewTextBoxColumn.ValueMember = "RetouchType_Code";
            this.retouchTypeCodeDataGridViewTextBoxColumn.Width = 92;
            // 
            // oSRRetouchTypeBindingSource
            // 
            this.oSRRetouchTypeBindingSource.DataMember = "OSR_RetouchType";
            this.oSRRetouchTypeBindingSource.DataSource = this.osrDataSet1;
            // 
            // cntrctrCreatedDateDataGridViewTextBoxColumn
            // 
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.DataPropertyName = "Cntrctr_CreatedDate";
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.HeaderText = "Created Date";
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.Name = "cntrctrCreatedDateDataGridViewTextBoxColumn";
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntrctrCreatedDateDataGridViewTextBoxColumn.Width = 87;
            // 
            // Cntrctr_DeactivatedDate
            // 
            this.Cntrctr_DeactivatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cntrctr_DeactivatedDate.DataPropertyName = "Cntrctr_DeactivatedDate";
            this.Cntrctr_DeactivatedDate.HeaderText = "Deactivated Date";
            this.Cntrctr_DeactivatedDate.Name = "Cntrctr_DeactivatedDate";
            this.Cntrctr_DeactivatedDate.ReadOnly = true;
            this.Cntrctr_DeactivatedDate.Width = 106;
            // 
            // Cntrctr_ReactivatedDate
            // 
            this.Cntrctr_ReactivatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cntrctr_ReactivatedDate.DataPropertyName = "Cntrctr_ReactivatedDate";
            this.Cntrctr_ReactivatedDate.HeaderText = "Reactivated Date";
            this.Cntrctr_ReactivatedDate.Name = "Cntrctr_ReactivatedDate";
            this.Cntrctr_ReactivatedDate.ReadOnly = true;
            this.Cntrctr_ReactivatedDate.Width = 106;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "OSR_Contractor";
            this.bindingSource1.DataSource = this.osrDataSet1;
            // 
            // oSR_ContractorTableAdapter
            // 
            this.oSR_ContractorTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_StatesTableAdapter
            // 
            this.oSR_StatesTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_ActiveStatusTableAdapter
            // 
            this.oSR_ActiveStatusTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_RetouchTypeTableAdapter
            // 
            this.oSR_RetouchTypeTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_CarriersTableAdapter
            // 
            this.oSR_CarriersTableAdapter.ClearBeforeFill = true;
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
            // ContractorDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 320);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1278, 364);
            this.Name = "ContractorDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Contractors List";
            this.Load += new System.EventHandler(this.Records_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRStatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRCarriersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRActiveStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn cntrctrStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCodeDataGridViewTextBoxColumn;
        private OSRDataSet osrDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OSRDataSetTableAdapters.OSR_ContractorTableAdapter oSR_ContractorTableAdapter;
        private System.Windows.Forms.BindingSource oSRStatesBindingSource;
        private OSRDataSetTableAdapters.OSR_StatesTableAdapter oSR_StatesTableAdapter;
        private System.Windows.Forms.BindingSource oSRActiveStatusBindingSource;
        private OSRDataSetTableAdapters.OSR_ActiveStatusTableAdapter oSR_ActiveStatusTableAdapter;
        private System.Windows.Forms.BindingSource oSRRetouchTypeBindingSource;
        private OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter oSR_RetouchTypeTableAdapter;
        private System.Windows.Forms.BindingSource oSRCarriersBindingSource;
        private OSRDataSetTableAdapters.OSR_CarriersTableAdapter oSR_CarriersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrFNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrLNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrAdd1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrAdd2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statesIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrZipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrEmail1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrEmail2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrPhone1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Carriers_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrPhone2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrMaxFilesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn activeStatusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn retouchTypeCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntrctrCreatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cntrctr_DeactivatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cntrctr_ReactivatedDate;
        private System.Windows.Forms.BindingSource bindingSource2;
        private OSRDataSetTableAdapters.OSR_ErrorsTableAdapter oSR_ErrorsTableAdapter;
    }
}