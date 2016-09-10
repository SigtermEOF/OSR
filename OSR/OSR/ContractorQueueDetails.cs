/* **********************************************************************************************************************************
 * **********************************************************************************************************************************
 * -- Copyright (c) Advanced Photographics Solutions 2013. All rights reserved.
 * 
 *  <file name='Contractor Queueing Details' />
 *  <solution name='OSR' />
 *  <project name='OSR' />
 *  <developmentlab name='Advanced Photographic Solutions' />
 *  <developementteam name='Jason Lett' initials='jrl' />
 * 
 *  <class name'ContractorQueueDetails'>
 *  <description>
 *  (O)ff (S)ite (R)etouching form for queueing details amongst contractors/jobs.
 *  
 *      -
 *      - 
 *  </description>
 *  </class>
 * 
 * <updatelog>
 * ===================================================================================================================================================
 * <update number='' version='' fileversion='' date='' request='' author=''> </update>
 * <update number='0' version='0.0.0.0' fileversion='0.0.0.0' date='01 November 2013' request='DEVELOPMENT' author='jrl'> Initial Version of File - ALL INITIAL DEVELOPMENT </update>
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
using System.IO;

namespace OSR
{
    public partial class ContractorQueueDetails : Form
    {

        string sFname = "";

        string sLname = "";

        string sRefNum = "";

        string sProdNum = "";

        string sQueryString = "";

        string sTotalCount = "";

        DataTable dtTotalCount = new DataTable();

        string sException = "";

        string sID = string.Empty;

        string sConID = string.Empty;



        public ContractorQueueDetails(string sIncomingID)
        {
            InitializeComponent();

            sConID = sIncomingID;
        }

        private void ContractorQueueDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'osrDataSet1.OSR_Errors' table. You can move, or remove it, as needed.
            this.oSR_ErrorsTableAdapter.Fill(this.osrDataSet1.OSR_Errors);
            this.dataGridView1.Columns.Clear();
            this.SearchForOrders();
            this.CreateButtonColumn();
        }

        private void SearchForOrders()
        {
            try
            {

                sQueryString = string.Format("SELECT [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName]," +
                    " [Orders_ProdNum], [Orders_RefNum], [Orders_Count], [Orders_QueueDate], [Orders_SentDate]," +
                    " [Orders_DueDate], [Orders_ReceivedDate], [Orders_Error], [Orders_ErrorDate], [Orders_ErrorMsg]," +
                    " [OSR_Contractor].[Cntrctr_ID] FROM " +
                "[OSRetouch].[dbo].[OSR_Orders], [OSRetouch].[dbo].[OSR_Contractor]" +
                    " WHERE [OSR_Contractor].[Cntrctr_ID] = '{0}' AND OSR_Orders.Cntrctr_ID = " +
                    " OSR_Contractor.Cntrctr_ID", sConID);                
                
                SqlConnection searchSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);
                
                SqlDataAdapter searchSqlDataAdapter = new SqlDataAdapter(sQueryString, searchSqlConnection);

                SqlCommandBuilder SqlCB = new SqlCommandBuilder(searchSqlDataAdapter);

                DataSet ds = new DataSet();

                ds.Clear();

                searchSqlDataAdapter.Fill(ds);

                DataTable dtSearch = ds.Tables[0];

                if (dtSearch.Rows.Count > 0)
                {
                    sFname = Convert.ToString(dtSearch.Rows[0]["Cntrctr_FName"]).Trim();
                    sLname = Convert.ToString(dtSearch.Rows[0]["Cntrctr_LName"]).Trim();
                    sID = Convert.ToString(dtSearch.Rows[0]["Cntrctr_ID"]).Trim();
                    sRefNum = Convert.ToString(dtSearch.Rows[0]["Orders_RefNum"]).Trim();
                }

                foreach (DataRow dr in dtSearch.Rows)
                {
                    dr["Cntrctr_Fname"] = sFname + " " + sLname + " [" + sID + "]";
                }

                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Cntrctr_FName"].DisplayIndex = 0;
                dataGridView1.Columns[0].HeaderText = "Contractor";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Cntrctr_LName"].DisplayIndex = 1;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns["Orders_ProdNum"].DisplayIndex = 2;
                dataGridView1.Columns[2].HeaderText = "Prod #";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_RefNum"].DisplayIndex = 3;
                dataGridView1.Columns[3].HeaderText = "Ref #";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_Count"].DisplayIndex = 4;
                dataGridView1.Columns[4].HeaderText = "Count";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_QueueDate"].DisplayIndex = 5;
                dataGridView1.Columns[5].HeaderText = "Queued";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_SentDate"].DisplayIndex = 6;
                dataGridView1.Columns[6].HeaderText = "Sent";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_DueDate"].DisplayIndex = 7;
                dataGridView1.Columns[7].HeaderText = "Due";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_ReceivedDate"].DisplayIndex = 8;
                dataGridView1.Columns[8].HeaderText = "Received";
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_Error"].DisplayIndex = 9;
                dataGridView1.Columns[9].HeaderText = "Error";
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_ErrorDate"].DisplayIndex = 10;
                dataGridView1.Columns[10].HeaderText = "Error Date";
                dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_ErrorMsg"].DisplayIndex = 11;
                dataGridView1.Columns[11].HeaderText = "Error Message";
                dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Cntrctr_ID"].DisplayIndex = 12;
                dataGridView1.Columns[12].Visible = false;

                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateButtonColumn()
        {
            DataGridViewButtonColumn buttonColumnDetails = new DataGridViewButtonColumn();
            buttonColumnDetails.Name = "WorkToDo";
            buttonColumnDetails.HeaderText = "WorkToDo";
            buttonColumnDetails.Text = "WorkToDo";
            buttonColumnDetails.UseColumnTextForButtonValue = true;
            dataGridView1.AutoSize = false;
            buttonColumnDetails.Width = 100;
            dataGridView1.Columns.Insert(13, buttonColumnDetails);
            dataGridView1.Columns["WorkToDo"].DisplayIndex = 13;
            dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ContractorQueueDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Clear();
        }

        private void ImageCount()
        {
            try
            {
                string tcQueryString = string.Format("SELECT [Jobs_Filename], [OSR_Jobs].[Orders_ProdNum] FROM [OSR_Jobs] FULL OUTER JOIN [OSR_Orders] ON " +
                "[OSR_Jobs].[Orders_ProdNum] = [OSR_Orders].[Orders_ProdNum] WHERE [OSR_Orders].[Orders_ProdNum] = '{0}'", sProdNum);

                SqlConnection tcSqlConnection = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString);

                SqlCommand tcSqlCommand = tcSqlConnection.CreateCommand();

                tcSqlCommand.CommandText = tcQueryString;

                tcSqlConnection.Open();

                SqlDataAdapter tcSqlDataAdapter = new SqlDataAdapter(tcQueryString, tcSqlConnection);

                SqlCommandBuilder SqlCB = new SqlCommandBuilder(tcSqlDataAdapter);

                SqlDataReader tcSqlDataReader = tcSqlCommand.ExecuteReader();

                if (tcSqlDataReader.HasRows)
                {
                    dtTotalCount.Load(tcSqlDataReader);
                }

                else
                {
                    tcSqlDataReader.Close();
                    tcSqlDataReader.Dispose();

                    tcSqlCommand.Dispose();

                    tcSqlConnection.Close();
                    tcSqlConnection.Dispose();

                    return;
                }

                sTotalCount = dtTotalCount.Rows.Count.ToString().Trim();

                tcSqlDataReader.Close();
                tcSqlDataReader.Dispose();

                tcSqlCommand.Dispose();

                tcSqlConnection.Close();
                tcSqlConnection.Dispose();
            }
            catch (Exception ex)
            {
                sException = ex.ToString().Trim();
                this.SaveExceptionToDB();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Trace.WriteLine("Column Index:" + " " + e.ColumnIndex.ToString() + " , " + "Row Index:" + " " + e.RowIndex.ToString());

            if (e.RowIndex >= 0)
            {
                try
                {

                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        sProdNum = dataGridView1[2, e.RowIndex].Value.ToString().Trim();

                        this.ImageCount();

                        if (e.ColumnIndex == 13)
                        {
                            SqlDataReader reader;
                            string sQuery = String.Format("SELECT [Jobs_Filename],[Jobs_Descript] FROM [OSRetouch].[dbo].[OSR_Jobs] WHERE [Orders_ProdNum] = '{0}'", sProdNum);

                            string sDelimiter = "                    ";

                            string sFilePath = string.Format(@"c:\temp\{0}.txt", sProdNum);

                            using (SqlConnection conn = new SqlConnection(OSR.Properties.Settings.Default.OSRetouchConnectionString))
                            {
                                conn.Open();

                                using (reader = new SqlCommand(sQuery, conn).ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        Object[] items = new Object[reader.FieldCount];

                                        sb.AppendFormat("Production #: {0}", sProdNum);
                                        sb.Append("          ");
                                        sb.AppendFormat("Reference #: {0}", sRefNum);
                                        sb.Append("\n");

                                        sb.AppendFormat("Images: {0}", sTotalCount);
                                        sb.Append("\n");

                                        sb.Append("------------------------------------------------------------");
                                        sb.Append("\n");

                                        sb.Append("  Image Name" + "                              " + "Retouch Type");
                                        sb.Append("\n");

                                        sb.Append("------------------------------------------------------------");
                                        sb.Append("\n");

                                        while (reader.Read())
                                        {
                                            reader.GetValues(items);

                                            foreach (var item in items)
                                            {
                                                sb.Append(item.ToString().Trim());
                                                sb.Append(sDelimiter);
                                            }

                                            if (sb.ToString().EndsWith(", "))
                                                sb = sb.Remove(sb.Length - 2, 2);

                                            sb.Append("\n");
                                        }
                                        reader.Close();
                                        reader.Dispose();
                                        conn.Close();
                                        conn.Dispose();
                                        File.WriteAllText(sFilePath, sb.ToString());
                                        Process.Start(sFilePath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No work details available for this job.");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    sException = ex.ToString().Trim();
                    this.SaveExceptionToDB();
                    MessageBox.Show(ex.Message);
                }
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
            sFname = "";
            sLname = "";
            sID = "";
            sRefNum = "";
            sProdNum = "";
            sQueryString = "";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Refresh();
        }

    }
}
