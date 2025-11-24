using DVLD_DrivingLicenseApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ShowDriversForm : Form
    {
        public ShowDriversForm()
        {
            InitializeComponent();
        }

        private void ShowDriversForm_Load(object sender, EventArgs e)
        {
            dgvAllDrivers.DataSource = clsDrivingLicense.GetAllDrivers();
            lblRecordsValue.Text = clsDrivingLicense.GetCountDrivers().ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
