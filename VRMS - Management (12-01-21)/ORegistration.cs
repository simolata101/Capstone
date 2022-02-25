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
    public partial class ORegistration : Form
    {
        public ORegistration()
        {
            InitializeComponent();
        }

        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //FORM LOAD
        private void ORegistration_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY REGISTERED OWNERS DATA
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT owner_id as 'OWNER ID', school_id as 'SCHOOL ID', fullname as 'FULLNAME', type as 'OWNER TYPE', birthdate as 'BIRTHDATE', contact as 'CONTACT', address as 'ADDRESS', email as 'EMAIL' FROM registered_owners;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvRegOwn.DataSource = ds.Tables[0];
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
            OdbcCommand commands = new OdbcCommand("SELECT owner_id, school_id, fullname, type, birthdate, contact, address, email FROM registered_owners WHERE owner_id LIKE '%" + txtSearch.Text + "%' OR school_id LIKE '%" + txtSearch.Text + "%' OR fullname LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvRegOwn.DataSource = dt;
            con.Close();

            dgvRegOwn.Columns[0].HeaderText = "OWNER ID";
            dgvRegOwn.Columns[1].HeaderText = "SCHOOL ID";
            dgvRegOwn.Columns[3].HeaderText = "OWNER TYPE";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOwner ao = new AddOwner();
            ao.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IDPrint ip = new IDPrint();
            ip.ShowDialog();
        }
    }
}
