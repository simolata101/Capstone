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
using DGVPrinterHelper;

namespace VRMS___Management__12_01_21_
{
    public partial class LHistory : Form
    {
        public LHistory()
        {
            InitializeComponent();
        }


        //CONNECTION
        OdbcConnection con = new OdbcConnection("dsn=capstone");


        //LOAD
        private void LHistory_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT admin_id as `ADMIN ID`, fullname as `FULLNAME`, access as `TYPE OF ADMIN`, date as `DATE`, time as `TIME`, event as  `EVENT` FROM loghistory ORDER BY date DESC;", con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptr.Fill(ds, "Empty");
                dgvLH.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        //TEXT SEARCH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OdbcConnection cons = new OdbcConnection("dsn=capstone");
            cons.Open();
            OdbcCommand commands = new OdbcCommand("SELECT admin_id as `ADMIN ID`, fullname as `FULLNAME`, access as `TYPE OF ADMIN`, date as `DATE`, time as `TIME`, event as  `EVENT` FROM loghistory WHERE admin_id LIKE '%" + txtSearch.Text + "%' OR fullname LIKE '%" + txtSearch.Text + "%' OR time LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvLH.DataSource = dt;
            con.Close();

            //dgvLH.Columns[1].HeaderText = "FULLNAME";
            //dgvLH.Columns[2].HeaderText = "ACCESS";
            //dgvLH.Columns[3].HeaderText = "DATE";
            //dgvLH.Columns[4].HeaderText = "TIME";
            //dgvLH.Columns[5].HeaderText = "ADMIN ID";
            //dgvLH.Columns[5].HeaderText = "EVENT";
            
        }

        //FIND FILTER FROM AND TO
        private void btnFind_Click(object sender, EventArgs e)
        {
            Filter();
        }

        //FILTER DATA
        void Filter()
        {
            try
            {
                OdbcConnection cons = new OdbcConnection("dsn=capstone");
                cons.Open();

                txtFrom.Text = dtpFrom.Text;
                txtTo.Text = dtpTo.Text;
                //OdbcCommand commands = new OdbcCommand("SELECT fullname, access, date, time, event FROM loghistory WHERE 'date' BETWEEN @from AND @too", cons);
                OdbcCommand commands = new OdbcCommand("SELECT admin_id as `ADMIN ID`, fullname as `FULLNAME`, access as `TYPE OF ADMIN`, date as `DATE`, time as `TIME`, event as  `EVENT` FROM loghistory WHERE date LIKE '%" + txtFrom.Text + "%' OR date LIKE '%" + txtTo.Text + "%'", cons);

                // BETWEEN @from and @too
                OdbcDataAdapter adptrrr = new OdbcDataAdapter(commands);
                DataTable dtt = new DataTable();
                //adptrrr.SelectCommand.Parameters.AddWithValue("@from", dtpFrom.Value);
                //adptrrr.SelectCommand.Parameters.AddWithValue("@too", dtpTo.Value);
                //adptrrr.SelectCommand.Parameters.AddWithValue("@from", txtFrom.Text);
                //adptrrr.SelectCommand.Parameters.AddWithValue("@too", txtTo.Text);
                adptrrr.Fill(dtt);
                dgvLH.DataSource = dtt;
                con.Close();

                //dgvLH.Columns[0].HeaderText = "ID";
                //dgvLH.Columns[1].HeaderText = "FULLNAME";
                //dgvLH.Columns[2].HeaderText = "ACCESS";
                //dgvLH.Columns[3].HeaderText = "DATE";
                //dgvLH.Columns[4].HeaderText = "TIME";
                //dgvLH.Columns[5].HeaderText = "ADMIN ID";
                //dgvLH.Columns[6].HeaderText = "EVENT";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            

        }

        //PRINT LOGIN HISTORY
        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
                Bitmap bitmap1 = new Bitmap(@"C:\Users\Simolata\Source\Repos\simolata101\Capstone\VRMS - Management (New Version Feb 21)\Resources\img\qcu2.png");
                // This code is to crop the image size
                //System.Drawing.(bitmap1, 60, 50 ,img1.width, img1.height);
                //  System.Drawing.Bitmap(bitmap1,60,50 img1.Width,img1.Height);
                img1.theImage = bitmap1; img1.ImageX = 140; img1.ImageY = 10;
                img1.ImageAlignment = DGVPrinter.Alignment.NotSet;
                img1.ImageLocation = DGVPrinter.Location.Header;
                printer.ImbeddedImageList.Add(img1);
                printer.Title = "QUEZON CITY UNIVERSITY";
                printer.SubTitle = string.Format("VEHICLE RECORDS MANAGEMENT SYSTEM", printer.SubTitleColor = Color.Black, printer, printer);
                printer.SubTitle = string.Format("LOGIN / LOGOUT HISTORY", printer.SubTitleColor = Color.Black, printer);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.Footer = " All rights reserved by Vehicle System";
                printer.FooterSpacing = 15;
                printer.TitleSpacing = 10;
                printer.SubTitleSpacing = 30;

                printer.PrintPreviewDataGridView(dgvLH);


                //OdbcConnection conss = new OdbcConnection("dsn=capstone");
                //conss.Open();
                //OdbcCommand commandss = new OdbcCommand("INSERT INTO audit_trails (fullname, access, date, time, admin_id, activity) values (?, ?, ?, ?, ?, ?)  ", conss);

                //OdbcDataAdapter adptrrrr = new OdbcDataAdapter(commandss);


                //adptrrrr.SelectCommand.Parameters.AddWithValue("fullname", OdbcType.VarChar).Value = handler;
                //adptrrrr.SelectCommand.Parameters.AddWithValue("access", OdbcType.VarChar).Value = "ADMIN";
                //adptrrrr.SelectCommand.Parameters.AddWithValue("date", OdbcType.VarChar).Value = date;
                //adptrrrr.SelectCommand.Parameters.AddWithValue("time", OdbcType.VarChar).Value = time;
                //adptrrrr.SelectCommand.Parameters.AddWithValue("admin_id", OdbcType.VarChar).Value = adminid;
                //adptrrrr.SelectCommand.Parameters.AddWithValue("activity", OdbcType.VarChar).Value = "PRINTED LOGIN HISTORY";

                con.Open();
                OdbcCommand cmd1 = new OdbcCommand();
                cmd1 = con.CreateCommand();

                VRMS___Management__12_01_21_.Dashboard call = new Dashboard();

                cmd1.CommandText = "INSERT INTO audit_trails (fullname, access, date, time, admin_id, activity) values (?, ?, ?, ?, ?, ?)  ";
                //cmd1.Parameters.Add("@fullname", OdbcType.VarChar).Value = lblCurrent.Text;
                cmd1.Parameters.Add("@access", OdbcType.VarChar).Value = "OSAS";
                //cmd1.Parameters.Add("@date", OdbcType.VarChar).Value = lblDate.Text;
                //cmd1.Parameters.Add("@time", OdbcType.VarChar).Value = lblTime.Text;
                //cmd1.Parameters.Add("@admin_id", OdbcType.VarChar).Value = lblAdminID.Text;
                cmd1.Parameters.Add("@activity", OdbcType.VarChar).Value = "LOGIN";
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            catch(Exception ex)
            {
                con.Close();
            }
        }

        
    }
}
