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
    public partial class ContractorQueueing : Form
    {
        TaskMethods TM2 = null;
        string sOSRConnString = OSR.Properties.Settings.Default.OSRetouchConnectionString.ToString();
        string sCDSConnString = OSR.Properties.Settings.Default.CDSConnString.ToString();

        private ContractorMaintenance ConMaintenance = null;
        private EditRetouchCodes EditRetCodes = null;
        DataTable dtTotalCount = new DataTable();
        DataTable dtTotalJobs = new DataTable();
        DataTable dtSearch1 = new DataTable();
        DataTable dtSearch2 = new DataTable();
        DataTable dtSearch3 = new DataTable();
        DataTable dtSearchFinal = new DataTable();
        DataSet dsContractorSearch = new DataSet();

        public ContractorQueueing()
        {
            InitializeComponent();

            TM2 = new TaskMethods();

            ConMaintenance = new ContractorMaintenance();
            EditRetCodes = new EditRetouchCodes();
        }

        private void ContractorQueueing_Load(object sender, EventArgs e)
        {
            this.SearchForContractors();
            this.RowWarning();
            int iJobCount = 0;
            this.TotalJobs(ref iJobCount);
            this.TotalCount(iJobCount);

            DataTable dTbl = new DataTable();
            string sCommText = "SELECT * FROM [OSR_ChangeLog] WHERE [App] = 'Main'";
            string sValue = string.Empty;
            string sColumn = "Version";

            TM2.SQLQueryWithReturnValue(sOSRConnString, sCommText, dTbl, ref sValue, sColumn);

            this.Text = "O.S.R. " + sValue;

            Application.DoEvents();
        }

        #region Form Events.

        private void ContractorQueueing_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.SearchForContractors();
            this.RowWarning();
            int iJobCount = 0;
            this.TotalJobs(ref iJobCount);
            this.TotalCount(iJobCount);
            this.txtboxSearch.Text = string.Empty;
            this.txtboxSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtboxSearch.Text != string.Empty)
            {
                this.SearchForJobs();
                int iJobCount = 0;
                this.TotalJobs(ref iJobCount);
                this.TotalCount(iJobCount);
                this.RowWarning();
            }
            else
            {
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Trace.WriteLine("Column Index:" + " " + e.ColumnIndex.ToString() + " , " + "Row Index:" + " " + e.RowIndex.ToString());

            // Do not attempt to pass a value to child form if a header is clicked.
            if (e.RowIndex >= 0)
            {
                // Capture the ID and set that value for passing off to a child form.
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    string sOutgoingID2 = dataGridView1[3, e.RowIndex].Value.ToString().Trim();
                    string sOutgoingID = dataGridView1[4, e.RowIndex].Value.ToString().Trim();

                    // If the user clicks the Details button in the datagridview then open the child form.
                    if (e.ColumnIndex == 5)
                    {
                        if (sOutgoingID != string.Empty || sOutgoingID != "0")
                        {
                            this.Enabled = false;
                            ContractorQueueDetails ConQueueDetails = new ContractorQueueDetails(sOutgoingID);
                            ConQueueDetails.ShowDialog();
                            this.Enabled = true;
                        }
                    }

                    // If the user clicks the Queue button in the datagridview then open the child form.
                    if (e.ColumnIndex == 6)
                    {
                        this.Enabled = false;
                        OrderSending OS = new OrderSending(sOutgoingID);
                        OS.ShowDialog();
                        this.Enabled = true;
                        this.Clear();
                        this.SearchForContractors();
                        int iJobCount = 0;
                        this.TotalJobs(ref iJobCount);
                        this.TotalCount(iJobCount);
                        this.RowWarning();
                    }
                }

                else
                {
                    return;
                }
            }
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTipRefresh = new ToolTip();
            toolTipRefresh.SetToolTip(this.btnRefresh, "Refresh");
        }

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

        private void contractorMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.ConMaintenance.ShowDialog();
            this.Enabled = true;
            this.Clear();
            int iJobCount = 0;
            this.TotalJobs(ref iJobCount);
            this.TotalCount(iJobCount);
            this.SearchForContractors();
            this.RowWarning();
        }

        private void retouchCodeMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.EditRetCodes.ShowDialog();
            this.Enabled = true;
            this.Clear();
            int iJobCount = 0;
            this.TotalJobs(ref iJobCount);
            this.TotalCount(iJobCount);
            this.SearchForContractors();
            this.RowWarning();
        }

        #endregion


        #region Task methods.

        private void SearchForContractors()
        {

            this.SearchOne();
            this.SearchTwo();
            this.SearchThree();

            this.dataGridView1.Columns.Clear();

            dtSearch1.TableName = "A";

            if (!dsContractorSearch.Tables.Contains(dtSearch1.TableName))
                dsContractorSearch.Tables.Add(dtSearch1);

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = dsContractorSearch.Tables[dtSearch1.TableName];

            dataGridView1.AutoGenerateColumns = false;

            if (dtSearch1.Rows.Count >= 1)
            {

                dataGridView1.Columns["Cntrctr_FName"].DisplayIndex = 0;
                dataGridView1.Columns[0].HeaderText = "First Name";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Cntrctr_LName"].DisplayIndex = 1;
                dataGridView1.Columns[1].HeaderText = "Last Name";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Cntrctr_MaxFiles"].DisplayIndex = 2;
                dataGridView1.Columns[2].HeaderText = "Max Files";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Orders_Count"].DisplayIndex = 3;
                dataGridView1.Columns[3].HeaderText = "Current Count";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Cntrctr_ID"].DisplayIndex = 4;
                dataGridView1.Columns[4].HeaderText = "ID";
                dataGridView1.Columns[4].Visible = false;

                DataGridViewButtonColumn buttonColumnDetails = new DataGridViewButtonColumn();
                buttonColumnDetails.Name = "Details";
                buttonColumnDetails.HeaderText = "Details";
                buttonColumnDetails.Text = "Details";
                buttonColumnDetails.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(5, buttonColumnDetails);
                dataGridView1.Columns["Details"].DisplayIndex = 5;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewButtonColumn buttonColumnSend = new DataGridViewButtonColumn();
                buttonColumnSend.Name = "Queue";
                buttonColumnSend.HeaderText = "Queue";
                buttonColumnSend.Text = "Queue";
                buttonColumnSend.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(6, buttonColumnSend);
                dataGridView1.Columns["Queue"].DisplayIndex = 6;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Descending);
            }

            this.dataGridView1.Refresh();
            Application.DoEvents();
            this.Refresh();

        }
        
        // Gather all newly active contractors which have never had work assigned.
        private void SearchOne()
        {
            try
            {
                dtSearch1.Clear();

                DataTable dTbl = new DataTable();
                // Gather FName, LName, MaxFiles, and set the Order_Count to 0 from OSR_Orders where  OSR_Orders.Cntrctr_ID = OSR_Contractor.Cntrctr_ID
                // but exclude any contractors also listed in the Orders table and finally only list those contractors that are flagged as Active.
                // Order_Count is set to 0 to simply keep the DGV consistent among all queries(Order_Count on a new contractor would obviously be 0).
                string sCommText = "SELECT [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName]," +
                " [OSR_Contractor].[Cntrctr_MaxFiles], 0 AS [Orders_Count]," +
                " [OSR_Contractor].[Cntrctr_ID] FROM [OSR_Orders] FULL OUTER JOIN [OSR_Contractor] ON [OSR_Orders].[Cntrctr_ID] = " +
                "[OSR_Contractor].[Cntrctr_ID] WHERE [OSR_Contractor].[Cntrctr_ID] NOT IN (SELECT [Cntrctr_ID] FROM [OSR_Orders]) " +
                "AND [OSR_Contractor].[ActiveStatus_Code] != 0";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dtSearch1.Merge(dTbl);
                }
                else if (dTbl.Rows.Count == 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        // Gather all active contractors who have had work assigned.
        private void SearchTwo()
        {
            try
            {
                dtSearch2.Clear();

                DataTable dTbl = new DataTable();
                // Gather FName, LName, MaxFiles, sum Orders_Count from OSR_Orders where OSR_Orders.Cntrctr_ID = OSR_Contractor.Cntrctr_ID
                // where contractor is flagged as Active and OrderStatus_Code = Queued or Sent.
                string sCommText = "SELECT [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName]," +
                " [OSR_Contractor].[Cntrctr_MaxFiles], SUM([OSR_Orders].[Orders_Count]) AS [Orders_Count]," +
                " [OSR_Contractor].[Cntrctr_ID] FROM [OSR_Orders] FULL OUTER JOIN [OSR_Contractor] ON [OSR_Orders].[Cntrctr_ID] = " +
                "[OSR_Contractor].[Cntrctr_ID] WHERE [OSR_Contractor].[ActiveStatus_Code] != 0" +
                 " AND ([OrderStatus_Code] = 1 OR [OrderStatus_Code] = 2)" +
                 " GROUP BY [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName], [OSR_Contractor].[Cntrctr_MaxFiles]," +
                " [OSR_Contractor].[Cntrctr_ID]";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dtSearch2.Merge(dTbl);

                    dtSearch1.Merge(dtSearch2);
                }
                else if (dTbl.Rows.Count == 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        // Gather all active contractors who have had work assigned and completed.
        private void SearchThree()
        {
            try
            {
                dtSearch3.Clear();

                DataTable dTbl = new DataTable();
                // Gather distinct (to prevent duplicate records for a single contractor who has completed multiple orders) FName, LName, MaxFiles,
                // and set the Order_Count to 0 from OSR_Orders where  OSR_Orders.Cntrctr_ID = OSR_Contractor.Cntrctr_ID
                // but exclude any contractors who also have orders currently Queued or Sent(to avoid duplicate records in the DGV) or are flagged as Inactive and finally
                // only gather orders marked as Returned or Error'd.
                // Order_Count is set to 0 to avoid displaying a count in DGV that would give the impression that the contractor currently has live orders.
                string sCommText = "SELECT DISTINCT [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName]," +
                " [OSR_Contractor].[Cntrctr_MaxFiles], 0 AS [Orders_Count]," +
                " [OSR_Contractor].[Cntrctr_ID] FROM [OSR_Orders] FULL OUTER JOIN [OSR_Contractor] ON [OSR_Orders].[Cntrctr_ID] = " +
                "[OSR_Contractor].[Cntrctr_ID] WHERE [OSR_Contractor].[Cntrctr_ID] NOT IN (SELECT [Cntrctr_ID] FROM [OSR_Orders] WHERE " +
                "[OrderStatus_Code] = 1 OR [OrderStatus_Code] = 2) AND [OSR_Contractor].[ActiveStatus_Code] != 0" +
                 " AND ([OrderStatus_Code] = 3 OR [OrderStatus_Code] = 4)";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dtSearch3.Merge(dTbl);

                    dtSearch1.Merge(dtSearch3);
                }
                else if (dTbl.Rows.Count == 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }        

        private void SearchForJobs()
        {
            try
            {
                this.dataGridView1.Columns.Clear();

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT [OSR_Contractor].[Cntrctr_FName], [OSR_Contractor].[Cntrctr_LName]," +
                " [OSR_Contractor].[Cntrctr_MaxFiles], [OSR_Orders].[Orders_Count]," +
                " [OSR_Contractor].[Cntrctr_ID] FROM [OSR_Orders] FULL OUTER JOIN [OSR_Contractor] ON [OSR_Orders].[Cntrctr_ID] = " +
                "[OSR_Contractor].[Cntrctr_ID] WHERE" +
                " [Orders_ProdNum] = '" + txtboxSearch.Text.Trim() + "'";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.DataSource = dTbl;

                    dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.Columns["Cntrctr_FName"].DisplayIndex = 0;
                    dataGridView1.Columns[0].HeaderText = "First Name";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Cntrctr_LName"].DisplayIndex = 1;
                    dataGridView1.Columns[1].HeaderText = "Last Name";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Cntrctr_MaxFiles"].DisplayIndex = 2;
                    dataGridView1.Columns[2].HeaderText = "Max Files";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Orders_Count"].DisplayIndex = 3;
                    dataGridView1.Columns[3].HeaderText = "Current Count";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Cntrctr_ID"].DisplayIndex = 4;
                    dataGridView1.Columns[4].HeaderText = "ID";
                    dataGridView1.Columns[4].Visible = false;

                    DataGridViewButtonColumn buttonColumnDetails = new DataGridViewButtonColumn();
                    buttonColumnDetails.Name = "Details";
                    buttonColumnDetails.HeaderText = "Details";
                    buttonColumnDetails.Text = "Details";
                    buttonColumnDetails.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Insert(5, buttonColumnDetails);
                    dataGridView1.Columns["Details"].DisplayIndex = 5;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    DataGridViewButtonColumn buttonColumnSend = new DataGridViewButtonColumn();
                    buttonColumnSend.Name = "Queue";
                    buttonColumnSend.HeaderText = "Queue";
                    buttonColumnSend.Text = "Queue";
                    buttonColumnSend.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Insert(6, buttonColumnSend);
                    dataGridView1.Columns["Queue"].DisplayIndex = 6;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].Visible = false;

                    this.dataGridView1.Refresh();
                    Application.DoEvents();
                    this.Refresh();
                }
                else if (dTbl.Rows.Count == 0)
                {
                    MessageBox.Show("No results.");
                    this.SearchForContractors();
                    this.RowWarning();
                    int iJobCount = 0;
                    this.TotalJobs(ref iJobCount);
                    this.TotalCount(iJobCount);
                    this.txtboxSearch.Text = string.Empty;
                    this.txtboxSearch.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void TotalJobs(ref int iJobCount)
        {
            try
            {
                dtTotalJobs.Clear();

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT [OSR_Orders].[Orders_RefNum], [OSR_Contractor].[ActiveStatus_Code] FROM [OSR_Orders] " +
                    "FULL OUTER JOIN [OSR_Contractor] ON [OSR_Orders].[Cntrctr_ID] = " +
                "[OSR_Contractor].[Cntrctr_ID] WHERE [OrderStatus_Code] != 3 AND [OrderStatus_Code] != 4 AND [OSR_Contractor].[ActiveStatus_Code] != 0";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dtTotalJobs.Merge(dTbl);

                    iJobCount = dtTotalJobs.Rows.Count;
                }
                else if (dTbl.Rows.Count == 0)
                {
                    lblTotalCount.Text = "No images currently out for retouch.";
                    Application.DoEvents();
                    this.Refresh();
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void TotalCount(int iJobCount)
        {
            try
            {
                dtTotalCount.Clear();

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT [Jobs_Filename], [OSR_Jobs].[Orders_ProdNum] FROM [OSR_Jobs] FULL OUTER JOIN [OSR_Orders] ON " +
                "[OSR_Jobs].[Orders_ProdNum] = [OSR_Orders].[Orders_ProdNum] WHERE [OrderStatus_Code] != 3 AND [OrderStatus_Code] != 4";

                TM2.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dtTotalCount.Merge(dTbl);

                    int iCount = dtTotalCount.Rows.Count;

                    if (iCount == 1 && iJobCount == 1)
                    {
                        lblTotalCount.Text = iCount + " image in " + iJobCount + " order currently out for retouch.";
                    }

                    if (iCount >= 2 && iJobCount == 1)
                    {
                        lblTotalCount.Text = iCount + " images in " + iJobCount + " order currently out for retouch.";
                    }

                    if (iCount >= 2 && iJobCount >= 2)
                    {
                        lblTotalCount.Text = iCount + " images in " + iJobCount + " orders currently out for retouch.";
                    }
                }
                else if (dTbl.Rows.Count == 0)
                {
                    lblTotalCount.Text = "No images currently out for retouch.";
                    Application.DoEvents();
                    this.Refresh();
                    return;
                }
            }
            catch (Exception ex)
            {
                TM2.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void RowWarning()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[3].Value != DBNull.Value)
                {
                    if (Convert.ToInt32(row.Cells[3].Value) > Convert.ToInt32(row.Cells[2].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                }
        }

        private void Clear()
        {
            this.dataGridView1.Columns.Clear();
            dtTotalCount.Clear();
            dtTotalCount.Dispose();
            dtTotalJobs.Clear();
            dtTotalJobs.Dispose();
            dtSearch1.Clear();
            dtSearch1.Dispose();
            dtSearch2.Clear();
            dtSearch2.Dispose();
            dtSearch3.Clear();
            dtSearch3.Dispose();
            dtSearchFinal.Clear();
            dtSearchFinal.Dispose();
            dsContractorSearch.Clear();
            dsContractorSearch.Dispose();
            this.txtboxSearch.Enabled = true;
            this.btnSearch.Enabled = true;
            this.txtboxSearch.Text = string.Empty;
            this.txtboxSearch.Focus();
            Application.DoEvents();
            this.Refresh();
        }

        #endregion

    }
}
