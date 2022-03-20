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
using DGVPrinterHelper;

namespace VRMS___Management__12_01_21_
{
    public partial class ActivityTrails : Form
    {
        public ActivityTrails()
        {
            InitializeComponent();
        }

        //CONNECTION
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //FORM LOAD
        private void ActivityTrails_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY DATA
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT  fullname as `FULLNAME`, access as `TYPE OF ADMIN`, date as `DATE`, time as `TIME`, admin_id as `ACCOUNT ID`, activity as  `ACTIVITY` FROM audit_trails ORDER BY date DESC;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvAT.DataSource = ds.Tables[0];
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //SEARCH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OdbcConnection cons = new OdbcConnection("dsn=capstone");
            cons.Open();
            OdbcCommand commands = new OdbcCommand("SELECT fullname as `FULLNAME`, access as `TYPE OF USER`, date as `DATE`, time as `TIME`, activity as  `ACTIVITY` FROM audit_trails WHERE fullname LIKE '%" + txtSearch.Text + "%' OR access LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvAT.DataSource = dt;
            con.Close();


        }
    }
}
