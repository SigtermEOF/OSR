/* **********************************************************************************************************************************
 * **********************************************************************************************************************************
 * -- Copyright (c) Advanced Photographics Solutions 2013. All rights reserved.
 * 
 *  <file name='ContractorMaintenance' />
 *  <solution name='OSR' />
 *  <project name='OSR' />
 *  <developmentlab name='Advanced Photographic Solutions' />
 *  <developementteam name='Jason Lett' initials='jrl' />
 * 
 *  <class name'ContractorMaintenance'>
 *  <description>
 *  (O)ff (S)ite (R)etouching form for adding and modifying contractors in the database.
 *  
 *      -
 *      - 
 *  </description>
 *  </class>
 * 
 * <updatelog>
 * ===================================================================================================================================================
 * <update number='' version='' fileversion='' date='' request='' author=''> </update>
 * <update number='0' version='0.0.0.0' fileversion='0.0.0.0' date='09 October 2013' request='DEVELOPMENT' author='jrl'> Initial Version of File - ALL INITIAL DEVELOPMENT </update>
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
    public partial class ContractorMaintenance : Form
    {

        // Class members.

        private ContractorDatabase ConDB = null;
        TaskMethods TM = null;
        Email EM = null;

        // Save button availabilty flags for needed data.
        //private bool bID = false;
        private bool bFName = false;
        private bool bLName = false;        
        private bool bEmail1 = false;
        private bool bMCount = false;
        private bool bRType = false;
        private bool bStatus = false;
        private int iStatus;

        string sID = "";
        string sFName = "";
        string sLName = "";
        string sAddress1 = "";
        string sAddress2 = "";
        string sCity = "";
        string sZip = "";
        string sEmail1 = "";
        string sEmail2 = "";
        string sPhone1 = "";
        string sPhone2 = "";
        int iRetType = 0;
        int iCarrierID = 0;
        string sCountMax = "";
        string sNotes = "";
        bool bShowPWDiag = false;

        string sSendtoAdd2 = "";
        string sEmailServer = "";
        string sEmailFromAdd = "";
        string sEmailMyBccAdd = "";
        string sEmailMyErrorSendAdd = "";
        string sNewCntrctrSendToAdd = "";

        string sException = "";

        DateTime sDate = DateTime.Now;

        // Set a bool to indicate whether the user has selected a state from the combobox.
        // Default is false for a selectedindex of -1 (no state selected).
        private bool bState = false;



        // Set a bool to indicate whether we have a record on the leave event query for the ID textbox. Then base conditions
        // on whether this is true/false for button availability/displayed text.
        private bool bSave = true;

        /// <summary>
        /// 
        /// </summary>
        public ContractorMaintenance()
        {
            InitializeComponent();

            // Instantiate all members.
            ConDB = new ContractorDatabase();
            TM = new TaskMethods();
            EM = new Email();

        }

        private void AddNewContractor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_Errors' table. You can move, or remove it, as needed.
            this.oSR_ErrorsTableAdapter.Fill(this.osrDataSet1.OSR_Errors);
            // Load data into the tables for comboboxes.
            this.oSR_RetouchTypeTableAdapter.Fill(this.osrDataSet1.OSR_RetouchType);
            this.oSR_StatesTableAdapter.Fill(this.osrDataSet1.OSR_States);
            this.oSR_ActiveStatusTableAdapter.Fill(this.osrDataSet1.OSR_ActiveStatus);
            this.oSR_CarriersTableAdapter.Fill(this.osrDataSet1.OSR_Carriers);

            this.ActiveControl = this.txtFName;

            // Set the indexes for the comboboxes.
            this.cboxState.SelectedIndex = -1;
            this.cboxStatus.SelectedIndex = -1;
            this.cboxRetouchType.SelectedIndex = -1;
            this.cboxCarriersID.SelectedIndex = -1;

            TM.EmailVariables(ref sEmailServer, ref sEmailMyBccAdd, ref sEmailMyErrorSendAdd, ref sSendtoAdd2, ref sNewCntrctrSendToAdd);

#if (Development)

            this.txtPW.Enabled = true;
            this.txtPW.Visible = true;
            this.btnSetPW.Enabled = true;
            this.btnSetPW.Visible = true;

#endif 

        }

        #region Menu events.

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // On click event verify the user wishes to exit the program.
            DialogResult verifyExit;
            verifyExit = MessageBox.Show("Exit the program?", "Exit", MessageBoxButtons.YesNo);
            // Exit the application if yes is chosen.
            if (verifyExit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (verifyExit == DialogResult.No)
            {
                // Do nothing if the user answers no.
                return;
            }
        }

        private void contractorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GetID();
        }

        #endregion

        #region Form events.

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bSave == true)
            {
                this.SaveRecordsToDatabase();
                this.EmailNew();
                this.ClearForm();
            }
            else if (bSave == false)
            {
                this.UpdateRecordsToDatabase();
                this.ClearForm();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.GetID();
        }

        #region commented code
        //private void txtID_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.txtID.Text == "?")
        //    {
        //        this.GetID();
        //    }
        //}
        #endregion

        private void ContractorMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ClearForm();
        }

        private void AddNewContractor_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sKey = e.KeyChar.ToString();

            // Treat the Enter key as a means to Tab through fields.
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
                e.Handled = true;
            }
            if (sKey == "~")
            {
                if (this.btnSave.Text == "&Update")
                {

                    if (bShowPWDiag == false)
                    {
                        SendKeys.Send("{BS}");
                        e.Handled = true;

                        bShowPWDiag = true;

                        this.txtPW.Enabled = true;
                        this.txtPW.Visible = true;
                        this.btnSetPW.Enabled = true;
                        this.btnSetPW.Visible = true;
                    }
                    else if (bShowPWDiag == true)
                    {
                        SendKeys.Send("{BS}");
                        e.Handled = true;

                        bShowPWDiag = false;

                        this.txtPW.Enabled = false;
                        this.txtPW.Visible = false;
                        this.btnSetPW.Enabled = false;
                        this.btnSetPW.Visible = false;
                    }
                }
                else if (this.btnSave.Text == "&Save")
                {
                    return;
                }
            }
        }

        private void btnSetPW_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtID.Text != "" && this.txtFName.Text != "" && this.txtLName.Text != "")
                {
                    if (this.txtPW.Text != "")
                    {
                        string sConPW = this.txtPW.Text;
                        string sConID = this.txtID.Text;

                        SqlConnection updateSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                        SqlCommand updateSqlCommand = updateSqlConnection.CreateCommand();

                        string sSqlUpdate = @"UPDATE [OSRetouch].[dbo].[OSR_Contractor] SET [Cntrctr_Password] = " + "'" + sConPW + "'" + " WHERE [Cntrctr_ID] = " + "'" +  sConID + "'";

                        updateSqlCommand.CommandText = sSqlUpdate;

                        updateSqlConnection.Open();

                        updateSqlCommand.CommandTimeout = 0;

                        updateSqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Database updated successfully.");

                        this.txtPW.Text = "";
                        this.ClearForm();

                        updateSqlCommand.Dispose();

                        updateSqlConnection.Close();
                        updateSqlConnection.Dispose();
                    }
                    else if (this.txtPW.Text == "")
                    {
                        MessageBox.Show("You must enter a password to save!");
                        return;
                    }
                }
                else if (this.txtID.Text == "" || this.txtFName.Text == "" || this.txtLName.Text == "")
                {
                    MessageBox.Show("No contractor currently displayed!");
                    this.txtPW.Text = string.Empty;
                    return;
                }
            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        #endregion 

        #region Leave events.

        #region commented code
        //private void txtID_Leave(object sender, EventArgs e)
        //{
        //    // If the ID field is not empty query the database for existing contractors with the ID that the user input.
        //    if (this.txtID.Text != string.Empty)
        //    {
        //        bID = true;
        //        this.SearchDatabase();
        //    }
        //    // If the ID field is empty then proceed in "Save" mode.
        //    else if (this.txtID.Text == string.Empty)
        //    {
        //        bID = false;
        //        this.btnCancel.Enabled = false;
        //    }

        //    this.ReadyToSave();          
        //}
        #endregion

        private void txtFName_Leave(object sender, EventArgs e)
        {
            if (this.txtFName.Text != string.Empty)
                bFName = true;
            else
                bFName = false;
            this.ReadyToSave();
            
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            if (this.txtLName.Text != string.Empty)
                bLName = true;
            else
                bLName = false;
            this.ReadyToSave();
            
        }

        private void cboxState_Leave(object sender, EventArgs e)
        {
            if (this.cboxState.SelectedIndex == -1)
                bState = false;
            else
                bState = true;
        }

        private void txtEmail1_Leave(object sender, EventArgs e)
        {
            if (this.txtEmail1.Text != string.Empty)
                bEmail1 = true;
            else
                bEmail1 = false;
            this.ReadyToSave();
        }

        private void cboxRetouchType_Leave(object sender, EventArgs e)
        {
            if (this.cboxRetouchType.SelectedIndex == -1)
                bRType = false;
            else
                bRType = true;
            this.ReadyToSave();
        }

        private void txtCountMax_Leave(object sender, EventArgs e)
        {
            if (this.txtCountMax.Text != string.Empty)
                bMCount = true;
            else
                bMCount = false;
            this.ReadyToSave();
        }

        private void cboxStatus_Leave(object sender, EventArgs e)
        {
            if (this.cboxStatus.SelectedIndex == -1)
                bStatus = false;
            else
                bStatus = true;
            this.ReadyToSave();
        }

        #endregion

        #region Task methods.

        private void SaveRecordsToDatabase()
        {
            try
            {

                

                //sID = this.txtID.Text;
                sFName = this.txtFName.Text;
                sLName = this.txtLName.Text;
                sAddress1 = this.txtAddress1.Text;
                sAddress2 = this.txtAddress2.Text;
                sCity = this.txtCity.Text;
                sZip = this.txtZip.Text;                
                sEmail1 = this.txtEmail1.Text;
                sEmail2 = this.txtEmail2.Text;
                sPhone1 = this.txtPhone1.Text;
                sPhone2 = this.txtPhone2.Text;
                iRetType = this.osrDataSet1.OSR_RetouchType[this.cboxRetouchType.SelectedIndex].RetouchType_Code;
                iCarrierID = this.osrDataSet1.OSR_Carriers[this.cboxCarriersID.SelectedIndex].Carriers_ID;
                sCountMax = this.txtCountMax.Text;
                sNotes = this.rtxtNotes.Text;

                // Create new DataTable DataRow and insert DataRow data.
                DataRow drOSR = this.osrDataSet1.OSR_Contractor.NewRow();
                drOSR["Cntrctr_FName"] = sFName;
                drOSR["Cntrctr_LName"] = sLName;
                drOSR["Cntrctr_Add1"] = sAddress1;
                drOSR["Cntrctr_Add2"] = sAddress2;
                drOSR["Cntrctr_City"] = sCity;

                if (bState == false)
                {
                    drOSR["States_ID"] = DBNull.Value;
                }
                else if (bState == true)
                {
                    drOSR["States_ID"] = this.osrDataSet1.OSR_States[this.cboxState.SelectedIndex].States_ID;
                }


                drOSR["Cntrctr_Zip"] = sZip;
                //drOSR["Cntrctr_ID"] = sID;
                drOSR["Cntrctr_Email1"] = sEmail1;
                drOSR["Cntrctr_Email2"] = sEmail2;
                drOSR["Cntrctr_Phone1"] = sPhone1;
                drOSR["Cntrctr_Phone2"] = sPhone2;
                drOSR["RetouchType_Code"] = iRetType;
                drOSR["Carriers_ID"] = iCarrierID;
                drOSR["Cntrctr_CreatedDate"] = sDate;
                drOSR["Cntrctr_PWSent"] = 0;

                if (this.cboxStatus.SelectedIndex == 1)
                {
                    iStatus = 1;
                }
                else if (this.cboxStatus.SelectedIndex == 0)
                {
                    iStatus = 0;
                    drOSR["Cntrctr_DeactivatedDate"] = sDate;
                }
                else
                {
                    // Panic.
                }

                drOSR["ActiveStatus_Code"] = iStatus;
                drOSR["Cntrctr_MaxFiles"] = sCountMax;
                drOSR["Cntrctr_Notes"] = sNotes;

                // Place the DataRow into the DataSet.
                this.osrDataSet1.OSR_Contractor.Rows.Add(drOSR);

                // Update the database through the TableAdapter using the DataSet.
                this.oSR_ContractorTableAdapter.Update(osrDataSet1);

                // Notify the user that the database was updated successfully.
                MessageBox.Show("Record saved to database successfully.");

            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        private void EmailNew()
        {

            string sMysubject = string.Format("(ATTENTION) A new contractor has been added to the OSR database.");
            string sMybody = string.Format("(ATTENTION)" + " " + sFName + " " + sLName + " was added to the contractors database at " + sDate + ". Please setup the VPN" +
                " for this contractor.");

            try
            {
                EM.EmailNew(sEmailServer, sNewCntrctrSendToAdd, sEmailMyBccAdd, sMysubject, sMybody);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateRecordsToDatabase()
        {
            try
            {
                // Create a SqlConnection object to connect to the database, passing the connection string to the constructor.
                SqlConnection updateSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                // Create a SqlCommand object.
                SqlCommand updateSqlCommand = updateSqlConnection.CreateCommand();

                // Set the CommandText property of the SqlCommand object to a SQL UPDATE statement.
                //updateSqlCommand.CommandText = "UPDATE [OSRetouch].[dbo].[OSR_Contractor] SET [Cntrctr_MaxFiles] = @MaxFiles," +
                //    "[RetouchType_Code] = @RType, [Cntrctr_ActiveStatus] = @ActiveStatus WHERE [Cntrctr_ID] = @ID" +
                //    " AND [Cntrctr_FName] = @FName AND [Cntrctr_LName] = @LName";

                //updateSqlCommand.Parameters.Add("@MaxFiles", SqlDbType.Int);
                //updateSqlCommand.Parameters["@MaxFiles"].Value = this.txtCountMax.Text;
                //updateSqlCommand.Parameters.Add("@RType", SqlDbType.Int);
                //updateSqlCommand.Parameters["@RType"].Value = this.cboxRetouchType.SelectedIndex;
                //updateSqlCommand.Parameters.Add("@ActiveStatus", SqlDbType.Int);
                //updateSqlCommand.Parameters["@ActiveStatus"].Value = this.cboxStatus.SelectedIndex;
                //updateSqlCommand.Parameters.Add("@ID", SqlDbType.VarChar);
                //updateSqlCommand.Parameters["@ID"].Value = this.txtID.Text;
                //updateSqlCommand.Parameters.Add("@FName", SqlDbType.VarChar);
                //updateSqlCommand.Parameters["@FName"].Value = this.txtFName.Text;
                //updateSqlCommand.Parameters.Add("@LName", SqlDbType.VarChar);
                //updateSqlCommand.Parameters["@LName"].Value = this.txtLName.Text;


                // Build a dynamic SQL update statement.

                DateTime sDate = DateTime.Now;

                sID = this.txtID.Text;
                sFName = this.txtFName.Text;
                sLName = this.txtLName.Text;
                sAddress1 = this.txtAddress1.Text;
                sAddress2 = this.txtAddress2.Text;
                sCity = this.txtCity.Text;
                sZip = this.txtZip.Text;                
                sEmail1 = this.txtEmail1.Text;
                sEmail2 = this.txtEmail2.Text;
                sPhone1 = this.txtPhone1.Text;
                sPhone2 = this.txtPhone2.Text;
                sCountMax = this.txtCountMax.Text;
                sNotes = this.rtxtNotes.Text;



                bool combined = false; // In case of multiple search parameters.

                string SqlUpdate = @"UPDATE [OSRetouch].[dbo].[OSR_Contractor] SET";

                // Check the forms fields for data, concatenate the SQL update command based on entered field information.
                // I do not check/update the ID as that is the unique column that this query is based upon.
                if (!string.IsNullOrEmpty(sFName))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_FName] = \'" + sFName + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sLName))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_LName] = \'" + sLName + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sAddress1) || string.IsNullOrEmpty(sAddress1))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Add1] = \'" + sAddress1 + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sAddress2) || string.IsNullOrEmpty(sAddress2))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Add2] = \'" + sAddress2 + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sCity) || string.IsNullOrEmpty(sCity))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_City] = \'" + sCity + "\'";

                    combined = true;
                }

                if (this.cboxState.SelectedIndex != -1)
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [States_ID] = \'" + this.cboxState.SelectedIndex + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sZip) || string.IsNullOrEmpty(sZip))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Zip] = \'" + sZip + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sEmail1))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Email1] = \'" + sEmail1 + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sEmail2) || string.IsNullOrEmpty(sEmail2))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Email2] = \'" + sEmail2 + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sPhone1))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Phone1] = \'" + sPhone1 + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sPhone2) || string.IsNullOrEmpty(sPhone2))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Phone2] = \'" + sPhone2 + "\'";

                    combined = true;
                }

                if (this.cboxCarriersID.SelectedIndex != -1)
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Carriers_ID] = \'" + this.cboxCarriersID.SelectedIndex + "\'";

                    combined = true;
                }

                if (this.cboxRetouchType.SelectedIndex != -1)
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [RetouchType_Code] = \'" + this.cboxRetouchType.SelectedIndex + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sCountMax))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_MaxFiles] = \'" + sCountMax + "\'";

                    combined = true;
                }

                if (!string.IsNullOrEmpty(sNotes))
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    SqlUpdate += " [Cntrctr_Notes] = \'" + sNotes + "\'";

                    combined = true;
                }

                // Check to see if the form activity status is different from the records activity status
                // and set a date/time based on whether it has been deactivated or reactivated.
                if (this.cboxStatus.SelectedIndex != -1)
                {
                    if (combined)
                    {
                        SqlUpdate += ",";
                    }

                    if (this.osrDataSet1.OSR_Contractor[0].ActiveStatus_Code == 0)
                    {
                        if (this.cboxStatus.SelectedIndex == 1)
                        {
                            SqlUpdate += " [ActiveStatus_Code] = \'" + this.cboxStatus.SelectedIndex + "\'" +
                                ",[Cntrctr_ReactivatedDate] = \'" + sDate + "\'";
                        }
                        else
                        {
                            SqlUpdate += " [ActiveStatus_Code] = \'" + this.cboxStatus.SelectedIndex + "\'";
                        }
                    }
                    // !!!!!*****ATTENTION*****!!!!!
                    // Need to update the orders table OrderStatus_Code = 4 based on Cntrctr_ID for any active orders at time of setting the
                    // contractor status to "Inactive" to keep the lblTotalCount.Text on ContractorQueueing form correct.
                    if (this.osrDataSet1.OSR_Contractor[0].ActiveStatus_Code == 1)
                    {
                        if (this.cboxStatus.SelectedIndex == 0)
                        {
                            SqlUpdate += " [ActiveStatus_Code] = \'" + this.cboxStatus.SelectedIndex + "\'" +
                                ",[Cntrctr_DeactivatedDate] = \'" + sDate + "\'";
                        }
                        else
                        {
                            SqlUpdate += " [ActiveStatus_Code] = \'" + this.cboxStatus.SelectedIndex + "\'";
                        }
                    }

                    combined = true;
                }

                SqlUpdate += " WHERE [Cntrctr_ID] = \'" + sID + "\'";



                // Set the CommandText property of the SqlCommand object to a SQL UPDATE statement.
                updateSqlCommand.CommandText = SqlUpdate;

                // Open the database connection using the Open() method of the SqlConnection object.
                updateSqlConnection.Open();

                // Set the timeout of the SqlCommand object.
                updateSqlCommand.CommandTimeout = 0;

                // Create a SqlCommand object and call the ExecuteNonQuery() method of the SqlCommand object to run
                // the UPDATE statement.
                updateSqlCommand.ExecuteNonQuery();

                // Notify the user that the database was updated successfully.
                MessageBox.Show("Database updated successfully.");

                // Free resources used by the SqlCommand object.
                updateSqlCommand.Dispose();

                // Close and free resources used by the SqlConnection object.
                updateSqlConnection.Close();
                updateSqlConnection.Dispose();
            }

            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }

            // After a record update, reset the form to its initial status.
            this.ClearForm();
        }

        private void SearchDatabase()
        {
            try
            {
                // Create a SqlConnection object to connect to the database, passing the connection string to the constructor.
                SqlConnection searchSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                // Create a SqlCommand object.
                SqlCommand searchSqlCommand = searchSqlConnection.CreateCommand();

                // Set the CommandText property of the SqlCommand object to a SQL SELECT statement.
                searchSqlCommand.CommandText = "SELECT * FROM [OSRetouch].[dbo].[OSR_Contractor] WHERE [Cntrctr_ID] = @ID";

                searchSqlCommand.Parameters.Add("@ID", SqlDbType.VarChar);
                searchSqlCommand.Parameters["@ID"].Value = this.txtID.Text;

                // Open the database connection using the Open() method of the SqlConnection object.
                searchSqlConnection.Open();

                // Set the timeout of the SqlCommand object.
                searchSqlCommand.CommandTimeout = 0;

                // Create a SqlDataAdapter object.
                SqlDataAdapter searchSqlDataAdapter = new SqlDataAdapter(searchSqlCommand.CommandText, searchSqlConnection);

                // Set the SqlCommand as the SelectCommand.
                searchSqlDataAdapter.SelectCommand = searchSqlCommand;

                // Create a SqlDataReader object and call the ExecuteReader() method of the SqlCommand object to run
                // the SELECT statement.
                SqlDataReader searchSqlDataReader = searchSqlCommand.ExecuteReader();

                // Clear items from previous search.
                this.osrDataSet1.OSR_Contractor.Clear();

                // Load the data into the SqlDataReader object.
                this.osrDataSet1.OSR_Contractor.Load(searchSqlDataReader);


                // Populate the form fields via the DataSet if a result is returned.
                if (this.osrDataSet1.OSR_Contractor.Rows.Count == 1)
                {
                    try
                    {
                        this.txtID.Text = Convert.ToString(this.osrDataSet1.OSR_Contractor.Rows[0]["Cntrctr_ID"]).Trim();
                        this.txtFName.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_FName;
                        this.txtLName.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_LName;
                        this.txtAddress1.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Add1;
                        this.txtAddress2.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Add2;
                        this.txtCity.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_City;

                        if (this.osrDataSet1.OSR_Contractor[0]["States_ID"] == DBNull.Value)
                        {
                            this.cboxState.SelectedIndex = -1;
                        }
                        else
                        {
                            this.cboxState.SelectedIndex = this.osrDataSet1.OSR_Contractor[0].States_ID;
                        }

                        this.txtZip.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Zip;
                        this.txtEmail1.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Email1;
                        this.txtEmail2.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Email2;
                        this.txtPhone1.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Phone1;
                        this.txtPhone2.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Phone2;
                        this.txtCountMax.Text = Convert.ToString(this.osrDataSet1.OSR_Contractor.Rows[0]["Cntrctr_MaxFiles"]).Trim();
                        this.cboxRetouchType.SelectedIndex = this.osrDataSet1.OSR_Contractor[0].RetouchType_Code;
                        this.cboxStatus.SelectedIndex = this.osrDataSet1.OSR_Contractor[0].ActiveStatus_Code;

                        if (this.osrDataSet1.OSR_Contractor[0]["Carriers_ID"] == DBNull.Value)
                        {
                            this.cboxCarriersID.SelectedIndex = -1;
                        }
                        else
                        {
                            this.cboxCarriersID.SelectedIndex = this.osrDataSet1.OSR_Contractor[0].Carriers_ID;
                        }
                        if (this.rtxtNotes.Text != string.Empty)
                        {
                            this.rtxtNotes.Text = "";
                        }
                        if (this.osrDataSet1.OSR_Contractor[0]["Cntrctr_Notes"] != DBNull.Value)
                        {
                            this.rtxtNotes.Text = this.osrDataSet1.OSR_Contractor[0].Cntrctr_Notes;
                        }                        

                    }
                    catch (Exception ex)
                    {
                        sException = ex.ToString().Trim();
                        this.SaveExceptionToDB();
                        MessageBox.Show(ex.Message);
                    }

                    // If a record is returned then setup for updating the record rather than saving as new.
                    this.btnCancel.Enabled = true;
                    this.btnSave.Text = "&Update";
                    bSave = false;
                    this.Refresh();
                }
                
                // If no result is returned then proceed in "Save" mode.
                else if (this.osrDataSet1.OSR_Contractor.Rows.Count != 1)
                {
                    bSave = true;
                    this.btnCancel.Enabled = true;
                }

                searchSqlCommand.Dispose();

                searchSqlDataReader.Close();
                searchSqlDataReader.Dispose();

                searchSqlDataAdapter.Dispose();

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

        private void ReadyToSave()
        {
            // If in "Save" mode (no results from on leave ID SQL query event) then check if required bools are true for record saving.
            if (bSave == true)
            {
                // Use bools set on the leave events that determine if the record has the required information to be saved.
                if (bFName && bLName && bEmail1 && bRType && bMCount && bStatus)
                    this.btnSave.Enabled = true;
                else
                    this.btnSave.Enabled = false;
            }
            // If not in "Save" mode (results from on leave ID SQL query) then activate the Save button (labeled "Update" now).
            else if (bSave == false)
            {
                this.btnSave.Enabled = true;
            }
        }

        private void GetID()
        {
            // Parent form loses focus while child form is open.
            this.Enabled = false;
            // When returning to this form from the ContractorDatabase form pull in the selected record ID
            // if the double click event was triggered on the ContractorsDatabase form.
            if (this.ConDB.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.txtID.Text = Convert.ToString(ConDB.sContractorID);
                this.SearchDatabase();
            }
            // Parent form regains focus once child form is closed.
            this.Enabled = true;
        }

        private void GetVariableInfo()
        {
            try
            {

                DataTable dt = new DataTable();

                SqlConnection myConn = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                SqlCommand myCommand = myConn.CreateCommand();

                myCommand.CommandText = "SELECT * FROM [OSRetouch].[dbo].[OSR_Variables] WHERE [Variables_VariableName] = 'VPN_CC_Email_Adds' OR " +
                    "[Variables_VariableName] = 'APS_Email_Server' OR [Variables_VariableName] = 'APS_Email_Server_FromAdd' OR " +
                    "[Variables_VariableName] = 'APS_Email_My_BCC' OR [Variables_VariableName] = 'APS_Email_Error_Sendto' OR [Variables_VariableName] = 'OSR_NewCntrctrSetup_SendToAdd'";

                myConn.Open();

                myCommand.CommandTimeout = 0;

                SqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    dt.Load(myReader);

                    sSendtoAdd2 = Convert.ToString(dt.Rows[0]["Variables_Variable"]).Trim(); // email to other aps employees
                    sEmailServer = Convert.ToString(dt.Rows[1]["Variables_Variable"]).Trim(); // email server
                    sEmailFromAdd = Convert.ToString(dt.Rows[2]["Variables_Variable"]).Trim(); // from addy
                    sEmailMyBccAdd = Convert.ToString(dt.Rows[3]["Variables_Variable"]).Trim(); // my internal email addy
                    sEmailMyErrorSendAdd = Convert.ToString(dt.Rows[4]["Variables_Variable"]).Trim(); // my gmail email
                    sNewCntrctrSendToAdd = Convert.ToString(dt.Rows[5]["Variables_Variable"]).Trim(); // bills internal email

                }

                else
                {
                    myReader.Close();
                    myReader.Dispose();

                    myCommand.Dispose();

                    myConn.Close();
                    myConn.Dispose();

                    return;
                }

                myReader.Close();
                myReader.Dispose();

                myCommand.Dispose();

                myConn.Close();
                myConn.Dispose();

                dt.Clear();
                dt.Dispose();

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

        private void ClearForm()
        {
            // Clear all textboxes on form, set SelectedIndex on comboboxes.
            this.txtFName.Text = string.Empty;
            this.txtLName.Text = string.Empty;
            this.txtAddress1.Text = string.Empty;
            this.txtAddress2.Text = string.Empty;
            this.txtCity.Text = string.Empty;
            this.cboxState.SelectedIndex = -1;
            this.txtZip.Text = string.Empty;
            this.txtID.Text = string.Empty;
            this.txtEmail1.Text = string.Empty;
            this.txtEmail2.Text = string.Empty;
            this.txtPhone1.Text = string.Empty;
            this.txtPhone2.Text = string.Empty;
            this.txtCountMax.Text = string.Empty;
            this.cboxStatus.SelectedIndex = -1;
            this.cboxRetouchType.SelectedIndex = -1;
            this.cboxCarriersID.SelectedIndex = -1;
            this.rtxtNotes.Text = string.Empty;

            // Reset the save ready flags.
            //bID = false;
            bFName = false;
            bLName = false;
            bEmail1 = false;
            bMCount = false;
            bRType = false;
            bStatus = false;

            sID = "";
            sFName = "";
            sLName = "";
            sAddress1 = "";
            sAddress2 = "";
            sCity = "";
            sZip = "";
            sEmail1 = "";
            sEmail2 = "";
            sPhone1 = "";
            sPhone2 = "";
            iRetType = 0;
            iCarrierID = 0;
            sCountMax = "";
            sNotes = "";

            sSendtoAdd2 = "";
            sEmailServer = "";
            sEmailFromAdd = "";
            sEmailMyBccAdd = "";
            sEmailMyErrorSendAdd = "";
            sNewCntrctrSendToAdd = "";

            sException = "";

            // Reset the mode to "Save".
            bSave = true;

            // Set the buttons inactive until new data is entered into the textboxes.
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;

            // Set the text back to default.
            this.btnSave.Text = "&Save";

            // Set the focus to the first name textbox.
            this.ActiveControl = this.txtFName;

            // Reset read only fields if in edit mode.
            //this.txtID.ReadOnly = false;
            this.txtFName.ReadOnly = false;
            this.txtLName.ReadOnly = false;

            // Refresh the form.
            this.Refresh();
        }

        #endregion

    }
}
