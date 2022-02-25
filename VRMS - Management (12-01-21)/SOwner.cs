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
    public partial class SOwner : Form
    {
        public SOwner()
        {
            InitializeComponent();
        }

        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //FORM LOAD
        private void SOwner_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY REGISTERED VEHICLES
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT qrtext as `VEHICLE ID`, owner_id as `OWNER ID`, plate_num as `PLATE NUMBER`, type as `TYPE OF VEHICLE`, brand as `BRAND` FROM registered_vehicles;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvRegVec.DataSource = ds.Tables[0];
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
            //OdbcCommand commands = new OdbcCommand("select * from t_car_info where platen like '" + txtSearch.Text + "%' OR o_id like '" + txtSearch.Text + "%' OR type like '" + txtSearch.Text + "%'", cons);
            OdbcCommand commands = new OdbcCommand("SELECT qrtext, owner_id, plate_num, type, brand FROM registered_vehicles WHERE plate_num LIKE '" + txtSearch.Text + "%' OR owner_id LIKE '" + txtSearch.Text + "%' OR type LIKE '" + txtSearch.Text + "%' OR qrtext LIKE '" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvRegVec.DataSource = dt;
            con.Close();

            dgvRegVec.Columns[0].HeaderText = "VEHICLE ID";
            dgvRegVec.Columns[1].HeaderText = "OWNER ID";
            dgvRegVec.Columns[2].HeaderText = "PLATE NUMBER";
            dgvRegVec.Columns[3].HeaderText = "TYPE OF VEHICLE";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteForm df = new DeleteForm();
            df.lblShowID.Text = lblShowID.Text;
            df.ShowDialog();
        }

        private void dgvRegVec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            lblShowID.Text = dgvRegVec.Rows[e.RowIndex].Cells["Vehicle ID"].FormattedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddVehicle av = new AddVehicle();
            av.ShowDialog();
        }
    }

       
    }
   

