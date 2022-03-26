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
    public partial class DashboardPanel : Form
    {
        public DashboardPanel()
        {
            InitializeComponent();
        }

        OdbcConnection con = new OdbcConnection("dsn=capstone");
        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DashboardPanel_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
