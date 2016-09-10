namespace OSR
{
    partial class ContractorMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractorMaintenance));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractorListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.lbl_FName = new System.Windows.Forms.Label();
            this.lbl_LName = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblEmail1 = new System.Windows.Forms.Label();
            this.lblEmail2 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtCountMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.cboxState = new System.Windows.Forms.ComboBox();
            this.oSRStatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.osrDataSet1 = new OSR.OSRDataSet();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboxStatus = new System.Windows.Forms.ComboBox();
            this.oSRActiveStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboxRetouchType = new System.Windows.Forms.ComboBox();
            this.oSRRetouchTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_ContractorTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ContractorTableAdapter();
            this.oSR_StatesTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_StatesTableAdapter();
            this.oSR_RetouchTypeTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter();
            this.oSR_ActiveStatusTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ActiveStatusTableAdapter();
            this.btnList = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.rtxtNotes = new System.Windows.Forms.RichTextBox();
            this.lblCarrierID = new System.Windows.Forms.Label();
            this.cboxCarriersID = new System.Windows.Forms.ComboBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_CarriersTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_CarriersTableAdapter();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_ErrorsTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ErrorsTableAdapter();
            this.btnSetPW = new System.Windows.Forms.Button();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oSRStatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRActiveStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contractorListToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // contractorListToolStripMenuItem1
            // 
            this.contractorListToolStripMenuItem1.Name = "contractorListToolStripMenuItem1";
            this.contractorListToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.contractorListToolStripMenuItem1.Text = "&Contractor List";
            this.contractorListToolStripMenuItem1.Click += new System.EventHandler(this.contractorListToolStripMenuItem_Click);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(79, 70);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(150, 20);
            this.txtFName.TabIndex = 2;
            this.txtFName.Leave += new System.EventHandler(this.txtFName_Leave);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(80, 104);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(150, 20);
            this.txtLName.TabIndex = 3;
            this.txtLName.Leave += new System.EventHandler(this.txtLName_Leave);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(80, 139);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(250, 20);
            this.txtAddress1.TabIndex = 4;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(80, 172);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(250, 20);
            this.txtAddress2.TabIndex = 5;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(80, 206);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 20);
            this.txtCity.TabIndex = 6;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(80, 276);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(100, 20);
            this.txtZip.TabIndex = 8;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail1.Location = new System.Drawing.Point(497, 37);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(150, 20);
            this.txtEmail1.TabIndex = 9;
            this.txtEmail1.Leave += new System.EventHandler(this.txtEmail1_Leave);
            // 
            // txtEmail2
            // 
            this.txtEmail2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail2.Location = new System.Drawing.Point(497, 71);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(150, 20);
            this.txtEmail2.TabIndex = 10;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone1.Location = new System.Drawing.Point(497, 106);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(150, 20);
            this.txtPhone1.TabIndex = 11;
            // 
            // txtPhone2
            // 
            this.txtPhone2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone2.Location = new System.Drawing.Point(497, 172);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(150, 20);
            this.txtPhone2.TabIndex = 13;
            // 
            // lbl_FName
            // 
            this.lbl_FName.AutoSize = true;
            this.lbl_FName.Location = new System.Drawing.Point(13, 73);
            this.lbl_FName.Name = "lbl_FName";
            this.lbl_FName.Size = new System.Drawing.Size(60, 13);
            this.lbl_FName.TabIndex = 12;
            this.lbl_FName.Text = "First Name:";
            // 
            // lbl_LName
            // 
            this.lbl_LName.AutoSize = true;
            this.lbl_LName.Location = new System.Drawing.Point(13, 107);
            this.lbl_LName.Name = "lbl_LName";
            this.lbl_LName.Size = new System.Drawing.Size(61, 13);
            this.lbl_LName.TabIndex = 13;
            this.lbl_LName.Text = "Last Name:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(13, 142);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(57, 13);
            this.lblAddress1.TabIndex = 14;
            this.lblAddress1.Text = "Address 1:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(13, 179);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(57, 13);
            this.lblAddress2.TabIndex = 15;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(13, 209);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 16;
            this.lblCity.Text = "City:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(13, 243);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 17;
            this.lblState.Text = "State:";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(13, 279);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(53, 13);
            this.lblZip.TabIndex = 18;
            this.lblZip.Text = "Zip Code:";
            // 
            // lblEmail1
            // 
            this.lblEmail1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail1.AutoSize = true;
            this.lblEmail1.Location = new System.Drawing.Point(395, 40);
            this.lblEmail1.Name = "lblEmail1";
            this.lblEmail1.Size = new System.Drawing.Size(44, 13);
            this.lblEmail1.TabIndex = 19;
            this.lblEmail1.Text = "Email 1:";
            // 
            // lblEmail2
            // 
            this.lblEmail2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail2.AutoSize = true;
            this.lblEmail2.Location = new System.Drawing.Point(395, 74);
            this.lblEmail2.Name = "lblEmail2";
            this.lblEmail2.Size = new System.Drawing.Size(44, 13);
            this.lblEmail2.TabIndex = 20;
            this.lblEmail2.Text = "Email 2:";
            // 
            // lblPhone1
            // 
            this.lblPhone1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Location = new System.Drawing.Point(395, 109);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(61, 13);
            this.lblPhone1.TabIndex = 21;
            this.lblPhone1.Text = "Cell Phone:";
            // 
            // lblPhone2
            // 
            this.lblPhone2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(395, 176);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(72, 13);
            this.lblPhone2.TabIndex = 22;
            this.lblPhone2.Text = "Home Phone:";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(395, 210);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "Type:";
            // 
            // txtCountMax
            // 
            this.txtCountMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountMax.Location = new System.Drawing.Point(497, 240);
            this.txtCountMax.Name = "txtCountMax";
            this.txtCountMax.Size = new System.Drawing.Size(50, 20);
            this.txtCountMax.TabIndex = 15;
            this.txtCountMax.Leave += new System.EventHandler(this.txtCountMax_Leave);
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(395, 243);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(93, 13);
            this.lblMax.TabIndex = 26;
            this.lblMax.Text = "Image Count Max:";
            // 
            // lblActive
            // 
            this.lblActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(395, 279);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(73, 13);
            this.lblActive.TabIndex = 28;
            this.lblActive.Text = "Active Status:";
            // 
            // cboxState
            // 
            this.cboxState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxState.DataSource = this.oSRStatesBindingSource;
            this.cboxState.DisplayMember = "States_Code";
            this.cboxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxState.FormattingEnabled = true;
            this.cboxState.Location = new System.Drawing.Point(80, 240);
            this.cboxState.Name = "cboxState";
            this.cboxState.Size = new System.Drawing.Size(50, 21);
            this.cboxState.TabIndex = 7;
            this.cboxState.ValueMember = "States_ID";
            this.cboxState.Leave += new System.EventHandler(this.cboxState_Leave);
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
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(14, 40);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 29;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(80, 37);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(150, 20);
            this.txtID.TabIndex = 1;
            // 
            // cboxStatus
            // 
            this.cboxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxStatus.DataSource = this.oSRActiveStatusBindingSource;
            this.cboxStatus.DisplayMember = "ActiveStatus_Descript";
            this.cboxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStatus.FormattingEnabled = true;
            this.cboxStatus.Location = new System.Drawing.Point(497, 273);
            this.cboxStatus.Name = "cboxStatus";
            this.cboxStatus.Size = new System.Drawing.Size(75, 21);
            this.cboxStatus.TabIndex = 16;
            this.cboxStatus.ValueMember = "ActiveStatus_Code";
            this.cboxStatus.Leave += new System.EventHandler(this.cboxStatus_Leave);
            // 
            // oSRActiveStatusBindingSource
            // 
            this.oSRActiveStatusBindingSource.DataMember = "OSR_ActiveStatus";
            this.oSRActiveStatusBindingSource.DataSource = this.osrDataSet1;
            // 
            // cboxRetouchType
            // 
            this.cboxRetouchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxRetouchType.DataSource = this.oSRRetouchTypeBindingSource;
            this.cboxRetouchType.DisplayMember = "RetouchType_Descript";
            this.cboxRetouchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRetouchType.FormattingEnabled = true;
            this.cboxRetouchType.Location = new System.Drawing.Point(497, 206);
            this.cboxRetouchType.Name = "cboxRetouchType";
            this.cboxRetouchType.Size = new System.Drawing.Size(150, 21);
            this.cboxRetouchType.TabIndex = 14;
            this.cboxRetouchType.ValueMember = "RetouchType_Code";
            this.cboxRetouchType.Leave += new System.EventHandler(this.cboxRetouchType_Leave);
            // 
            // oSRRetouchTypeBindingSource
            // 
            this.oSRRetouchTypeBindingSource.DataMember = "OSR_RetouchType";
            this.oSRRetouchTypeBindingSource.DataSource = this.osrDataSet1;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(244, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(325, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // oSR_RetouchTypeTableAdapter
            // 
            this.oSR_RetouchTypeTableAdapter.ClearBeforeFill = true;
            // 
            // oSR_ActiveStatusTableAdapter
            // 
            this.oSR_ActiveStatusTableAdapter.ClearBeforeFill = true;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(236, 35);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(50, 23);
            this.btnList.TabIndex = 30;
            this.btnList.Text = "&List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(395, 312);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 31;
            this.lblNotes.Text = "Notes:";
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNotes.Location = new System.Drawing.Point(439, 312);
            this.rtxtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(209, 71);
            this.rtxtNotes.TabIndex = 17;
            this.rtxtNotes.Text = "";
            // 
            // lblCarrierID
            // 
            this.lblCarrierID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarrierID.AutoSize = true;
            this.lblCarrierID.Location = new System.Drawing.Point(395, 142);
            this.lblCarrierID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarrierID.Name = "lblCarrierID";
            this.lblCarrierID.Size = new System.Drawing.Size(60, 13);
            this.lblCarrierID.TabIndex = 32;
            this.lblCarrierID.Text = "Cell Carrier:";
            // 
            // cboxCarriersID
            // 
            this.cboxCarriersID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCarriersID.DataSource = this.bindingSource2;
            this.cboxCarriersID.DisplayMember = "Carriers_Name";
            this.cboxCarriersID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCarriersID.FormattingEnabled = true;
            this.cboxCarriersID.Location = new System.Drawing.Point(497, 142);
            this.cboxCarriersID.Margin = new System.Windows.Forms.Padding(2);
            this.cboxCarriersID.Name = "cboxCarriersID";
            this.cboxCarriersID.Size = new System.Drawing.Size(149, 21);
            this.cboxCarriersID.TabIndex = 12;
            this.cboxCarriersID.ValueMember = "Carriers_ID";
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "OSR_Carriers";
            this.bindingSource2.DataSource = this.osrDataSet1;
            // 
            // oSR_CarriersTableAdapter
            // 
            this.oSR_CarriersTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource3
            // 
            this.bindingSource3.DataMember = "OSR_Errors";
            this.bindingSource3.DataSource = this.osrDataSet1;
            // 
            // oSR_ErrorsTableAdapter
            // 
            this.oSR_ErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // btnSetPW
            // 
            this.btnSetPW.Enabled = false;
            this.btnSetPW.Location = new System.Drawing.Point(12, 362);
            this.btnSetPW.Name = "btnSetPW";
            this.btnSetPW.Size = new System.Drawing.Size(100, 23);
            this.btnSetPW.TabIndex = 33;
            this.btnSetPW.Text = "Set PW";
            this.btnSetPW.UseVisualStyleBackColor = true;
            this.btnSetPW.Visible = false;
            this.btnSetPW.Click += new System.EventHandler(this.btnSetPW_Click);
            // 
            // txtPW
            // 
            this.txtPW.Enabled = false;
            this.txtPW.Location = new System.Drawing.Point(12, 336);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(100, 20);
            this.txtPW.TabIndex = 34;
            this.txtPW.Visible = false;
            // 
            // ContractorMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 397);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.btnSetPW);
            this.Controls.Add(this.cboxCarriersID);
            this.Controls.Add(this.lblCarrierID);
            this.Controls.Add(this.rtxtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboxRetouchType);
            this.Controls.Add(this.cboxStatus);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.cboxState);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.txtCountMax);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPhone2);
            this.Controls.Add(this.lblPhone1);
            this.Controls.Add(this.lblEmail2);
            this.Controls.Add(this.lblEmail1);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lbl_LName);
            this.Controls.Add(this.lbl_FName);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.txtEmail1);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(673, 445);
            this.Name = "ContractorMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Contractor Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContractorMaintenance_FormClosing);
            this.Load += new System.EventHandler(this.AddNewContractor_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddNewContractor_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oSRStatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRActiveStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label lbl_FName;
        private System.Windows.Forms.Label lbl_LName;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblEmail1;
        private System.Windows.Forms.Label lblEmail2;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtCountMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.ComboBox cboxState;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cboxStatus;
        private System.Windows.Forms.ComboBox cboxRetouchType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private OSRDataSet osrDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OSRDataSetTableAdapters.OSR_ContractorTableAdapter oSR_ContractorTableAdapter;
        private System.Windows.Forms.BindingSource oSRStatesBindingSource;
        private OSRDataSetTableAdapters.OSR_StatesTableAdapter oSR_StatesTableAdapter;
        private System.Windows.Forms.BindingSource oSRRetouchTypeBindingSource;
        private OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter oSR_RetouchTypeTableAdapter;
        private System.Windows.Forms.BindingSource oSRActiveStatusBindingSource;
        private OSRDataSetTableAdapters.OSR_ActiveStatusTableAdapter oSR_ActiveStatusTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractorListToolStripMenuItem1;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.RichTextBox rtxtNotes;
        private System.Windows.Forms.Label lblCarrierID;
        private System.Windows.Forms.ComboBox cboxCarriersID;
        private System.Windows.Forms.BindingSource bindingSource2;
        private OSRDataSetTableAdapters.OSR_CarriersTableAdapter oSR_CarriersTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource3;
        private OSRDataSetTableAdapters.OSR_ErrorsTableAdapter oSR_ErrorsTableAdapter;
        private System.Windows.Forms.Button btnSetPW;
        private System.Windows.Forms.TextBox txtPW;
    }
}

