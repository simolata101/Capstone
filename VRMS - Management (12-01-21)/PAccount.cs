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
    public partial class PAccount : Form
    {
        public PAccount()
        {
            InitializeComponent();
        }

        OdbcConnection con = new OdbcConnection("dsn=capstone");
        private void dgvPA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String OWID;
                OWID = dgvPA.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                lblShowID.Text = OWID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PAccount_Load(object sender, EventArgs e)
        {
            display();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
           try
            {          
            OdbcCommand cmd1 = new OdbcCommand("SELECT * FROM accounts_archive WHERE admin_id = '" + lblShowID.Text + "'", con);
            OdbcDataAdapter adptr1 = new OdbcDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adptr1.Fill(dt1);
            con.Close();

               con.Open();
            OdbcCommand cmd3 = new OdbcCommand();
            cmd3 = con.CreateCommand();

            cmd3.CommandText = "INSERT INTO accounts(admin_id,fullname,address,username,password,level,status,isApprove,Checker_FP)VALUES(?,?,?,?,?,?,?,?,?)";
            cmd3.Parameters.Add("@admin_id", OdbcType.VarChar).Value = dt1.Rows[0][6].ToString(); ;
            cmd3.Parameters.Add("@fullname", OdbcType.VarChar).Value = dt1.Rows[0][1].ToString();
            cmd3.Parameters.Add("@address", OdbcType.VarChar).Value = dt1.Rows[0][2].ToString();
            cmd3.Parameters.Add("@username", OdbcType.VarChar).Value = dt1.Rows[0][3].ToString();
            cmd3.Parameters.Add("@password", OdbcType.VarChar).Value = dt1.Rows[0][4].ToString();
            cmd3.Parameters.Add("@level", OdbcType.VarChar).Value = dt1.Rows[0][5].ToString();
            cmd3.Parameters.Add("@status", OdbcType.VarChar).Value = dt1.Rows[0][7].ToString();
            cmd3.Parameters.Add("@isApprove", OdbcType.VarChar).Value = "YES";
            cmd3.Parameters.Add("@isApprove", OdbcType.VarChar).Value = 0 ;

            //cmd3.Parameters.Add("@Archived_Operator_ID", OdbcType.VarChar).Value = dt1.Rows[0][0].ToString();
            if (cmd3.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Successfully Insert @ Registered");
            }
            con.Close();


            con.Open();
            OdbcCommand cmd6 = new OdbcCommand();
            cmd6 = con.CreateCommand();
            cmd6.CommandText = "DELETE FROM accounts_archive WHERE admin_id = '" + lblShowID.Text + "'";
            cmd6.ExecuteNonQuery();
            con.Close();

               display();

            }

           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
               con.Close();
           }
        }

        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT admin_id as `ID`, fullname as `NAME`, username as `USERNAME`, level as `LEVEL` FROM accounts_archive;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvPA.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OdbcConnection cons = new OdbcConnection("dsn=capstone");
            cons.Open();
            OdbcCommand commands = new OdbcCommand("SELECT admin_id, fullname, username, level FROM accounts_archive WHERE admin_id LIKE '%" + txtSearch.Text + "%' OR fullname LIKE '%" + txtSearch.Text + "%' OR username LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvPA.DataSource = dt;
            con.Close();

            dgvPA.Columns[0].HeaderText = "ADMIN ID";
            dgvPA.Columns[1].HeaderText = "FULLNAME";
            dgvPA.Columns[3].HeaderText = "LEVEL";
        }
    }
}