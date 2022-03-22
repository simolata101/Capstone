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
    public partial class VisitorEntryReport : Form
    {
        public VisitorEntryReport()
        {
            InitializeComponent();
        }

        private void tlpHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VisitorEntryReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.FillVisitor(this.DataSet1.DataTable2);
            //this.DataTable2TableAdapter.FillVisitor(this.DataSet1.DataTable2);

            this.reportViewer1.RefreshReport();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }
    }
}
