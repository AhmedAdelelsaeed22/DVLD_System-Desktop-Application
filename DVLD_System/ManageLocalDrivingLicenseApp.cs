using DVLD_Application;
using DVLD_ApplicationNumberTwo;
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
    public partial class ManageLocalDrivingLicenseApp : Form
    {
        public ManageLocalDrivingLicenseApp()
        {
            InitializeComponent();
        }

        private void ManageLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            dgvAllLocalDrivingApp.DataSource = clsDrivingLicense.GetAllLocalDrivingLicense();
            lblRecordNumber.Text = clsDrivingLicense.GetDrivingLicenseCount().ToString();
            cbFilterType.SelectedIndex = 0;
            _ApplyFilteration();
        }


        private void _RefershData()
        {
            dgvAllLocalDrivingApp.DataSource = clsDrivingLicense.GetAllLocalDrivingLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddLocalLicenseForm AddForm = new AddLocalLicenseForm(-1);
            AddForm.ShowDialog();
            _RefershData();
        }


        private void _ApplyFilteration()
        {

            if (cbFilterType.SelectedIndex == 0 || string.IsNullOrEmpty(txtFilter.Text))
            {
                dgvAllLocalDrivingApp.DataSource = clsDrivingLicense.GetAllLocalDrivingLicense();
                return;
            }


            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                if (cbFilterType.SelectedIndex == 1)
                {

                    dgvAllLocalDrivingApp.DataSource = clsDrivingLicense.GetLocalDrivingLicenseUsingID(Convert.ToInt32(txtFilter.Text));
                }
                else
                {

                    dgvAllLocalDrivingApp.DataSource = clsDrivingLicense.GetLocalDrivingLicenseUsingNationalNo(txtFilter.Text);
                }
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterType.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterType.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilteration();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionTestAppiontMent visionForm = new VisionTestAppiontMent(Convert.ToInt32(dgvAllLocalDrivingApp.CurrentRow.Cells[0].Value));
            visionForm.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowApplicationDetails appDetails = new ShowApplicationDetails(Convert.ToInt32(dgvAllLocalDrivingApp.CurrentRow.Cells[0].Value));
            appDetails.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDrivingLicense drivingLicense = clsDrivingLicense.FindLocalDrivingLicenseApplications(Convert.ToInt32(dgvAllLocalDrivingApp.CurrentRow.Cells[0].Value));

            if (clsDrivingLicense.DeleteLocalDrivingLicense(drivingLicense.LocalDrivingLicenseID) 
                && clsApplication2.DeleteApplicationUsingAppID(drivingLicense.ApplicationID))
            {
                MessageBox.Show("Delete Is Succeessfully", "Successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This Client is linkable with system can not deleted", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
