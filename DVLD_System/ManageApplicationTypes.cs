using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application;

namespace DVLD_System
{
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvAllApplications.DataSource = clsApplication.GetAllApplicationType();
            lblRecordsValue.Text = clsApplication.GetCountRecordsInApplicationType().ToString();
        }


        private void _RefershData()
        {
            dgvAllApplications.DataSource = clsApplication.GetAllApplicationType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplicationType EditAppForm = new EditApplicationType(Convert.ToInt32(dgvAllApplications.CurrentRow.Cells[0].Value));
            EditAppForm.ShowDialog();
            _RefershData();
        }
    }
}
