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
    public partial class HeadCount : Form
    {
        public int iHeadCount { get;set;}

        public HeadCount()
        {
            InitializeComponent();
        }

        private void HeadCount_Load(object sender, EventArgs e)
        {
            this.txtBoxCount.Focus();

            Application.DoEvents();

            this.Refresh();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (this.txtBoxCount.Text != null || this.txtBoxCount.Text != string.Empty)
            {
                iHeadCount = Convert.ToInt32(this.txtBoxCount.Text);
            }
            else if (this.txtBoxCount.Text == null || this.txtBoxCount.Text == string.Empty)
            {
                return;
            }

            this.Close();
        }
    }
}
