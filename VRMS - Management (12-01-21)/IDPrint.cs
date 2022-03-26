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

namespace VRMS___Management__12_01_21_
{
    public partial class IDPrint : Form
    {
        public IDPrint()
        {
            InitializeComponent();
        }
        
        private void IDPrint_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 410);
            printPreviewControl1.Zoom = 1.27;
            printPreviewControl1.Document = printDocument1;
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
                printPreviewControl1.Zoom = 1.27;
                printPreviewControl1.Document = printDocument1;
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
                printPreviewControl1.Zoom = 1.27;
                printPreviewControl1.Document = printDocument1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 350, 400);
                printPreviewControl1.Zoom = 1.27;
                printPreviewControl1.Document = printDocument1;
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void picEmployeeback_Click(object sender, EventArgs e)
        {

        }

    }
}
