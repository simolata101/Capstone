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
                OdbcCommand cmd = new OdbcCommand("SELECT owner_id as 'OWNER ID', school_id as 'SCHOOL ID', lname as 'LAST NAME', fname as 'FIRST NAME', mname as 'M.I.', suf as 'SUFFIX', type as 'OWNER TYPE' FROM registered_owners;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                bunifuCustomDataGrid1.DataSource = ds.Tables[0];
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
            OdbcCommand commands = new OdbcCommand("SELECT owner_id, school_id, fullname, type FROM registered_owners WHERE owner_id LIKE '%" + txtSearch.Text + "%' OR school_id LIKE '%" + txtSearch.Text + "%' OR fullname LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();

            bunifuCustomDataGrid1.Columns[0].HeaderText = "OWNER ID";
            bunifuCustomDataGrid1.Columns[1].HeaderText = "SCHOOL ID";
            bunifuCustomDataGrid1.Columns[3].HeaderText = "OWNER TYPE";
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

        private void btnDel_Click(object sender, EventArgs e)
        {

            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(owner_id) FROM registered_vehicles WHERE owner_id = '"+lblShowID.Text+"'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                con.Close();
                //count number of rows in registered vehicles
                int i = 0;
                i = Int32.Parse(dt.Rows[0][0].ToString());

                //fetch data in registered owners
                OdbcCommand cmd1 = new OdbcCommand("SELECT owner_id, school_id, type, fullname FROM registered_owners WHERE owner_id = '"+lblShowID.Text+"'",con);
                OdbcDataAdapter adptr1 = new OdbcDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adptr1.Fill(dt1);
                con.Close();

                //insert data of owners in archived table
                con.Open();
                OdbcCommand cmd3 = new OdbcCommand();
                cmd3 = con.CreateCommand();
                cmd3.CommandText = "INSERT INTO Archived(Archived_Operator_Owner_ID,Archived_Operator_Sch_ID,Archived_Operator_type,Archived_Operator_fullname)VALUES(?,?,?,?)";
                cmd3.Parameters.Add("@Archived_Operator_Owner_ID",OdbcType.VarChar).Value = dt1.Rows[0][0].ToString();
                cmd3.Parameters.Add("@Archived_Operator_Sch_ID", OdbcType.VarChar).Value = dt1.Rows[0][1].ToString();
                cmd3.Parameters.Add("@Archived_Operator_type", OdbcType.VarChar).Value = dt1.Rows[0][2].ToString();
                cmd3.Parameters.Add("@Archived_Operator_fullname", OdbcType.VarChar).Value = dt1.Rows[0][3].ToString();
                if (cmd3.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Successfully Insert @ Archived");
                }
                con.Close();


                //insert multiplerows in v_archived
                for(int o = 0; o < i; o++)
                {
                    OdbcCommand cmd4 = new OdbcCommand("SELECT qrtext,type,plate_num,owner_id,enc FROM registered_vehicles WHERE owner_id = '" + lblShowID.Text+"'",con);
                    OdbcDataAdapter adptr2 = new OdbcDataAdapter(cmd4);
                    DataTable dt2 = new DataTable();
                    adptr2.Fill(dt2);
                    con.Close();

                    con.Open();
                    OdbcCommand cmd5 = new OdbcCommand();
                    cmd5 = con.CreateCommand();
                    cmd5.CommandText = "INSERT INTO v_archived(Archived_Vehicle_Qrtext,Archived_Vehicle_type,Archived_Vehicle_PlateNum,Archived_Vehicle_OwnerID,Archived_Vehicle_Enc)VALUES(?,?,?,?,?);";
                    cmd5.Parameters.Add("@Archived_Vehicle_Qrtext",OdbcType.VarChar).Value=dt2.Rows[0][0].ToString();
                    cmd5.Parameters.Add("@Archived_Vehicle_type", OdbcType.VarChar).Value = dt2.Rows[0][1].ToString();
                    cmd5.Parameters.Add("@Archived_Vehicle_PlateNum", OdbcType.VarChar).Value = dt2.Rows[0][2].ToString();
                    cmd5.Parameters.Add("@Archived_Vehicle_OwnerID", OdbcType.VarChar).Value = dt2.Rows[0][3].ToString();
                    cmd5.Parameters.Add("@Archived_Vehicle_Enc", OdbcType.VarChar).Value = dt2.Rows[0][4].ToString();
                    cmd5.ExecuteNonQuery();
                    con.Close();
                }

                //delete of data in registered owners
                con.Open();
                OdbcCommand cmd6 = new OdbcCommand();
                cmd6 = con.CreateCommand();
                cmd6.CommandText = "DELETE FROM registered_owners WHERE owner_id = '"+lblShowID.Text+"'";
                cmd6.ExecuteNonQuery();
                con.Close();

                con.Open();
                OdbcCommand cmd7 = new OdbcCommand();
                cmd7 = con.CreateCommand();
                cmd7.CommandText = "DELETE FROM registered_vehicles WHERE owner_id = '" + lblShowID.Text + "'";
                cmd7.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        
        private void dgvRegOwn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String OWID;
                OWID = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                lblShowID.Text = OWID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblShowID_Click(object sender, EventArgs e)
        {

        }

    }
}
