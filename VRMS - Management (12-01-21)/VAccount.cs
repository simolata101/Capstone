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

namespace VRMS___Management__12_01_21_
{
    public partial class VAccount : Form
    {
        public VAccount()
        {
            InitializeComponent();
        }
        
        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //FORM LOAD
        private void VAccount_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY ACCOUNTS
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT admin_id as `ID`, fullname as `NAME`, username as `USERNAME`, level as `LEVEL` FROM accounts where isApprove = 'YES';", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvVA.DataSource = ds.Tables[0];
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
            OdbcCommand commands = new OdbcCommand("SELECT admin_id, fullname, username, level FROM accounts WHERE admin_id LIKE '%" + txtSearch.Text + "%' OR fullname LIKE '%" + txtSearch.Text + "%' OR username LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvVA.DataSource = dt;
            con.Close();

            dgvVA.Columns[0].HeaderText = "ADMIN ID";
            dgvVA.Columns[1].HeaderText = "FULLNAME";
            dgvVA.Columns[3].HeaderText = "LEVEL";
        }


    }
}
