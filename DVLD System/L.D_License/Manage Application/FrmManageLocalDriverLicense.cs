using DVLD_BussinessLayer;
using DVLD_System.L.D_License.Manage_Application.Street_Test;
using DVLD_System.L.D_License.Manage_Application.Tests;
using DVLD_System.L.D_License.Manage_Application.Written_Test;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_System.L.D_License.Manage_Application.FrmIssueDriverLicense;

namespace DVLD_System.L.D_License.Manage_Application
{
    public partial class FrmManageLocalDriverLicense : MaterialSkin.Controls.MaterialForm
    {
        public FrmManageLocalDriverLicense()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private DataTable dtSourceLocalDrivingLicenseApp = 
            clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllLocalDApp.Rows.Count.ToString();
        }

        private void DataGridViewHandlerWidth()
        {
            dgvAllLocalDApp.DataSource = dtSourceLocalDrivingLicenseApp;

            dgvAllLocalDApp.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "LocalDrivingLicenseApplication ID";
            dgvAllLocalDApp.Columns["LocalDrivingLicenseApplicationID"].Width = 130;

            dgvAllLocalDApp.Columns["ClassName"].HeaderText = "Class Name";
            dgvAllLocalDApp.Columns["ClassName"].Width = 120;

            dgvAllLocalDApp.Columns["NationalNo"].HeaderText = "National No";
            dgvAllLocalDApp.Columns["NationalNo"].Width = 130;

            dgvAllLocalDApp.Columns["FullName"].HeaderText = "Full Name";
            dgvAllLocalDApp.Columns["FullName"].Width = 140;

            dgvAllLocalDApp.Columns["ApplicationDate"].HeaderText = "ApplicationDate";
            dgvAllLocalDApp.Columns["ApplicationDate"].Width = 150;

            dgvAllLocalDApp.Columns["PassedTestCount"].HeaderText = "PassedTest Count";
            dgvAllLocalDApp.Columns["PassedTestCount"].Width = 160;

            dgvAllLocalDApp.Columns["Status"].HeaderText = "Status";
            dgvAllLocalDApp.Columns["Status"].Width = 170;

            cbFilter.SelectedIndex = 0;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllLocalDApp.BorderStyle = BorderStyle.None;
            dgvAllLocalDApp.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllLocalDApp.RowHeadersVisible = false;

            dgvAllLocalDApp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllLocalDApp.MultiSelect = false;
            dgvAllLocalDApp.ReadOnly = true;
            dgvAllLocalDApp.EnableHeadersVisualStyles = false;

            dgvAllLocalDApp.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllLocalDApp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllLocalDApp.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllLocalDApp.DefaultCellStyle.BackColor = Color.White;
            dgvAllLocalDApp.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllLocalDApp.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllLocalDApp.DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        

        private void FrmManageLocalDriverLicense_Load(object sender, EventArgs e)
        {
            DataGridViewHandlerWidth();
            DataGridViewHandlerStyle();
            RecordsNumber();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
            }
        }

        private void ApplyFilter()
        {
            string FilterColumn = "";
            if (cbFilter.SelectedIndex == 1)
            {
                FilterColumn = "LocalDrivingLicenseApplicationID";
                dtSourceLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
            else if (cbFilter.SelectedIndex == 2)
            {
                FilterColumn = "NationalNo";
                dtSourceLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                ApplyFilter();
            }
            else
            {
                dtSourceLocalDrivingLicenseApp.DefaultView.RowFilter = "";
                RecordsNumber();
                return;
            }
        }


        private void ReloadData()
        {
            dtSourceLocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvAllLocalDApp.DataSource = dtSourceLocalDrivingLicenseApp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNewLocalDriverLicense newLocalDriverLicense = new FrmNewLocalDriverLicense();
            newLocalDriverLicense.ShowDialog();
            ReloadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void TestEnabled()
        {
            if (clsLocalDrivingLicenseApplication
                .GetPassedTestCount
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value)) == 0)
            {
                schedualToolStripMenuItem.Enabled = true;
                scheduleWritenTestToolStripMenuItem.Enabled = false;
                scheduToolStripMenuItem.Enabled = false;
                SchduleApplicationToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }

            else if (clsLocalDrivingLicenseApplication
                .GetPassedTestCount
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value)) == 1)
            {
                schedualToolStripMenuItem.Enabled = false;
                scheduleWritenTestToolStripMenuItem.Enabled = true;
                SchduleApplicationToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else if (clsLocalDrivingLicenseApplication
                .GetPassedTestCount
                (Convert.ToInt32
                (dgvAllLocalDApp.CurrentRow.Cells[0].Value)) == 2)
            {
                schedualToolStripMenuItem.Enabled = false;
                scheduleWritenTestToolStripMenuItem.Enabled = false;
                scheduToolStripMenuItem.Enabled = true;
                SchduleApplicationToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else
            {
                SchduleApplicationToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
        }

        private void cancelApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Cancel This Application" , "Warning" 
                ,MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int ApplicationID = clsApplication.GetApplicationIDUsingLDAppID
                    (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
                clsApplication.CancelPersonApplication
                    (ApplicationID);
            }

            ReloadData();
        }

        private void schedualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisionTest VisionTestForm = new FrmVisionTest
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            VisionTestForm.ShowDialog();
        }

        private void scheduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWrittenTest frmWrittenTest =
                new FrmWrittenTest(Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            frmWrittenTest.ShowDialog();
        }

        private void materialContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            TestEnabled();

            int AppID = FindApplicationID(_LDAppInfo);
            if (clsLicense.IsLicenseExists_ByApplicationID(AppID))
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
            }

            string className = Convert.ToString(dgvAllLocalDApp.CurrentRow.Cells[1].Value);
            string NationalNo = Convert.ToString(dgvAllLocalDApp.CurrentRow.Cells[2].Value);

            if (clsLocalDrivingLicenseApplication.IsExistClassApplicationWithStatusCompleted
                (NationalNo , className))
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem1.Enabled = false;
            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem1.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled=false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private clsLocalDrivingLicenseApplication _LDAppInfo;
        

        private int FindApplicationID(clsLocalDrivingLicenseApplication LDAppInfo)
        {
            LDAppInfo = clsLocalDrivingLicenseApplication.
                Find(Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            if (LDAppInfo != null)
            {
                return LDAppInfo.ApplicationID;
            }

            return -1;
        }

        private void scheduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStreetTest frmStreetTest =
              new FrmStreetTest(Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            frmStreetTest.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssueDriverLicense issueDriverLicense = new FrmIssueDriverLicense
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            issueDriverLicense.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicense frmShowLicense = new FrmShowLicense
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            frmShowLicense.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LDAppInfo = clsLocalDrivingLicenseApplication.Find
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));

            int AppID = _LDAppInfo.ApplicationID;


            if (MessageBox.Show("Are You Sure Delete This Local Drive License ?" , "Warning" 
                ,MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.Delete(Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value)))
                {
                    if (clsApplication.Delete(AppID))
                    {
                        MessageBox.Show("Deleted Is Successfully", "Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadData();
                        RecordsNumber();
                    }
                    else
                    {
                        MessageBox.Show("SomeThing Error", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory
                (Convert.ToInt32(dgvAllLocalDApp.CurrentRow.Cells[0].Value));
            frmLicenseHistory.ShowDialog();
        }
    }
}
