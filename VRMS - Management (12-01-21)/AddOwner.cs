using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.Odbc;
using System.IO;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Security.Cryptography;


namespace VRMS___Management__12_01_21_
{
    public partial class AddOwner : Form
    {

        public AddOwner()
        {
            InitializeComponent();

        }

        OdbcConnection con = new OdbcConnection("dsn=capstone");
        QrCodeEncodingOptions options = new QrCodeEncodingOptions();
        private FilterInfoCollection CaptureDevices;
        private VideoCaptureDevice videoSource;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOwner_Load(object sender, EventArgs e)
        {
            gunaAdvenceButton3.Enabled = false;
            if (pictureBox1.Image == null)
            {
                cmbOtype.Enabled = false;
                txtFullname.Enabled = false;
                txtSchoolID.Enabled = false;
            }
            else
            {
                cmbOtype.Enabled = true;
                txtFullname.Enabled = true;
                txtSchoolID.Enabled = true;
            }


            if (pictureBox4.Image == null)
            {
                txtOwnerID.Enabled = false;
                bunifuCustomTextbox1.Enabled =false;
                cmbWheels.Enabled = false;
                
            }

            CaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevices)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                videoSource.Stop();
                this.Close();
            }catch(Exception ex){
                this.Close();
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs EventArgs)
        {
            pictureBox1.Image = (Bitmap)EventArgs.Frame.Clone();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(CaptureDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Random rn = new Random();
                int temp;
                textBox1.Text = rn.Next(6000, 10000).ToString();
                label14.Text = DateTime.Now.ToString("yy-") + textBox1.Text;
                con.Open();
                OdbcCommand command = new OdbcCommand("SELECT count(owner_id) FROM registered_owners WHERE owner_id = '" + label14.Text + "' ", con);
                int exist = Convert.ToInt32(command.ExecuteScalar());
                con.Close();
                if (exist == null)
                {
                    temp = 1;
                }
                else
                {

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

                    if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
                    {
                        pictureBox2.Image = null;
                        MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var qr = new ZXing.BarcodeWriter();
                        qr.Options = options;
                        qr.Format = ZXing.BarcodeFormat.QR_CODE;
                        var result = new Bitmap(qr.Write(label14.Text.Trim()));
                        pictureBox3.Image = result;
                    }

                    
                    con.Open();
                    OdbcCommand cmd = new OdbcCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO registered_owners(owner_id,school_id,type,fullname)VALUES(?,?,?,?)";
                    cmd.Parameters.Add("@owner_id", OdbcType.VarChar).Value = label14.Text;
                    cmd.Parameters.Add("@school_id", OdbcType.VarChar).Value = txtSchoolID.Text;
                    cmd.Parameters.Add("@type", OdbcType.VarChar).Value = cmbOtype.Text;
                    cmd.Parameters.Add("@fullname", OdbcType.VarChar).Value = txtFullname.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Owner ID: " + label14.Text, "Data Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();


                    o_pic();
                    txtSchoolID.Enabled=false;
                    txtFullname.Enabled=false;
                    pictureBox1.Enabled=false;
                    cmbOtype.Enabled = false;
                    txtOwnerID.Text = label14.Text;
                    nameVal.Text = txtFullname.Text;
                    gunaAdvenceButton3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtSchoolID.Text = "";
                txtFullname.Text = "";
                videoSource.Stop();
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void o_pic()
        {
            MemoryStream ms4 = new MemoryStream();
            pictureBox2.Image.Save(ms4, System.Drawing.Imaging.ImageFormat.Png);
            byte[] photo4 = new byte[ms4.Length];
            ms4.Position = 0;
            ms4.Read(photo4, 0, photo4.Length);
            try
            {
                con.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO owner_pic(owner_id,img)VALUES(?,?)";
                cmd.Parameters.Add("@o_id", OdbcType.VarChar).Value = "22-" + textBox1.Text;
                cmd.Parameters.Add("@email", OdbcType.Image).Value = photo4;
                cmd.ExecuteNonQuery();
                con.Close();
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTphoto_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null){
                cmbOtype.Enabled = true;
                txtFullname.Enabled = true;
                txtSchoolID.Enabled = true;   
            }
            pictureBox2.Image = pictureBox1.Image;
            videoSource.Stop();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning == true)
            {
                videoSource.Stop();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                pictureBox2.Image = null;
                pictureBox2.Invalidate();
                videoSource.Start();
            }
            else
            {
                videoSource.Stop();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                pictureBox2.Image = null;
                pictureBox2.Invalidate();
                videoSource.Start();
            }
        }


        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            try
            {
                videoSource.Stop();
                this.Close();
            }
            catch (Exception ex)
            {
                videoSource.Stop();
                this.Close();
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();  
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";  
            if (open.ShowDialog() == DialogResult.OK) {  
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

        //Encryption
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

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            IDPrint print = new IDPrint();
            try
            {
                Random rn = new Random();
                int temp;
                textBox2.Text = rn.Next(6000, 10000).ToString();
                String search = DateTime.Now.ToString("yy-") + textBox2.Text;
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
