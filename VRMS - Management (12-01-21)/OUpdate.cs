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
    public partial class OUpdate : Form
    {
        public OUpdate()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");
        private void OUpdate_Load(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Arrow;
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT owner_id,school_id,type,fname,mname,lname,suf FROM registered_owners WHERE owner_id='" +lblPID.Text + "'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lblPID.Text = dt.Rows[0][0].ToString();
                txtSchoolID.Text = dt.Rows[0][1].ToString();
                cmbOtype.Text = dt.Rows[0][2].ToString();
                txtFname.Text = dt.Rows[0][3].ToString();
                txtMname.Text = dt.Rows[0][4].ToString();
                txtLname.Text = dt.Rows[0][5].ToString();
                txtSuf.Text = dt.Rows[0][6].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT owner_id,school_id,type,fname,mname,lname,suf FROM registered_owners WHERE owner_id='" + lblPID.Text + "'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lblPID.Text = dt.Rows[0][0].ToString();
                txtSchoolID.Text = dt.Rows[0][1].ToString();
                cmbOtype.Text = dt.Rows[0][2].ToString();
                txtFname.Text = dt.Rows[0][3].ToString();
                txtMname.Text = dt.Rows[0][4].ToString();
                txtLname.Text = dt.Rows[0][5].ToString();
                txtSuf.Text = dt.Rows[0][6].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            ORegistration call = new ORegistration();
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE registered_owners SET school_id=?,type=?,fname=?,mname=?,lname=?,suf=? WHERE owner_id = '"+lblPID.Text+"';";
                cmd.Parameters.Add("@school_id", OdbcType.VarChar).Value = txtSchoolID.Text;
                cmd.Parameters.Add("@type", OdbcType.VarChar).Value = cmbOtype.Text;
                cmd.Parameters.Add("@fname", OdbcType.VarChar).Value = txtFname.Text;
                cmd.Parameters.Add("@mname", OdbcType.VarChar).Value = txtMname.Text;
                cmd.Parameters.Add("@lname", OdbcType.VarChar).Value = txtLname.Text;
                cmd.Parameters.Add("@suf", OdbcType.VarChar).Value = txtSuf.Text;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Proprietary successfully update.");
                }
                con.Close();
                this.Close();
                call.display();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

    }
}
