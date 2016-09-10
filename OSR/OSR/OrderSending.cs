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
using System.Threading;

namespace OSR
{
    public partial class OrderSending : Form
    {
        // Public variables.

        TaskMethods TM = null;
        string sOSRConnString = OSR.Properties.Settings.Default.OSRetouchConnectionString.ToString();
        string sCDSConnString = OSR.Properties.Settings.Default.CDSConnString.ToString();
        string sID = string.Empty;
        string sLookup = string.Empty;
        DataTable dTblFinalResults = new DataTable();
        DataTable dTblItems = new DataTable();
        bool bReturned = false;
        int iConRetLevel = -1;
        int iMaxRetLvl = -1;
        HeadCount HC = null;

        public OrderSending(string sIncomingID)
        {
            InitializeComponent();

            sID = sIncomingID;

            TM = new TaskMethods();
        }

        private void OrderSending_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oSRDataSet.OSR_RetouchType' table. You can move, or remove it, as needed.
            this.oSR_RetouchTypeTableAdapter.Fill(this.oSRDataSet.OSR_RetouchType);
            this.txtboxRefNum.Focus();
            this.PullNotes();
        }

        #region Form events.

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sLookup = this.txtboxRefNum.Text.Trim();

            this.btnSearch.Enabled = false;
            this.txtboxRefNum.Enabled = false;
            Application.DoEvents();
            this.Refresh();

            this.DoWork();

            //backgroundWorker1.RunWorkerAsync();

