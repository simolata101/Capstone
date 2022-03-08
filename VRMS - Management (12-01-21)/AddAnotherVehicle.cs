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
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Security.Cryptography;
using System.IO;

namespace VRMS___Management__12_01_21_
{
    public partial class AddAnotherVehicle : Form
    {
        public AddAnotherVehicle()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");
        QrCodeEncodingOptions options = new QrCodeEncodingOptions();
        private void txtOperatorID_TextChanged(object sender, EventArgs e)
        {
            txtOwnerID.Text = txtOperatorID.Text;
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT type,school_id,fullname FROM registered_owners WHERE owner_id = '"+txtOperatorID.Text+"';",con);
                OdbcDataAdapter adptr = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adptr.Fill(dt);
                lblOperatorClass.Text = dt.Rows[0][0].ToString();
                label11.Text = dt.Rows[0][1].ToString();
                label14.Text = dt.Rows[0][2].ToString();
                nameVal.Text = dt.Rows[0][2].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                lblOperatorClass.Text = "";
                label11.Text = "";
                label14.Text = "";
                con.Close();
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox4.Image = new Bitmap(open.FileName);
                // image file path  
            }
            if (pictureBox4.Image != null)
            {
                txtOwnerID.Enabled = true;
                bunifuCustomTextbox1.Enabled = true;
                cmbWheels.Enabled = true;
            }
        }

        private void AddAnotherVehicle_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (pictureBox4.Image == null)
            {
                txtOwnerID.Enabled = false;
                bunifuCustomTextbox1.Enabled = false;
                cmbWheels.Enabled = false;
            }
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            IDPrint print = new IDPrint();
            try
            {
                Random rn = new Random();
                int temp;
                String search = DateTime.Now.ToString("yy-") + rn.Next(6000, 10000).ToString();
                con.Open();
                OdbcCommand command = new OdbcCommand("SELECT COUNT(qrtext) FROM registered_vehicles WHERE qrtext = '" + search + "' ", con);
                int exist = Convert.ToInt32(command.ExecuteScalar());
                con.Close();
                if (exist == null)
                {
                    temp = 1;
                }
                else
                {
                    string enc = EncryptString("AAECAwQFBgcICQoLDA0ODw==", search);
                    Enc.Text = enc;
                    if (search == null)
                    {
                        pictureBox5.Image = null;
                        MessageBox.Show("No generate barcode");
                    }
                    else
                    {
                        options = new ZXing.QrCode.QrCodeEncodingOptions
                        {
                            DisableECI = true,
                            CharacterSet = "UTF-8",
                            Width = 250,
                            Height = 250,
                        };
                        var qr = new ZXing.BarcodeWriter();
                        qr.Options = options;
                        qr.Format = ZXing.BarcodeFormat.QR_CODE;
                        var result = new Bitmap(qr.Write(Enc.Text.Trim()));
                        pictureBox5.Image = result;
                        print.pictureBox2.Image = pictureBox5.Image;
                    }
                    con.Open();
                    OdbcCommand cmd = new OdbcCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO registered_vehicles(qrtext,type,plate_num,owner_id,enc)VALUES(?,?,?,?,?)";
                    cmd.Parameters.Add("@qrtext", OdbcType.VarChar).Value = search;
                    cmd.Parameters.Add("@type", OdbcType.VarChar).Value = cmbWheels.Text;
                    cmd.Parameters.Add("@plate_num", OdbcType.VarChar).Value = bunifuCustomTextbox1.Text;
                    cmd.Parameters.Add("@owner_id", OdbcType.VarChar).Value = txtOwnerID.Text;
                    cmd.Parameters.Add("@enc", OdbcType.VarChar).Value = Enc.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Vehicle ID: " + search, "Data Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();
                    bunifuCustomTextbox1.Text = "";
                    print.Show();
                }
            }
            catch (Exception ex)
            {
                con.Close();
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

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
