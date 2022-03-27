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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }
        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
        try

                {
                    con.Open();
                    OdbcCommand cmd4 = new OdbcCommand("SELECT qrtext,type,plate_num,owner_id,enc FROM registered_vehicles WHERE qrtext = '" + lblShowID.Text + "'", con);
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
             



                con.Open();
                OdbcCommand cmd7 = new OdbcCommand();
                cmd7 = con.CreateCommand();
                cmd7.CommandText = "DELETE FROM registered_vehicles WHERE qrtext = '" + lblShowID.Text + "'";
                cmd7.ExecuteNonQuery();
                if (cmd7.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Registered Vehicle Data was Deleted Succesfuly");
                    this.Close();
                }
                MessageBox.Show("Registered Vehicle Data was Deleted Succesfuly");
                this.Close();
                con.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
               
            }
        }
    }
}