            Application.DoEvents();
            this.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                this.DoWork();
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                if (e.ColumnIndex == 5)
                {
                    try
                    {
                        DataTable dTbl = new DataTable();
                        string sCommText = "SELECT * FROM [OSR_Orders] WHERE [Orders_ProdNum] = '" + this.txtboxRefNum.Text + "'";

                        TM.SQLQuery(sOSRConnString, sCommText, dTbl);

                        // If a record is returned then the job has previously had a contractor assigned to it.
                        if (dTbl.Rows.Count >= 1)
                        {
                            MessageBox.Show("ERROR: A contractor has already been assigned to this job.");
                            this.Close();
                            //this.InsertImageDataIntoJobsTable();
                        }
                        else if (dTbl.Rows.Count == 0)
                        {
                            this.InsertOrderIntoOrdersTable();
                            this.InsertImageDataIntoJobsTable();
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        TM.SaveExceptionToDB(ex);
                        MessageBox.Show(ex.Message);
                        Trace.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void OrderSending_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.PullNotes();
        }


        #endregion

        private void DoWork()
        {
            // If searching for a reference number for the first time since form was opened then run query and generate button column.
            if (this.dataGridView1.ColumnCount <= 2)
            {
                int itemspackagetagindex = 0;
                string paramval = "";
                DataTable dTblLabels = new DataTable();
                string sVal1 = string.Empty;
                string sVal2 = string.Empty;

                this.CheckCDSForOrderExistence(ref itemspackagetagindex, ref paramval);
                this.ScanForTriggerPoints();
                this.GetALaCarteRetCodesFromLabelsTable(ref dTblLabels);
                this.GetPreConfigsWithRetCodesFromLabelsTable(ref itemspackagetagindex, ref paramval, ref dTblLabels);
                this.CheckOrderForGatheredRetCodes(ref dTblLabels, ref sVal1, ref sVal2);
                if (bReturned != true)
                {
                    this.LoadDGVWithData();
                    // If the job currently has a contractor assigned and the user does not wish to reassign it to another contractor
                    // I set a bool to prevent the generation of columns and clears the form.
                    if (bReturned == false)
                    {
                        this.CreateButtonColumn();
                        this.ImageCount();
                    }
                    else
                    {
                        this.Clear();
                        this.PullNotes();
                    }
                }
            }
            // If searching for an additonal reference number since the form opened then clear the columns (to prevent duplicate
            // buttons from generating), run the query and create the button column.
            else if (this.dataGridView1.ColumnCount == 3)
            {
                int itemspackagetagindex = 0;
                string paramval = "";
                DataTable dTblLabels = new DataTable();
                string sVal1 = string.Empty;
                string sVal2 = string.Empty;

                this.dataGridView1.Columns.Clear();
                this.CheckCDSForOrderExistence(ref itemspackagetagindex, ref paramval);
                this.ScanForTriggerPoints();
                this.GetALaCarteRetCodesFromLabelsTable(ref dTblLabels);
                this.GetPreConfigsWithRetCodesFromLabelsTable(ref itemspackagetagindex, ref paramval, ref dTblLabels);
                this.CheckOrderForGatheredRetCodes(ref dTblLabels, ref sVal1, ref sVal2);
                if (bReturned != true)
                {
                    this.LoadDGVWithData();
                    this.CreateButtonColumn();
                }
            }
        }

        #region Main data gathering queries. 

        private void CheckCDSForOrderExistence(ref int itemspackagetagindex, ref string paramval)
        {
            try
            {
                DataTable dTbl = new DataTable();
                string sCommText = "SELECT ITEMS.PACKAGETAG,items.customer,items.order,items.lookupnum,items.imgloc" +
                    " FROM ITEMS WHERE lookupnum = '" + sLookup + "'";

                TM.CDSQuery(sCDSConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dTblItems.Merge(dTbl);

                    itemspackagetagindex = dTblItems.Columns.IndexOf("Packagetag");

                    paramval = Convert.ToString(dTblItems.Rows[0][itemspackagetagindex]);
                }
                else if (dTbl.Rows.Count == 0)
                {
                    MessageBox.Show("Order is not ready for queueing.");
                    this.Clear();

                    bReturned = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void ScanForTriggerPoints()
        {
            try
            {
                DataTable dTbl = new DataTable();
                string sCommText = "SELECT * FROM stamps WHERE (lookupnum = '" + sLookup + "') AND (action = 'ORD BUILT' OR action = 'BuiltThumb')";

                TM.CDSQuery(sCDSConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    // Proceed.
                }
                else if (dTbl.Rows.Count == 0)
                {
                    MessageBox.Show("Order is not ready for processing." + Environment.NewLine +
                        "[Triggers ORD BUILT or BuiltThumb missing in the Stamps table.]");
                    this.Clear();

                    bReturned = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void GetALaCarteRetCodesFromLabelsTable(ref DataTable dTblLabels)
        {
            try
            {
                DataTable dTbl = new DataTable();
                string sCommText = "SELECT * FROM LABELS WHERE (LABELS.PACKAGETAG = '        ') AND (LABELS.KEY_LABEL = 'RETOUCH')";

                TM.CDSQuery(sCDSConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dTblLabels.Merge(dTbl);
                }
                else if (dTbl.Rows.Count == 0)
                {
                    // This should never happen.
                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void GetPreConfigsWithRetCodesFromLabelsTable(ref int itemspackagetagindex, ref string paramval, ref DataTable dTblLabels)
        {
            try
            {
                if (dTblItems.Rows[0][itemspackagetagindex] != DBNull.Value && Convert.ToString(dTblItems.Rows[0][itemspackagetagindex]) != String.Empty)
                {
                    DataTable dTbl = new DataTable();
                    string sCommText = "SELECT * FROM LABELS WHERE (LABELS.PACKAGETAG = '" + paramval + "') AND (LABELS.KEY_LABEL = 'RETOUCH')";

                    TM.CDSQuery(sCDSConnString, sCommText, dTbl);

                    if (dTbl.Rows.Count > 0)
                    {
                        dTblLabels.Merge(dTbl);
                    }
                    else if (dTbl.Rows.Count == 0)
                    {
                        //*****************************************************NOT SURE IF NEEDED**********************************************

                        bReturned = true;
                        return;

                        //*********************************************************************************************************************
                    }
                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void CheckOrderForGatheredRetCodes(ref DataTable dTblLabels, ref string sVal1, ref string sVal2)
        {
            try
            {
                bool firstloop1 = true;
                bool firstloop2 = true;        

                foreach (DataRow dr in dTblLabels.Rows)
                {

                    if (Convert.ToString(dr["Packagecod"]) == "   ")
                    {
                        if (firstloop1 == true)
                        {
                            //sVal1 += " (Code = '" + Convert.ToString(dr["Code"]) + "'";
                            sVal1 += " (Code = 'PP8' OR Code = '" + Convert.ToString(dr["Code"]) + "'";
                            firstloop1 = false;
                        }
                        else
                        {
                            sVal1 += " OR Code = '" + Convert.ToString(dr["Code"]) + "'";
                        }
                    }
                    if (Convert.ToString(dr["Packagecod"]) != "   ")
                    {
                        if (firstloop2 == true)
                        {
                            sVal2 += " OR (Code = '" + Convert.ToString(dr["Packagecod"]) + "'";
                            firstloop2 = false;
                        }
                        else
                        {
                            sVal2 += " OR Code = '" + Convert.ToString(dr["Packagecod"]) + "'";
                        }
                    }
                }

                if (sVal1 != string.Empty)
                {
                    sVal1 += ")";
                }

                if (sVal2 != string.Empty)
                {
                    sVal2 += " AND Package = .T.))";

                    sVal1 = "(" + sVal1;
                }

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT codes.code,space(60) as descript,codes.sequence,codes.quantity,frames.image_id FROM codes," +
                " frames WHERE (codes.Lookupnum = '" + sLookup + "')" +
                 " AND (frames.Lookupnum = '" + sLookup + "') AND (codes.sequence = frames.sequence) AND " + sVal1.Trim() + sVal2.Trim();

                TM.CDSQuery(sCDSConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    dTblFinalResults.Merge(dTbl);

                    int iRowCount = dTblFinalResults.Rows.Count;
                    DataTable dTblCollectedRetCodes = new DataTable();

                    foreach(DataRow dRow in dTblFinalResults.Rows)
                    {
                        //Note: Why am I using an array below?*****

                        string sRetLvlDescript = string.Empty;
                        string sCode = "code = '" + Convert.ToString(dRow["Code"]).Trim() + "'";                        
                        DataRow[] dRowArray = dTblLabels.Select(sCode);

                        if (dRowArray.Length != 0)
                        {
                            string sProductCode = Convert.ToString(dRow["Code"]).Trim();
                            sCode = "packagecod = '" + Convert.ToString(dRow["Code"]).Trim() + "'";
                            dRowArray = dTblLabels.Select(sCode);

                            string sDescript = Convert.ToString(dRow["descript"]).Trim();

                            if (sDescript != string.Empty)
                            {
                                dRow["descript"] = dRowArray[0]["descript"].ToString().Trim();
                                sRetLvlDescript = Convert.ToString(dTblFinalResults.Rows[0]["descript"]).Trim();
                            }
                            else if (sDescript == string.Empty)
                            {
                                DataTable dTbl02 = new DataTable();
                                sCommText = "SELECT * FROM Labels WHERE Code = '" + sProductCode + "'";

                                TM.CDSQuery(sCDSConnString, sCommText, dTbl02);

                                if (dTbl02.Rows.Count > 0)
                                {
                                    dRow["descript"] = Convert.ToString(dTbl02.Rows[0]["Descript"]).Trim();
                                    sRetLvlDescript = Convert.ToString(dTbl02.Rows[0]["Descript"]).Trim();
                                }
                                else if (dTbl02.Rows.Count == 0)
                                {

                                }
                            }

                            this.GetRetLevel(sRetLvlDescript, ref dTblCollectedRetCodes);

                            if (dTblCollectedRetCodes.Rows.Count > 0)
                            {
                                iMaxRetLvl = (Int32)dTblCollectedRetCodes.Compute("MAX([ID])", "");
                            }
                            else if (dTblCollectedRetCodes.Rows.Count == 0)
                            {
                                // Add a more descriptive error msg and log to db.
                                MessageBox.Show("An error has occurred.");
                                return;
                            }

                            if (iConRetLevel < iMaxRetLvl)
                            {
                                MessageBox.Show("Contractor does not meet retouching requirements for this job.");

                                return;
                            }
                        }
                        else if (dRowArray.Length == 0)
                        {

                        }
                    }
                }
                else if (dTbl.Rows.Count == 0)
                {
                    MessageBox.Show("Order is not ready for queueing.");

                    this.Clear();

                    bReturned = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Misc methods. 

        private void LoadDGVWithData()
        {
            try
            {
                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = dTblFinalResults;

                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["code"].DisplayIndex = 0;
                dataGridView1.Columns[0].HeaderText = "Code";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["descript"].DisplayIndex = 1;
                dataGridView1.Columns[1].HeaderText = "Retouch Type";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["sequence"].DisplayIndex = 2;
                dataGridView1.Columns[2].HeaderText = "Sequence";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["quantity"].DisplayIndex = 3;
                dataGridView1.Columns[3].HeaderText = "Quantity";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["image_id"].DisplayIndex = 4;
                dataGridView1.Columns[4].HeaderText = "Filename";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void PullNotes()
        {
            try
            {
                DataTable dTbl = new DataTable();
                string sCommText = "SELECT [Cntrctr_Notes], [RetouchType_Code] FROM [OSR_Contractor] WHERE [Cntrctr_ID] = '" + sID + "'";

                TM.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    this.rtxtNotes.Text = Convert.ToString(dTbl.Rows[0]["Cntrctr_Notes"]).Trim();
                    this.cboxType.SelectedIndex = Convert.ToInt32(dTbl.Rows[0]["RetouchType_Code"]);
                    iConRetLevel = Convert.ToInt32(dTbl.Rows[0]["RetouchType_Code"]);
                }
                else if (dTbl.Rows.Count == 0)
                {

                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void GetRetLevel(string sRetLvlDecript, ref DataTable dTblCollectedRetCodes)
        {
            try
            {
                DataColumn dCol01;
                DataRow dRow01;
                DataColumn dCol02;

                bool bCreated = false;

                if (bCreated == false)
                {
                    dTblCollectedRetCodes.Columns.Clear();
                    bCreated = true;

                    dCol01 = new DataColumn();
                    dCol01.DataType = System.Type.GetType("System.String");
                    dCol01.ColumnName = "Descript";
                    dTblCollectedRetCodes.Columns.Add(dCol01);

                    dCol02 = new DataColumn();
                    dCol02.DataType = System.Type.GetType("System.Int32");
                    dCol02.ColumnName = "ID";
                    dTblCollectedRetCodes.Columns.Add("ID", typeof(Int32));
                }
                else if (bCreated != false)
                {

                }

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT * FROM [OSR_RetouchCodes] WHERE [RetouchCodes_Description] = " + "'" + sRetLvlDecript + "'";
                
                TM.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    foreach (DataRow dRow02 in dTbl.Rows)
                    {
                        dRow01 = dTblCollectedRetCodes.NewRow();
                        dRow01["Descript"] = Convert.ToString(dTbl.Rows[0]["RetouchCodes_Description"]).Trim();
                        dRow01["ID"] = Convert.ToInt32(dTbl.Rows[0]["RetouchType_Code"]);
                        dTblCollectedRetCodes.Rows.Add(dRow01);
                    }
                }
                else if (dTbl.Rows.Count == 0)
                {
                    MessageBox.Show("An error has occurred gathering contractors retouch ability level.");
                    return;
                }

            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void ImageCount()
        {
            try
            {
                string sTotalCount = dTblFinalResults.Rows.Count.ToString().Trim();

                this.lblCount.Text = "This order contains " + sTotalCount + " images flagged for retouch.";

                Application.DoEvents();
                this.Refresh();
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void InsertImageDataIntoJobsTable()
        {
            try
            {
                int iRowCount = dTblFinalResults.Rows.Count;

                bool bSuccess = true;

                foreach (DataRow dRow in dTblFinalResults.Rows)
                {
                    string sFrameNum = Convert.ToString(dRow["sequence"]).Trim();
                    string sFileName = Convert.ToString(dRow["image_id"]).Trim();
                    string sRetDescript = Convert.ToString(dRow["descript"]).Trim();
                    int iHeadCount = 0;

                    if (sRetDescript == "16x20 Painter Portrait without Frame")
                    {
                        DialogResult dResultMoreThan2 = MessageBox.Show("Is the head count greater than 2?", "Head count:", MessageBoxButtons.YesNo);

                        if (dResultMoreThan2 == DialogResult.Yes)
                        {
                            string sRetDescriptAdd = sRetDescript + " Add";

                            this.Enabled = false;
                            HC = new HeadCount();
                            HC.ShowDialog();
                            iHeadCount = HC.iHeadCount;
                            this.Enabled = true;

                            string sCommText = "INSERT INTO [OSR_Jobs] ([Jobs_Frame], [Jobs_Descript], [Jobs_Filename], [Orders_ProdNum], [Jobs_HeadCount]) VALUES" +
                            " ('" + sFrameNum + "','" + sRetDescriptAdd + "','" + sFileName + "','" + sLookup + "', '" + iHeadCount + "')";

                            TM.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);

                            sCommText = "INSERT INTO [OSR_Jobs] ([Jobs_Frame], [Jobs_Descript], [Jobs_Filename], [Orders_ProdNum]) VALUES" +
                            " ('" + sFrameNum + "','" + sRetDescript + "','" + sFileName + "','" + sLookup + "')";

                            TM.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);
                        }
                        else if (dResultMoreThan2 == DialogResult.No)
                        {
                            string sCommText = "INSERT INTO [OSR_Jobs] ([Jobs_Frame], [Jobs_Descript], [Jobs_Filename], [Orders_ProdNum]) VALUES" +
                            " ('" + sFrameNum + "','" + sRetDescript + "','" + sFileName + "','" + sLookup + "')";

                            TM.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);
                        }
                    }
                    else if (sRetDescript != "16x20 Painter Portrait without Frame")
                    {
                        string sCommText = "INSERT INTO [OSR_Jobs] ([Jobs_Frame], [Jobs_Descript], [Jobs_Filename], [Orders_ProdNum]) VALUES" +
                        " ('" + sFrameNum + "','" + sRetDescript + "','" + sFileName + "','" + sLookup + "')";

                        TM.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);
                    }
                }
                
                if (bSuccess == true)
                {
                    
                }
                else if (bSuccess != true)
                {

                }
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }
        }

        private void InsertOrderIntoOrdersTable()
        {
            try
            {
                string sAccNum = Convert.ToString(dTblItems.Rows[0]["customer"]).Trim();
                string sRefNum = Convert.ToString(dTblItems.Rows[0]["order"]).Trim();
                string sProdNum = Convert.ToString(dTblItems.Rows[0]["lookupnum"]).Trim();
                string sFileLoc = Convert.ToString(dTblItems.Rows[0]["imgloc"]).Trim();
                string sCount = dTblFinalResults.Rows.Count.ToString().Trim();
                string sQueueDate = DateTime.Now.ToString().Trim();

                string sCommText = "INSERT INTO [OSR_Orders] (Orders_AccNum,Orders_RefNum,Orders_ProdNum,Orders_FileLoc,Orders_Count,Orders_QueueDate,Cntrctr_ID,OrderStatus_Code)" +
                    " VALUES ('" + sAccNum + "','" + sRefNum + "','" + sProdNum + "','" + sFileLoc + "','" + sCount + "','" + sQueueDate + "','" + sID + "','1')";
                bool bSuccess = true;

                TM.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);

                if (bSuccess == true)
                {
                    MessageBox.Show("Contractor assigned to job successfully.");
                }
                else if (bSuccess != true)
                {
                    MessageBox.Show("An error has occurred assigning the contractor to this order.");
                }                
            }
            catch (Exception ex)
            {
                TM.SaveExceptionToDB(ex);
                MessageBox.Show(ex.Message);
                Trace.WriteLine(ex.Message);
            }            
        }

        private void CreateButtonColumn()
        {
            if (bReturned == false)
            {
                DataGridViewButtonColumn buttonColumnDetails = new DataGridViewButtonColumn();
                buttonColumnDetails.Name = "Send Job";
                buttonColumnDetails.HeaderText = "Send Job";
                buttonColumnDetails.Text = "Send Job";
                buttonColumnDetails.UseColumnTextForButtonValue = true;
                dataGridView1.AutoSize = false;
                buttonColumnDetails.Width = 100;
                dataGridView1.Columns.Insert(5, buttonColumnDetails);
                dataGridView1.Columns["Send Job"].DisplayIndex = 5;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                return;
            }
        }

        private void Clear()
        {
            this.txtboxRefNum.Text = string.Empty;
            this.dataGridView1.DataSource = null;
            dTblFinalResults.Clear();
            dTblFinalResults.Dispose();
            bReturned = false;
            dTblItems.Clear();
            dTblItems.Dispose();          
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Refresh();
            this.txtboxRefNum.Focus();
            this.lblCount.Text = "";
            iConRetLevel = -1;
            iMaxRetLvl = -1;
            sLookup = string.Empty;
            this.btnSearch.Enabled = true;
            this.txtboxRefNum.Enabled = true;
            Application.DoEvents();
            this.Refresh();
        }

        #endregion
    }
}
