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
    public partial class ArchiveProprietary : Form
    {
        public ArchiveProprietary()
        {
            InitializeComponent();
        }

        OdbcConnection con = new OdbcConnection("dsn=capstone");

        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT Archived_Operator_Owner_ID as 'PROPRIETARY ID', Archived_Operator_Sch_ID as 'SCHOOL ID', Archived_Operator_Last as 'LAST NAME', Archived_Operator_fullname as 'FIRST NAME', Archived_Operator_Mid as 'M.I.', Archived_Operator_Suffix as 'SUFFIX', Archived_Operator_type as 'OWNER TYPE' FROM Archived;", con);
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
        private void dgvAT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String OWID;
                OWID = dgvAT.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                lblShowID.Text = OWID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

            try
            {
            //OdbcCommand cmd1 = new OdbcCommand("SELECT * FROM registered_owners WHERE owner_id = '" + lblShowID.Text + "'", con);
            OdbcCommand cmd1 = new OdbcCommand("SELECT * FROM Archived WHERE Archived_Operator_Owner_ID = '" + lblShowID.Text + "'", con);
            OdbcDataAdapter adptr1 = new OdbcDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adptr1.Fill(dt1);
            con.Close();

            //insert data of owners in archived table
            con.Open();
            OdbcCommand cmd3 = new OdbcCommand();
            cmd3 = con.CreateCommand();
            //cmd3.CommandText = "INSERT INTO Archived(Archived_Operator_Owner_ID,Archived_Operator_Sch_ID,Archived_Operator_type,Archived_Operator_fullname,Archived_Operator_Mid,Archived_Operator_Last,Archived_Operator_Suffix)VALUES(?,?,?,?,?,?,?)";
            cmd3.CommandText = "INSERT INTO registered_owners(owner_id,school_id,type,fname,mname,lname,suf)VALUES(?,?,?,?,?,?,?)";
            cmd3.Parameters.Add("@owner_id", OdbcType.VarChar).Value = dt1.Rows[0][4].ToString(); ;
            cmd3.Parameters.Add("@school_id", OdbcType.VarChar).Value = dt1.Rows[0][1].ToString();
            cmd3.Parameters.Add("@type", OdbcType.VarChar).Value = dt1.Rows[0][2].ToString();
            cmd3.Parameters.Add("@fname", OdbcType.VarChar).Value = dt1.Rows[0][3].ToString();
            cmd3.Parameters.Add("@mname", OdbcType.VarChar).Value = dt1.Rows[0][5].ToString();
            cmd3.Parameters.Add("@lname", OdbcType.VarChar).Value = dt1.Rows[0][6].ToString();
            cmd3.Parameters.Add("@suf", OdbcType.VarChar).Value = dt1.Rows[0][7].ToString();
            //cmd3.Parameters.Add("@Archived_Operator_ID", OdbcType.VarChar).Value = dt1.Rows[0][0].ToString();
            if (cmd3.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Successfully Insert @ Registered");
            }
            con.Close();


            con.Open();
            OdbcCommand cmd6 = new OdbcCommand();
            cmd6 = con.CreateCommand();
            cmd6.CommandText = "DELETE FROM Archived WHERE Archived_Operator_Owner_ID = '" + lblShowID.Text + "'";
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


        private void ArchiveProprietary_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
