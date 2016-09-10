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
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Collections;
using System.Net;

namespace OSR
{
    class TaskMethods
    {
        string sOSRConnString = OSR.Properties.Settings.Default.OSRetouchConnectionString.ToString();
        string sCDSConnString = OSR.Properties.Settings.Default.CDSConnString.ToString();

        public void SQLNonQuery(string sConnString, string sCommText, ref bool bSuccess)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(sConnString);

                SqlCommand myCommand = myConn.CreateCommand();

                myCommand.CommandText = sCommText;

                myConn.Open();

                myCommand.ExecuteNonQuery();

                myCommand.Dispose();

                myConn.Close();
                myConn.Dispose();
            }
            catch (Exception ex)
            {
                bSuccess = false;
                this.SaveExceptionToDB(ex);
            }
        }

        public void SQLQuery(string sConnString, string sCommText, DataTable dTbl)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(sConnString);

                SqlCommand myCommand = myConn.CreateCommand();

                myCommand.CommandText = sCommText;

                myConn.Open();

                SqlDataReader myDataReader = myCommand.ExecuteReader();

                if (myDataReader.HasRows)
                {
                    dTbl.Clear();
                    dTbl.Load(myDataReader);
                }

                myDataReader.Close();
                myDataReader.Dispose();

                myCommand.Dispose();

                myConn.Close();
                myConn.Dispose();
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        }

        public void SQLQueryWithReturnValue(string sConnString, string sCommTextValue, DataTable dTbl, ref string sValueString, string sColumn)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(sConnString);

                SqlCommand myCommand = myConn.CreateCommand();

                myCommand.CommandText = sCommTextValue;

                myConn.Open();

                SqlDataReader myDataReader = myCommand.ExecuteReader();

                if (myDataReader.HasRows)
                {
                    dTbl.Clear();
                    dTbl.Load(myDataReader);

                    sValueString = string.Empty;
                    sValueString = Convert.ToString(dTbl.Rows[0][sColumn]).Trim();
                }

                myDataReader.Close();
                myDataReader.Dispose();

                myCommand.Dispose();

                myConn.Close();
                myConn.Dispose();
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        }

        public void CDSQuery(string sConnString, string sCommText, DataTable dTbl)
        {
            try
            {
                OleDbConnection CDSconn = new OleDbConnection(sConnString);

                OleDbCommand CDScommand = CDSconn.CreateCommand();

                CDScommand.CommandText = sCommText;

                CDSconn.Open();

                CDScommand.CommandTimeout = 0;

                OleDbDataReader CDSreader = CDScommand.ExecuteReader();

                if (CDSreader.HasRows)
                {
                    dTbl.Clear();
                    dTbl.Load(CDSreader);
                }

                CDScommand.Dispose();

                CDSreader.Close();
                CDSreader.Dispose();

                CDSconn.Close();
                CDSconn.Dispose();
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        }

        public void CDSNonQuery(string sConnString, string sCommText)
        {
            try
            {
                OleDbConnection CDSconn = new OleDbConnection(sConnString);

                OleDbCommand CDScommand = CDSconn.CreateCommand();

                CDScommand.CommandText = sCommText;

                CDSconn.Open();

                CDScommand.CommandTimeout = 0;

                OleDbDataReader CDSreader = CDScommand.ExecuteReader();

                CDScommand.Dispose();

                CDSreader.Close();
                CDSreader.Dispose();

                CDSconn.Close();
                CDSconn.Dispose();
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        }

        public void SaveExceptionToDB(Exception ex)
        {
            string sException = ex.ToString().Trim();
            sException = sException.Replace(@"'", "");
            bool bSuccess = true;

            string sCommText = "INSERT INTO [OSR_Errors] VALUES ('" + sException + "', '" + DateTime.Now.ToString().Trim() + "', '0')";

            this.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);
        }

        public void EmailVariables(ref string sEmailServer, ref string sEmailMyBccAdd, ref string sEmailMyErrorSendAdd, ref string sSendtoAdd2, ref string sNewCntrctrSendToAdd)
        {
            try
            {
                string sCommText = "SELECT [Variables_Variable] FROM [OSR_Variables] WHERE [Variables_VariableName] = 'APS_Email_Server'"; // Email server name.
                DataTable dTbl = new DataTable();

                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    sEmailServer = Convert.ToString(dTbl.Rows[0]["Variables_Variable"]).Trim();
                }

                dTbl.Clear();

                sCommText = "SELECT [Variables_Variable] FROM [OSR_Variables] WHERE [Variables_VariableName] = 'APS_Email_My_BCC'"; // My internal APS email.

                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    sEmailMyBccAdd = Convert.ToString(dTbl.Rows[0]["Variables_Variable"]).Trim();
                }

                dTbl.Clear();

                sCommText = "SELECT [Variables_Variable] FROM [OSR_Variables] WHERE [Variables_VariableName] = 'APS_Email_Error_Sendto'"; // My gmail email.

                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    sEmailMyErrorSendAdd = Convert.ToString(dTbl.Rows[0]["Variables_Variable"]).Trim();
                }

                dTbl.Clear();

                sCommText = "SELECT [Variables_Variable] FROM [OSR_Variables] WHERE [Variables_VariableName] = 'VPN_CC_Email_Adds'"; // List of in lab email addys and my gmail for notification emails.

                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    sSendtoAdd2 = Convert.ToString(dTbl.Rows[0]["Variables_Variable"]).Trim();
                }

                dTbl.Clear();

                sCommText = "SELECT [Variables_Variable] FROM [OSR_Variables] WHERE [Variables_VariableName] = 'OSR_NewCntrctrSetup_SendToAdd'"; // List of in lab email addys and my gmail for notification emails.

                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    sNewCntrctrSendToAdd = Convert.ToString(dTbl.Rows[0]["Variables_Variable"]).Trim();
                }

                dTbl.Clear();
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        }

        public void CheckForExceptions(ref string sMySubject, ref string sMyBody) // Check for logged errors in database and notify if new errors are found.
        {
            try
            {
                string sExceptionString = string.Empty;
                DateTime datetimeException = DateTime.Now;
                string sDateTimeException = string.Empty;

                DataTable dTbl = new DataTable();
                string sCommText = "SELECT * FROM [Errors] WHERE [Errors_Email_Sent] = '0' OR [Errors_Email_Sent] IS NULL";
                this.SQLQuery(sOSRConnString, sCommText, dTbl);

                if (dTbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dTbl.Rows)
                    {
                        sExceptionString = Convert.ToString(dr["Errors_String"]).Trim();
                        datetimeException = Convert.ToDateTime(dr["Errors_DateTime"]);
                        sDateTimeException = Convert.ToString(dr["Errors_DateTime"]);

                        sMySubject = string.Format("OSR Error Reporting");
                        sMyBody = string.Format("An exception was recorded in the Errors database at " + datetimeException + ":" + Environment.NewLine + Environment.NewLine + sExceptionString);                      

                        sCommText = "UPDATE [OSR_Errors] SET [Errors_Email_Sent] = '1' WHERE [Errors_DateTime] = '" + datetimeException + "'";
                        bool bSuccess = true;
                        this.SQLNonQuery(sOSRConnString, sCommText, ref bSuccess);
                    }
                }
            }
            catch (Exception ex)
            {
                this.SaveExceptionToDB(ex);
            }
        } 
    }
}

