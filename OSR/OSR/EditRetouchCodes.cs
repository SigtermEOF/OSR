/* **********************************************************************************************************************************
 * **********************************************************************************************************************************
 * -- Copyright (c) Advanced Photographics Solutions 2013. All rights reserved.
 * 
 *  <file name='Retouch Code Maintenance' />
 *  <solution name='OSR' />
 *  <project name='OSR' />
 *  <developmentlab name='Advanced Photographic Solutions' />
 *  <developementteam name='Jason Lett' initials='jrl' />
 * 
 *  <class name'Edit Retouch Codes'>
 *  <description>
 *  (O)ff (S)ite (R)etouching form for editing retouch codes.
 *  
 *      -
 *      - 
 *  </description>
 *  </class>
 * 
 * <updatelog>
 * ===================================================================================================================================================
 * <update number='' version='' fileversion='' date='' request='' author=''> </update>
 * <update number='0' version='0.0.0.0' fileversion='0.0.0.0' date='21 March 2014' request='DEVELOPMENT' author='jrl'> Initial Version of File - ALL INITIAL DEVELOPMENT </update>
 * </updatelog>
 * ===================================================================================================================================================
 * 
********************************************************************************************************************************** */

//*****************************
//#define Development
//*****************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OSR
{
    public partial class EditRetouchCodes : Form
    {


        private RetouchCodeMaintenance RetCodeMaint = null;

        public string sException = "";

        // Set a bool to indicate whether we have a record on the leave event query for the Code textbox. Then base conditions
        // on whether this is true/false for button availability/displayed text.
        bool bSave = true;


        public EditRetouchCodes()
        {
            InitializeComponent();

            RetCodeMaint = new RetouchCodeMaintenance();
        }

        private void EditRetouchCodes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oSRDataSet.OSR_Errors' table. You can move, or remove it, as needed.
            this.oSR_ErrorsTableAdapter.Fill(this.oSRDataSet.OSR_Errors);
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_RetouchCodes' table. You can move, or remove it, as needed.
            this.oSR_RetouchCodesTableAdapter.Fill(this.osrDataSet1.OSR_RetouchCodes);
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_RetouchType' table. You can move, or remove it, as needed.
            this.oSR_RetouchTypeTableAdapter.Fill(this.osrDataSet1.OSR_RetouchType);
            this.cboxType.SelectedIndex = -1;
        }

        #region Form events.

        private void btnList_Click(object sender, EventArgs e)
        {
            this.GetCode();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bSave == true)
            {
                this.SaveNewCodeToDB();
                this.Clear();
            }
            else if (bSave == false)
            {
                this.UpdateDB();
                this.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void EditRetouchCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Clear();
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (this.txtCode.Text != string.Empty)
            {
                this.GatherCodeInfo();
            }
        }

        #endregion

        #region Task methods.

        private void GetCode()
        {
            this.Enabled = false;

            if (this.RetCodeMaint.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.txtCode.Text = Convert.ToString(RetCodeMaint.sCode);
                this.GatherCodeInfo();
            }

            this.Enabled = true;
        }

        private void GatherCodeInfo()
        {
            try
            {

                string sQueryString = string.Format("SELECT * FROM [OSR_RetouchCodes] WHERE [RetouchCodes_Code] = '" + this.txtCode.Text + "' ");

                SqlConnection searchSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                SqlCommand searchSqlCommand = searchSqlConnection.CreateCommand();

                searchSqlCommand.CommandText = sQueryString;

                searchSqlConnection.Open();

                SqlDataAdapter searchSqlDataAdapter = new SqlDataAdapter(searchSqlCommand.CommandText, searchSqlConnection);

                searchSqlDataAdapter.SelectCommand = searchSqlCommand;

                SqlDataReader searchSqlDataReader = searchSqlCommand.ExecuteReader();

                this.osrDataSet1.OSR_RetouchCodes.Clear();

                this.osrDataSet1.OSR_RetouchCodes.Load(searchSqlDataReader);

                if (this.osrDataSet1.OSR_RetouchCodes.Rows.Count == 1)
                {

                    this.txtCode.Text = this.osrDataSet1.OSR_RetouchCodes[0].RetouchCodes_Code;
                    this.txtLabel.Text = this.osrDataSet1.OSR_RetouchCodes[0].RetouchCodes_Label;
                    this.txtDescript.Text = this.osrDataSet1.OSR_RetouchCodes[0].RetouchCodes_Description;
                    this.cboxType.SelectedIndex = this.osrDataSet1.OSR_RetouchCodes[0].RetouchType_Code;

                    // If a record is returned then setup for updating the record rather than saving as new.
                    this.btnSave.Text = "&Update";
                    bSave = false;
                    this.Refresh();

                }

                // If no result is returned then proceed in "Save" mode.
                else if (this.osrDataSet1.OSR_RetouchCodes.Rows.Count != 1)
                {
                    bSave = true;
                }

                searchSqlDataAdapter.Dispose();

                searchSqlDataReader.Close();
                searchSqlDataReader.Dispose();

                searchSqlCommand.Dispose();

                searchSqlConnection.Close();
                searchSqlConnection.Dispose();

            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveNewCodeToDB()
        {
            try
            {
                string sCode = this.txtCode.Text;
                string sDescript = this.txtDescript.Text;
                string sLabel = this.txtLabel.Text;
                int iRetType = this.osrDataSet1.OSR_RetouchType[this.cboxType.SelectedIndex].RetouchType_Code;

                // to cause an exception uncomment line below
                //int iRetType = this.osrDataSet1.OSR_RetouchCodes[this.cboxType.SelectedIndex].RetouchType_Code;

                DataRow drOSR = this.osrDataSet1.OSR_RetouchCodes.NewRow();
                drOSR["RetouchCodes_Code"] = sCode;
                drOSR["RetouchCodes_Label"] = sLabel;
                drOSR["RetouchCodes_Description"] = sDescript;
                drOSR["RetouchType_Code"] = iRetType;

                this.osrDataSet1.OSR_RetouchCodes.Rows.Add(drOSR);

                this.oSR_RetouchCodesTableAdapter.Update(osrDataSet1);

                MessageBox.Show("Record saved to database successfully"); 

            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);                
            }
        }

        private void UpdateDB()
        {
            try
            {
                SqlConnection updateSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                SqlCommand updateSqlCommand = updateSqlConnection.CreateCommand();

                string sCode = this.txtCode.Text;
                string sLabel = this.txtLabel.Text;
                string sDescript = this.txtDescript.Text;

                bool combined = false; // In case of multiple search parameters.

                string SqlUpdate = @"UPDATE [OSRetouch].[dbo].[OSR_RetouchCodes] SET";

                // Check the forms fields for data, concatenate the SQL update command based on entered field information.
                // I do not check/update the ID as that is the unique column that this query is based upon.

                if (!string.IsNullOrEmpty(sLabel))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [RetouchCodes_Label] = \'" + sLabel + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sDescript))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [RetouchCodes_Description] = \'" + sDescript + "\'";

                    combined = true;
                }

                if (this.cboxType.SelectedIndex != -1)
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [RetouchType_Code] = \'" + this.cboxType.SelectedIndex + "\'";

                    combined = true;
                }

                SqlUpdate += " WHERE [RetouchCodes_Code] = \'" + sCode + "\'";


                updateSqlCommand.CommandText = SqlUpdate;

                updateSqlConnection.Open();

                updateSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Database updated successfully.");

                updateSqlCommand.Dispose();

                updateSqlConnection.Close();
                updateSqlConnection.Dispose();

            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveExceptionToDB()
        {
            try
            {

                DateTime dt = DateTime.Now;

                DataRow drOSR = this.osrDataSet1.OSR_Errors.NewRow();

                drOSR["Errors_String"] = sException;
                drOSR["Errors_DateTime"] = dt;

                this.osrDataSet1.OSR_Errors.Rows.Add(drOSR);

                this.oSR_ErrorsTableAdapter.Update(osrDataSet1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            this.txtCode.Text = "";
            this.txtDescript.Text = "";
            this.txtLabel.Text = "";
            this.cboxType.SelectedIndex = -1;
            this.btnSave.Text = "&Save";

            this.Refresh();
        }

        #endregion
    }
}
