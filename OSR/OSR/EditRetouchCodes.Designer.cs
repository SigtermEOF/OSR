namespace OSR
{
    partial class EditRetouchCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRetouchCodes));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblDescript = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cboxType = new System.Windows.Forms.ComboBox();
            this.oSRRetouchTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.osrDataSet1 = new OSR.OSRDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.oSR_RetouchTypeTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSR_RetouchCodesTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_RetouchCodesTableAdapter();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.oSRDataSet = new OSR.OSRDataSet();
            this.oSR_ErrorsTableAdapter = new OSR.OSRDataSetTableAdapters.OSR_ErrorsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(101, 45);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(82, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(101, 84);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(2);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(212, 20);
            this.txtLabel.TabIndex = 1;
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(101, 126);
            this.txtDescript.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(212, 20);
            this.txtDescript.TabIndex = 2;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(49, 48);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Code:";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(49, 87);
            this.lblLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(36, 13);
            this.lblLabel.TabIndex = 4;
            this.lblLabel.Text = "Label:";
            // 
            // lblDescript
            // 
            this.lblDescript.AutoSize = true;
            this.lblDescript.Location = new System.Drawing.Point(23, 129);
            this.lblDescript.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescript.Name = "lblDescript";
            this.lblDescript.Size = new System.Drawing.Size(63, 13);
            this.lblDescript.TabIndex = 5;
            this.lblDescript.Text = "Description:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(49, 168);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type:";
            // 
            // cboxType
            // 
            this.cboxType.DataSource = this.oSRRetouchTypeBindingSource;
            this.cboxType.DisplayMember = "RetouchType_Descript";
            this.cboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Location = new System.Drawing.Point(101, 165);
            this.cboxType.Margin = new System.Windows.Forms.Padding(2);
            this.cboxType.Name = "cboxType";
            this.cboxType.Size = new System.Drawing.Size(212, 21);
            this.cboxType.TabIndex = 7;
            this.cboxType.ValueMember = "RetouchType_Code";
            // 
            // oSRRetouchTypeBindingSource
            // 
            this.oSRRetouchTypeBindingSource.DataMember = "OSR_RetouchType";
            this.oSRRetouchTypeBindingSource.DataSource = this.osrDataSet1;
            // 
            // osrDataSet1
            // 
            this.osrDataSet1.DataSetName = "OSRDataSet";
            this.osrDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 217);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(159, 217);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(187, 42);
            this.btnList.Margin = new System.Windows.Forms.Padding(2);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(56, 24);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "&List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // oSR_RetouchTypeTableAdapter
            // 
            this.oSR_RetouchTypeTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "OSR_RetouchCodes";
            this.bindingSource1.DataSource = this.osrDataSet1;
            // 
            // oSR_RetouchCodesTableAdapter
            // 
            this.oSR_RetouchCodesTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "OSR_Errors";
            this.bindingSource2.DataSource = this.oSRDataSet;
            // 
            // oSRDataSet
            // 
            this.oSRDataSet.DataSetName = "OSRDataSet";
            this.oSRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oSR_ErrorsTableAdapter
            // 
            this.oSR_ErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // EditRetouchCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 289);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboxType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDescript);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditRetouchCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.S.R. Edit Retouch Codes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditRetouchCodes_FormClosing);
            this.Load += new System.EventHandler(this.EditRetouchCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oSRRetouchTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osrDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSRDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblDescript;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboxType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnList;
        private OSRDataSet osrDataSet1;
        private System.Windows.Forms.BindingSource oSRRetouchTypeBindingSource;
        private OSRDataSetTableAdapters.OSR_RetouchTypeTableAdapter oSR_RetouchTypeTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OSRDataSetTableAdapters.OSR_RetouchCodesTableAdapter oSR_RetouchCodesTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private OSRDataSet oSRDataSet;
        private OSRDataSetTableAdapters.OSR_ErrorsTableAdapter oSR_ErrorsTableAdapter;
    }
}