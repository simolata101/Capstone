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
    public partial class VUpdate : Form
    {
        public VUpdate()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");
        private void txtVID_TextChanged(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT SELECT qrtext, type, plate_num, owner_id  FROM registered_vehicles WHERE qrtext='" + txtVID.Text + "'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);

                OdbcCommand cmd2 = new OdbcCommand("SELECT owner_id,school_id,type,fname,mname,lname,suf FROM registered_owners WHERE owner_id='" + lblOID.Text + "'", con);
                OdbcDataAdapter adptr2 = new OdbcDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adptr2.Fill(dt2);

                txtVID.Text = dt.Rows[0][1].ToString();
                lblOID.Text = dt.Rows[0][4].ToString();
                //txtSchoolID.Text = dt.Rows[0][1].Todt.Rows[0][1].ToString();String();
                //cmbOtype.Text = dt.Rows[0][2].ToString();

                txtplate.Text = dt.Rows[0][3].ToString();
                txtType.Text = dt.Rows[0][2].ToString();




                nameVal.Text = dt2.Rows[0][4].ToString();
                //txtMname.Text = dt.Rows[0][4].ToString();
                label2.Text = dt2.Rows[0][5].ToString();
                //txtSuf.Text = dt.Rows[0][6].ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            SOwner call = new SOwner();
            Dashboard calll = new Dashboard();
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE registered_vehicles SET plate_num=? WHERE qrtext = '" + txtVID.Text + "';";
                cmd.Parameters.Add("@plate_num", OdbcType.VarChar).Value = txtplate.Text;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Proprietary successfully update.");
                }
                con.Close();
                this.Close();
                //call.ShowDialog();
                call.Close();
                calll.Show();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VUpdate_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
