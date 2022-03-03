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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //LOGOUT
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Do you want to logout " + lblCurrent.Text + "? ", "WARNING!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ask == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OdbcCommand cmd1 = new OdbcCommand();
                    cmd1 = con.CreateCommand();
                    cmd1.CommandText = "INSERT INTO loghistory (admin_id, fullname, access, date, time, event) VALUES (?, ?, ?, ?, ?, ?)";
                    cmd1.Parameters.Add("@admin_id", OdbcType.VarChar).Value = lblAdminID.Text;
                    cmd1.Parameters.Add("@fullname", OdbcType.VarChar).Value = lblCurrent.Text;
                    cmd1.Parameters.Add("@access", OdbcType.VarChar).Value = "OSAS";
                    cmd1.Parameters.Add("@date", OdbcType.VarChar).Value = lblDate.Text;
                    cmd1.Parameters.Add("@time", OdbcType.VarChar).Value = lblTime.Text;
                    cmd1.Parameters.Add("@event", OdbcType.VarChar).Value = "LOGOUT";
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    logout();
                    this.Hide();
                    lblCurrent.Text = "";
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }

        //LOGOUT FUNCTION
        public void logout()
        {
            try
            {
                con.Open();
                OdbcCommand cmd1 = new OdbcCommand();
                cmd1 = con.CreateCommand();
                cmd1.CommandText = "UPDATE accounts SET status = 'OFFLINE' WHERE admin_id = '" + lblAdminID.Text + "'";
                cmd1.ExecuteNonQuery();
                con.Close();
                this.Hide();
                Login call = new Login();
                call.Show();
                lblCurrent.Text = "";
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        //HIDE SUB MENU
        private void hideSubMenu()
        {
            //if (PanelRegistration.Visible == true)
            //    PanelRegistration.Visible = false;
            if (PanelReports.Visible == true)
                PanelReports.Visible = false;
            if (PanelAccounts.Visible == true)
                PanelAccounts.Visible = false;
            if (PanelSystemLogs.Visible == true)
                PanelSystemLogs.Visible = false;
        }

        //SHOW SUBMENU
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //DASHBOARD
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            pnlDashboard.Show();
            pnlShow.Hide();
        }

        //OWNER REGISTRATION
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelRegistration);
        }

        //REPORTS
        private void btnReports_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelReports);
        }

        //ACCOUNTS
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelAccounts);
        }

        //SYSTEM LOGS
        private void btnSystemLogs_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSystemLogs);
        }

        //TIME AND DATE
        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
            timer.Start();
            lblDate.Text = DateTime.Now.ToString("MM - dd - yyyy");
        }

        //TIMER
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer.Start();
        }

        //FORM LOAD
        private void Dashboard_Load(object sender, EventArgs e)
        {
            RV();
            RO();
            VIQ();
            Registered();
            TwoWheels();
            FourWheels();
            //this.reportViewer1.RefreshReport();
        }

        //REGISTERED VEHICLE COUNT
        public void RV()
        {
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM registered_vehicles", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                int Rcounts = Convert.ToInt32(cmd.ExecuteScalar());
                //RVCount.Text = Rcounts.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //REGISTERED OWNER COUNT
        public void RO()
        {
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM registered_owners", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                int Rcounts = Convert.ToInt32(cmd.ExecuteScalar());
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                //ROCount.Text = Rcounts.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //VEHICLES INSIDE QCU
        public void VIQ()
        {
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM entry_monitoring", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                int Rcounts = Convert.ToInt32(cmd.ExecuteScalar());
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                //VIQCount.Text = Rcounts.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }




        

        //OWNER REGISTRATION
        private void btnOR_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.ORegistration OR = new ORegistration();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }

        //VEHICLE REGISTRATION
        private void btnVR_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.SOwner OR = new SOwner();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }

        //REGISTERED ACCOUNTS
        private void btnVA_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.VAccount OR = new VAccount();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }

        //PENDING ACCOUNTS
        private void btnPA_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.PAccount OR = new PAccount();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }

        //LOGIN / LOGOUT HISTORY
        private void btnLLH_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.LHistory OR = new LHistory();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }
       
        //AUDITTRAILS
        private void btnAT_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.ActivityTrails OR = new ActivityTrails();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
        }

        private void lblCurrent_Click(object sender, EventArgs e)
        {

        }

        public void Registered()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(owner_id) FROM registered_vehicles;",con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lblRV.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }


        public void TwoWheels()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(id) FROM registered_vehicles WHERE type LIKE '2 wheels%' ;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lbl2.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public void FourWheels()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(id) FROM registered_vehicles WHERE type LIKE '4 wheels%' ;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lbl4.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }


        private void lblRV_Click(object sender, EventArgs e)
        {

        }

        private void btnRA_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlShow.Show();
            pnlShow.Controls.Clear();
            VRMS___Management__12_01_21_.SOwner OR = new SOwner();
            OR.TopLevel = false;
            pnlShow.Controls.Add(OR);
            OR.Show();
            
        }

        private void btnRegistration_Click_1(object sender, EventArgs e)
        {

        }
    }
}
