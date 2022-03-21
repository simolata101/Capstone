using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using ZXing.QrCode;
using ZXing;
using System.Security.Cryptography;
using System.IO;

namespace VRMS___Management__12_01_21_
{
    public partial class IDGenerate : Form
    {
        public IDGenerate()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IDGenerate_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 410);
            printPreviewControl2.Zoom = 1.27;
            printPreviewControl2.Document = printDocument1;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (label1.Text == "STUDENT")
            {
                Font f = new Font("Open Sans Light", 12);
                e.Graphics.DrawImage(picFront.Image, 0, 0, 350, 200);
                e.Graphics.DrawImage(picStudentback.Image, 0, 220, 350, 200);
                e.Graphics.DrawImage(pictureBox2.Image, 250, 110, 100, 100);
                e.Graphics.DrawString(lblID.Text, f, Brushes.Tan, 85, 125);
                e.Graphics.DrawString(lblFullname.Text, f, Brushes.Black, 150, 275);
                e.Graphics.DrawString(lblCompanyID.Text, f, Brushes.Black, 150, 300);
                e.Graphics.DrawString(lblContact.Text, f, Brushes.Black, 150, 325);
                e.Graphics.DrawString(".", f, Brushes.Black, 0, 0);
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 200);
                printPreviewControl2.Zoom = 1.27;
                printPreviewControl2.Document = printDocument1;
            }
            else
            {
                Font f = new Font("Open Sans Light", 12);
                e.Graphics.DrawImage(picFront.Image, 0, 0, 350, 200);
                e.Graphics.DrawImage(picEmployeeback.Image, 0, 220, 350, 200);
                e.Graphics.DrawImage(pictureBox2.Image, 250, 110, 100, 100);
                e.Graphics.DrawString(lblID.Text, f, Brushes.Tan, 85, 125);
                e.Graphics.DrawString(lblFullname.Text, f, Brushes.Black, 150, 275);
                e.Graphics.DrawString(lblCompanyID.Text, f, Brushes.Black, 150, 300);
                e.Graphics.DrawString(lblContact.Text, f, Brushes.Black, 150, 325);
                e.Graphics.DrawString(".", f, Brushes.Black, 0, 0);
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 200);
                printPreviewControl2.Zoom = 1.27;
                printPreviewControl2.Document = printDocument1;
            }
        }

        private void printPreviewControl2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        string i,SchoolID,Types;
        private void checker()
        {
            try
            {
                if (txtScan.Text.Length >= 4)
                {

                    OdbcCommand cmdd = new OdbcCommand("SELECT * FROM registered_owners WHERE owner_id like '" + txtScan.Text + "';", con);
                    OdbcDataAdapter adptrr = new OdbcDataAdapter(cmdd);
                    DataTable dtt = new DataTable();
                    adptrr.Fill(dtt);
                    

                    i = dtt.Rows[0][4].ToString();
                    i = i + " " + dtt.Rows[0][5].ToString();
                    i = i + " " + dtt.Rows[0][6].ToString();

                    txtPID.Text = dtt.Rows[0][1].ToString();
                    SchoolID = dtt.Rows[0][2].ToString();
                    Types = dtt.Rows[0][3].ToString();
                    txtClass.Text = dtt.Rows[0][3].ToString();

                    txtfname.Text = i;
                    

                       
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unavailable ID!!!");
                con.Close();

            }

        }


        private void AddingCMB() {
            try
            {
                con.Open();
                OdbcCommand cmdd = new OdbcCommand("SELECT * FROM registered_vehicles WHERE owner_id like '" + txtScan.Text + "';", con);
                OdbcDataAdapter adptrrr = new OdbcDataAdapter(cmdd);
                DataSet dttt = new DataSet();
               
                
                adptrrr.Fill(dttt);

                cmbV_ID.DataSource = dttt.Tables[0];
                cmbV_ID.DisplayMember = "qrtext";
                cmbV_ID.ValueMember = "id";
                cmbV_ID.Enabled = true;
                this.cmbV_ID.SelectedIndex = -1;
                cmdd.ExecuteNonQuery();
                con.Close();

               
                

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                con.Close();

            }
        
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            checker();
            AddingCMB();
        }

        public void cmbChecker() {
            try
            {
                if (cmbV_ID.Text != "")
                {
                    OdbcCommand cmdds = new OdbcCommand("SELECT * FROM registered_vehicles WHERE qrtext like '" + cmbV_ID.Text + "';", con);
                    OdbcDataAdapter adptrrrr = new OdbcDataAdapter(cmdds);
                    DataTable datable = new DataTable();
                    adptrrrr.Fill(datable);
                    txtPlatenum.Text = datable.Rows[0][3].ToString();
                    txtVehicleType.Text = datable.Rows[0][2].ToString();
                }
                else
                {

                    MessageBox.Show("Please Select Vehicle Type !!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void cmbV_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbV_ID.Text != "")
            {
                cmbChecker();
            }
            else {
            }
            
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (i != "" || SchoolID != "" || Types != "")
            {
                lblFullname.Text = i;
                lblID.Text = txtPID.Text;
                lblCompanyID.Text = SchoolID;
                lblType.Text = Types;
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 410);
                printPreviewControl2.Zoom = 1.27;
                printPreviewControl2.Document = printDocument1;
            }
            else
            {
                MessageBox.Show("Unable to Generate!");
            }

        }

        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        private void label3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbV_ID_TextChanged(object sender, EventArgs e)
        {
            string enc = EncryptString("AAECAwQFBgcICQoLDA0ODw==", cmbV_ID.Text);
            label3.Text = enc;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            if (String.IsNullOrWhiteSpace(label3.Text) || String.IsNullOrEmpty(label3.Text))
            {
                // pictureBox2.Image = null;
                MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var qr = new ZXing.BarcodeWriter();
                qr.Options = options;
                qr.Format = ZXing.BarcodeFormat.QR_CODE;
                var result = new Bitmap(qr.Write(label3.Text.Trim()));
                pictureBox2.Image = result;
            }
        }

    }
}
