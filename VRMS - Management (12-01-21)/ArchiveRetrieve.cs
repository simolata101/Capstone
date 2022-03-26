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
using System.IO;

namespace VRMS___Management__12_01_21_
{
    public partial class ArchiveRetrieve : Form
    {
        public ArchiveRetrieve()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");
        public void pics()
        {

            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand("select img from owner_pic where owner_id='" + txtScan.Text + "'", con);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["img"]);
                    pbOwner.Image = new Bitmap(ms);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

            pics();
            fetch();
        }
       string checkerValid;
        public void fetch()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT * FROM Archived WHERE Archived_Operator_Owner_ID ='" + txtScan.Text + "'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
               lblOID.Text = dt.Rows[0][4].ToString();
               lblClassification.Text = dt.Rows[0][2].ToString();
               lblSchoolID.Text = dt.Rows[0][1].ToString();
               lblFname.Text = dt.Rows[0][3].ToString();
               lblLname.Text = dt.Rows[0][6].ToString();
               lblMname.Text = dt.Rows[0][5].ToString();
               lblSuffix.Text = dt.Rows[0][7].ToString();
               checkerValid = dt.Rows[0][0].ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (checkerValid != null)
            {
                try
                {
                    con.Open();
                    OdbcCommand cmd = new OdbcCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO registered_owners(owner_id,school_id,type,fname,mname,lname,suf)VALUES(?,?,?,?,?,?,?)";
                    cmd.Parameters.Add("@owner_id", OdbcType.VarChar).Value = lblOID.Text;
                    cmd.Parameters.Add("@school_id", OdbcType.VarChar).Value = lblSchoolID.Text;
                    cmd.Parameters.Add("@type", OdbcType.VarChar).Value = lblClassification.Text;
                    cmd.Parameters.Add("@fname", OdbcType.VarChar).Value = lblFname.Text;
                    cmd.Parameters.Add("@mname", OdbcType.VarChar).Value = lblMname.Text;
                    cmd.Parameters.Add("@lname", OdbcType.VarChar).Value = lblLname.Text;
                    cmd.Parameters.Add("@suf", OdbcType.VarChar).Value = lblSuffix.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Welcome Back: " + lblLname.Text, "Data Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else {
                MessageBox.Show("Please Search Propritary First!!!","Please Insert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if (txtScan.Text != null)
            {
                DialogResult result = MessageBox.Show("Confirm to CLear?", "Notice!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Clearer();
                }
               
            }

            else {
                
            }
            
        }

        public void Clearer() {

            lblLname.Text = "";
            lblFname.Text = "";
            lblClassification.Text = "";
            lblMname.Text = "";
            lblOID.Text = "";
            lblSchoolID.Text = "";
            lblSuffix.Text = "";
            txtScan.Clear();
            checkerValid = "";
        }

        private void DataTable1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSuffix_Click(object sender, EventArgs e)
        {

        }

        private void lblMname_Click(object sender, EventArgs e)
        {

        }

        private void lblFname_Click(object sender, EventArgs e)
        {

        }

        private void lblSchoolID_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblOID_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblClassification_Click(object sender, EventArgs e)
        {

        }

        private void lblLname_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void pbOwner_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
