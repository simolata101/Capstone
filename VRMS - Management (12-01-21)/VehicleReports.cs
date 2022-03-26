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
    public partial class VehicleReports : Form
    {
        public VehicleReports()
        {
            InitializeComponent();
        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VehicleReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.DataTable2' table. You can move, or remove it, as needed.
          
            this.DataTable1TableAdapter.filldate(this.DataSet1.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
           
            this.DataTable1TableAdapter.Filldata2(this.DataSet1.DataTable1, dtpFrom.Text);

            this.reportViewer1.RefreshReport();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
