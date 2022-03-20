using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRMS___Management__12_01_21_
{
    public partial class LoadingScreen : Form
    {

        int seconds;
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = seconds--.ToString();
            if (seconds < 0)
            {

                timer1.Stop();
                this.Hide();
            }
           /* panel2.Width += 3;

            if (panel2.Width >= 1040)
            {
                timer1.Stop();
                this.Hide();
            }
             
            */
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            seconds = 5;
            timer1.Start();
        }
    }
}
