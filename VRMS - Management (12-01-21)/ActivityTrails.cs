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
    public partial class ActivityTrails : Form
    {
        public ActivityTrails()
        {
            InitializeComponent();
        }

        //CONNECTION
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        //FORM LOAD
        private void ActivityTrails_Load(object sender, EventArgs e)
        {
            display();
        }

        //DISPLAY DATA
        public void display()
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT  fullname as `FULLNAME`, access as `TYPE OF ADMIN`, date as `DATE`, time as `TIME`, admin_id as `ACCOUNT ID`, activity as  `ACTIVITY` FROM audit_trails ORDER BY date DESC;", con);
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

        //SEARCH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OdbcConnection cons = new OdbcConnection("dsn=capstone");
            cons.Open();
            OdbcCommand commands = new OdbcCommand("SELECT fullname as `FULLNAME`, access as `TYPE OF USER`, date as `DATE`, time as `TIME`, activity as  `ACTIVITY` FROM audit_trails WHERE fullname LIKE '%" + txtSearch.Text + "%' OR access LIKE '%" + txtSearch.Text + "%'", cons);
            OdbcDataAdapter adptrr = new OdbcDataAdapter(commands);
            DataTable dt = new DataTable();
            adptrr.Fill(dt);
            dgvAT.DataSource = dt;
            con.Close();


        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
                Bitmap bitmap1 = new Bitmap(@"C:\Users\Simolata\Source\Repos\simolata101\Capstone\Resources\img\qcu2.png");
                // This code is to crop the image size
                //System.Drawing.(bitmap1, 60, 50 ,img1.width, img1.height);
                //  System.Drawing.Bitmap(bitmap1,60,50 img1.Width,img1.Height);
                img1.theImage = bitmap1; img1.ImageX = 140; img1.ImageY = 10;
                img1.ImageAlignment = DGVPrinter.Alignment.NotSet;
                img1.ImageLocation = DGVPrinter.Location.Header;
                printer.ImbeddedImageList.Add(img1);
                printer.Title = "QUEZON CITY UNIVERSITY";
                printer.SubTitle = string.Format("VEHICLE RECORDS MANAGEMENT SYSTEM", printer.SubTitleColor = Color.Black, printer, printer);
                printer.SubTitle = string.Format("ACTIVITY LOG", printer.SubTitleColor = Color.Black, printer);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.Footer = " All rights reserved by Vehicle System";
                printer.FooterSpacing = 15;
                printer.TitleSpacing = 10;
                printer.SubTitleSpacing = 30;

                printer.PrintPreviewDataGridView(dgvAT);


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

            catch (Exception ex)
            {
                con.Close();
            }
        }
    }
}
