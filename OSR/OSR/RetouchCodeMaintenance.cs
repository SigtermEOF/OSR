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
 *  <class name'Retouch Code Maintenance'>
 *  <description>
 *  (O)ff (S)ite (R)etouching form for maintaining retouch codes.
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
    public partial class RetouchCodeMaintenance : Form
    {

        public string sCode;

        public RetouchCodeMaintenance()
        {
            InitializeComponent();            
        }

        private void RetouchCodeMaintenance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oSRDataSet.OSR_RetouchType' table. You can move, or remove it, as needed.
            this.oSR_RetouchTypeTableAdapter.Fill(this.oSRDataSet.OSR_RetouchType);
            // TODO: This line of code loads data into the 'oSRDataSet.OSR_RetouchCodes' table. You can move, or remove it, as needed.
            this.oSR_RetouchCodesTableAdapter.Fill(this.oSRDataSet.OSR_RetouchCodes);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.sCode = Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[0].Value);

            this.Close();
        }
    }
}
