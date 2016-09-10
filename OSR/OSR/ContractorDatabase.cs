/* **********************************************************************************************************************************
 * **********************************************************************************************************************************
 * -- Copyright (c) Advanced Photographics Solutions 2013. All rights reserved.
 * 
 *  <file name='Contractor Database' />
 *  <solution name='OSR' />
 *  <project name='OSR' />
 *  <developmentlab name='Advanced Photographic Solutions' />
 *  <developementteam name='Jason Lett' initials='jrl' />
 * 
 *  <class name'Contractor Database'>
 *  <description>
 *  (O)ff (S)ite (R)etouching form for displaying a list of contractors in the database.
 *  
 *      -
 *      - 
 *  </description>
 *  </class>
 * 
 * <updatelog>
 * ===================================================================================================================================================
 * <update number='' version='' fileversion='' date='' request='' author=''> </update>
 * <update number='0' version='0.0.0.0' fileversion='0.0.0.0' date='10 October 2013' request='DEVELOPMENT' author='jrl'> Initial Version of File - ALL INITIAL DEVELOPMENT </update>
 * </updatelog>
 * ===================================================================================================================================================
 * 
********************************************************************************************************************************** */

//*****************************
#define Development
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
    public partial class ContractorDatabase : Form
    {

        // Set a public int to pass the value of the selected row on the double click event back to the parent form.
        /// <summary>
        /// 
        /// </summary>
        public string sContractorID;

        string sException = "";

        /// <summary>
        /// 
        /// </summary>
        public ContractorDatabase()
        {
            InitializeComponent();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_Errors' table. You can move, or remove it, as needed.
            this.oSR_ErrorsTableAdapter.Fill(this.osrDataSet1.OSR_Errors);
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_Carriers' table. You can move, or remove it, as needed.
            this.oSR_CarriersTableAdapter.Fill(this.osrDataSet1.OSR_Carriers);
            // Load data into the tables for comboboxes nested in datagrid.
            this.oSR_RetouchTypeTableAdapter.Fill(this.osrDataSet1.OSR_RetouchType);
            this.oSR_ActiveStatusTableAdapter.Fill(this.osrDataSet1.OSR_ActiveStatus);
            this.oSR_StatesTableAdapter.Fill(this.osrDataSet1.OSR_States);

            try
            {
                // Create a SqlConnection object to connect to the database, passing the connection string to the constructor.
                SqlConnection oSRRecordsConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                // Create a SqlCommand object.
                SqlCommand oSRRecordsCommand = oSRRecordsConnection.CreateCommand();

                // Set the CommandText property of the SqlCommand object to a SQL SELECT statement.
                oSRRecordsCommand.CommandText = "SELECT * FROM OSRetouch.dbo.OSR_Contractor ORDER BY [Cntrctr_ID] ASC";

                // Open the database connection using the Open() method of the SqlConnection object.
                oSRRecordsConnection.Open();

                // Set the timeout of the SqlCommand object.
                oSRRecordsCommand.CommandTimeout = 0;

                // Create a SqlDataReader object and call the ExecuteReader() method of the SqlCommand object to run
                // the SELECT statement.
                SqlDataReader oSRRecordsDataReader = oSRRecordsCommand.ExecuteReader();

                // Clear items from previous search.
                this.osrDataSet1.OSR_Contractor.Clear();

                // Load the data into the SqlDataReader object.
                this.osrDataSet1.OSR_Contractor.Load(oSRRecordsDataReader);

                // Close and free resources used by the SqlDataReader object.
                oSRRecordsDataReader.Close();
                oSRRecordsDataReader.Dispose();

                // Free resources used by the SqlCommand object.
                oSRRecordsCommand.Dispose();

                // Close and free resources used by the SqlConnection object.
                oSRRecordsConnection.Close();
                oSRRecordsConnection.Dispose();

            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }

        }

        // Feed the selected row back into the parent form on double click and close this form.
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.sContractorID = Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[0].Value);

            this.Close();  
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

    }
}
