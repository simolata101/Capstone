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
    public partial class DashboardShow : Form
    {
        public DashboardShow()
        {
            InitializeComponent();
        }

        
        //DATABASE
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        private void DashboardShow_Load(object sender, EventArgs e)
        {
            RV();
            RO();
            VIQ();
            Registered();
            TwoWheels();
            FourWheels();
            INSIDER();
        }

        public void Loader()
        {
            RV();
            RO();
            VIQ();
            Registered();
            TwoWheels();
            FourWheels();
            INSIDER();
        }

        public void INSIDER()
        {
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("SELECT count(*) FROM entry_monitoring WHERE event LIKE 'ENTRY%' ;", con);
                    OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    //OdbcCommand cmd2 = new OdbcCommand("SELECT count(*) FROM entry_monitoring UNION SELECT count(*) FROM exit_monitoring;  ;", con);
                    OdbcCommand cmd2 = new OdbcCommand("SELECT count(id) FROM exit_monitoring WHERE event LIKE 'EXIT%' ;", con);
                    OdbcDataAdapter adptr2 = new OdbcDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    adptr2.Fill(dt2);



                    lblvInside.Text = dt.Rows[0][0].ToString();
                    lblInsideAll.Text = dt2.Rows[0][0].ToString();


                    string gg = lblvInside.Text; //total entry
                    string gg2 = lblInsideAll.Text; //total whole in one day

                    int result = int.Parse(gg); //3
                    int resultAllentered = int.Parse(gg2) + result; //6

                    int total, total2, total3, total4;
                    total = result + resultAllentered; //9
                    total2 = (total / result); //3
                    total3 = total2 * 100;
                    total4 = (total3 / resultAllentered)+40;

                    lblInsideAll.Text = total.ToString();

                    gaugeIN.Value = total4;


                    lblInsideAll.Text = resultAllentered.ToString();

                    con.Close();



                    /*string gg = lblvInside.Text;
                    string gg2 = lblInsideAll.Text;

                    int result = Convert.ToInt32(gg);
                    int resultAllentered = Convert.ToInt32(gg2);
                    int total = (2 / 7) * 100;
                    int total1 = Convert.ToInt32(total);

                    gunaGauge1.Value = result;
                    label5.Text = total.ToString();
                    con.Close(); */
                }
                catch (Exception ex)
                {
                    con.Close();
                }

            }

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

        public void Registered()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(owner_id) FROM registered_vehicles;", con);
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
                OdbcCommand cmd = new OdbcCommand("SELECT count(id) FROM entry_monitoring WHERE type LIKE '2 wheels%' ;", con);
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
                OdbcCommand cmd = new OdbcCommand("SELECT count(id) FROM entry_monitoring WHERE type LIKE '4 wheels%' ;", con);
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

        public void ThreeWheels()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT count(id) FROM entry_monitoring WHERE type LIKE '3 wheels%' ;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lbl3.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sec = Int32.Parse(DateTime.Now.ToString("ss"));
            if (sec % 3 == 0)
            {
                INSIDER();
                try
                {
                    OdbcCommand cmd = new OdbcCommand("SELECT count(owner_id) FROM entry_monitoring WHERE type LIKE '%2 wheels%'", con);
                    OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    lbl2.Text = dt.Rows[0][0].ToString();
                    con.Close();

                    OdbcCommand cmd1 = new OdbcCommand("SELECT count(owner_id) FROM entry_monitoring WHERE type LIKE '%3 wheels%'", con);
                    OdbcDataAdapter adptr1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    adptr1.Fill(dt1);
                    lbl3.Text = dt1.Rows[0][0].ToString();
                    con.Close();

                    OdbcCommand cmd2 = new OdbcCommand("SELECT count(owner_id) FROM entry_monitoring WHERE type LIKE '%4 wheels%'", con);
                    OdbcDataAdapter adptr2 = new OdbcDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    adptr2.Fill(dt2);
                    lbl4.Text = dt2.Rows[0][0].ToString();
                    con.Close();
                }catch(Exception ex){
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
