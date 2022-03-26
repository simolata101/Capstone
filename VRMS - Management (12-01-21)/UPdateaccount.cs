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
    public partial class UPdateaccount : Form
    {
        public UPdateaccount()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        private void UPdateaccount_Load(object sender, EventArgs e)
        {
            VAccount Vacc = new VAccount();
            Vacc.OWID = lblPID.Text;
            displays();
            Vacc.display();
            btnRepass.SendToBack();
            lblchecs.Text = passhold;
        }
        public String passhold;
        public void displays()
        {
            try
            {
                
                OdbcCommand cmd = new OdbcCommand("SELECT fullname , username , password  FROM accounts where admin_id = '" + lblPID.Text + "';", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable ds = new DataTable();
                adptr.Fill(ds);
                txtLN.Text = ds.Rows[0][0].ToString();
                txtUname.Text = ds.Rows[0][1].ToString();
                passhold = ds.Rows[0][2].ToString();
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (txtLN.Text != "" || txtUname.Text != "")
            {
                checker();
                VAccount Vacc = new VAccount();
                Vacc.display();
            }


            else {
                MessageBox.Show("Please Fill all the Blanks!");
            }
        }

        void checker()
        {
            if (txtsubpass.Text == "")
            {
                MessageBox.Show("Please enter you Password before changing");
            }
            else {

                if (txtsubpass.Text == passhold)
                {
                    try
                    {
                        con.Open();
                        OdbcCommand cmd5 = new OdbcCommand();
                        cmd5 = con.CreateCommand();
                        cmd5.CommandText = "UPDATE accounts SET username = ? , password = ? , fullname = ? where admin_id = '" + lblPID.Text + "' ;";
                        cmd5.Parameters.Add("@username", OdbcType.VarChar).Value = txtUname.Text;
                        cmd5.Parameters.Add("@password", OdbcType.VarChar).Value = passhold;
                        cmd5.Parameters.Add("@fullname", OdbcType.VarChar).Value = txtLN.Text;
                        cmd5.ExecuteNonQuery();
                        con.Close();
                        this.Close();
                      
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }

                }

                else {
                    MessageBox.Show("Incorrect Password!!!");
                }

                
            }
           
        }

        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpass.Checked == true)
            {
                txtrePass.Enabled = true;
                txtPass.Enabled = true;
                btnRepass.BringToFront();
                txtsubpass.Enabled = false;
            }

            else {
                txtrePass.Enabled = false;
                txtPass.Enabled = false;
                txtsubpass.Enabled = true;
                
                btnRepass.SendToBack();
            }
        }

        void passchanger() {

            if (txtrePass.Text == "" || txtPass.Text == "")
            {
                btnRepass.Enabled = false;

            }

           else if (txtrePass.Text == "" && txtPass.Text == "")
            {
                btnRepass.Enabled = false;
            }

            else {

                btnRepass.Enabled = true;
            }
        
        }

        private void txtsubpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtrePass_TextChanged(object sender, EventArgs e)
        {
            passchanger();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            passchanger();
        }

        private void btnRepass_Click(object sender, EventArgs e)
        {
            if (passhold != txtrePass.Text)
            {
                MessageBox.Show("Incorrect Re-Password");
            }
            else {
                try
                {
                    con.Open();
                    OdbcCommand cmd5 = new OdbcCommand();
                    cmd5 = con.CreateCommand();
                    cmd5.CommandText = "UPDATE accounts SET username = ? , password = ? , fullname = ? where admin_id = '" + lblPID.Text + "' ;";
                    cmd5.Parameters.Add("@username", OdbcType.VarChar).Value = txtUname.Text;
                    cmd5.Parameters.Add("@password", OdbcType.VarChar).Value = txtPass.Text;
                    cmd5.Parameters.Add("@fullname", OdbcType.VarChar).Value = txtLN.Text;
                    cmd5.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                    VAccount Vacc = new VAccount();
                    Vacc.display();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }

    }
}
