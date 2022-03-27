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
                OdbcCommand cmd = new OdbcCommand("SELECT qrtext as `VEHICLE ID`, owner_id as `OWNER ID`, plate_num as `PLATE NUMBER`, type as `TYPE OF VEHICLE` FROM registered_vehicles;", con);
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
        private void txtScan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection cons = new OdbcConnection("dsn=capstone");
                cons.Open();
                //OdbcCommand commands = new OdbcCommand("select * from t_car_info where platen like '" + txtSearch.Text + "%' OR o_id like '" + txtSearch.Text + "%' OR type like '" + txtSearch.Text + "%'", cons);
                OdbcCommand commands = new OdbcCommand("SELECT qrtext, owner_id, plate_num, type FROM registered_vehicles WHERE plate_num LIKE '" + txtScan.Text + "%' OR owner_id LIKE '" + txtScan.Text + "%' OR type LIKE '" + txtScan.Text + "%' OR qrtext LIKE '" + txtScan.Text + "%'", cons);
                OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
                DataTable dt = new DataTable();
                adptrr.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();

                bunifuCustomDataGrid1.Columns[0].HeaderText = "VEHICLE ID";
                bunifuCustomDataGrid1.Columns[1].HeaderText = "OWNER ID";
                bunifuCustomDataGrid1.Columns[2].HeaderText = "PLATE NUMBER";
                bunifuCustomDataGrid1.Columns[3].HeaderText = "TYPE OF VEHICLE";
            }
            catch (Exception ex)
            {
                if (txtScan.TextLength >= 8)
                {
                    MessageBox.Show("Data not found");
                }
            }
            fetch();
        }

        public void fetch()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT registered_owners.owner_id,registered_owners.type,registered_owners.lname,registered_owners.fname,registered_owners.mname,registered_owners.suf,registered_vehicles.qrtext,registered_vehicles.type,registered_vehicles.plate_num FROM registered_owners JOIN registered_vehicles ON registered_owners.owner_id=registered_vehicles.owner_id WHERE registered_vehicles.qrtext = '" +txtScan.Text+ "'", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                con.Close();
                label27.Text = dt.Rows[0][0].ToString();
                label25.Text = dt.Rows[0][1].ToString();
                label22.Text = dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString() + ". " + dt.Rows[0][5].ToString();
                label20.Text = dt.Rows[0][6].ToString();
                label18.Text = dt.Rows[0][8].ToString();
                label16.Text = dt.Rows[0][7].ToString();
                label3.Text = dt.Rows[0][3].ToString();
                label2.Text = dt.Rows[0][2].ToString();
            }
            catch (Exception ex)
            {
                if (txtScan.TextLength > 7)
                {
                    MessageBox.Show("No data found.");
                }
                label27.Text = "";
                label25.Text = "";
                label22.Text = "";
                label20.Text = "";
                label18.Text = "";
                label16.Text = "";
                label3.Text = "";
                label2.Text = "";
                con.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtScan.Text == "")
            {
                MessageBox.Show("PLease select a data, you want to delete");
            }
            else { 
            DeleteForm df = new DeleteForm();
            df.lblShowID.Text = txtScan.Text;
            df.label3.Text = "Registered Vehicle";
            df.ShowDialog();
            }
        }

        private void dgvRegVec_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lblShowID.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Vehicle ID"].FormattedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAnotherVehicle av = new AddAnotherVehicle();
            av.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtScan.Text == "")
            {
                MessageBox.Show("PLease select a data, you want to update");
            }
            else
            {
                VUpdate ou = new VUpdate();
                ou.lblOID.Text = label27.Text;
                ou.txtVID.Text = label20.Text;
                ou.nameVal.Text = label3.Text;
                ou.label2.Text = label2.Text;
                ou.txtplate.Text = label18.Text;
                ou.txtType.Text = label16.Text;
                ou.ShowDialog();
                txtScan.Text = "";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpContents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String OWID, VWID;
                VWID = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                OWID = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                label1.Text = VWID;
                lblShowID.Text = OWID;
                txtScan.Text = VWID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

       
    }
   

