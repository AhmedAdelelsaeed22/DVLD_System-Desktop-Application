using DVLD_BussinessLayer;
using DVLD_System.People;
using MaterialSkin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.L.D_License.Manage_Application.Tests
{
    public partial class FrmVisionTest : MaterialSkin.Controls.MaterialForm
    {

        private clsApplicationTestAppointment _AppointmentInfo
            = new clsApplicationTestAppointment();
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LDAppInfo;
        private clsApplication _ApplicationInfo;

        public FrmVisionTest(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private string GetCurrentUserName()
        {
            string username = "";
            using (RegistryKey key =
                Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\SOFTWARE\DVLDAPP"))
            {
                if (key != null)
                {
                    username = key.GetValue("Username", "").ToString();
                }
            }

            return username;

        }

        private void _DataLoad()
        {
            _LDAppInfo = clsLocalDrivingLicenseApplication.Find
                (_LocalDrivingLicenseApplicationID);

            if (_LDAppInfo != null) 
            {
                _ApplicationInfo = clsApplication.Find(_LDAppInfo.ApplicationID);
            }

            if (_ApplicationInfo != null) 
            {
                ctrlVisionTest1.LoadDataToControl(_ApplicationInfo , _LDAppInfo);
            }

            ctrlVisionTest1.CreatedBy = GetCurrentUserName();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails personDetails = new FrmPersonDetails
                (_ApplicationInfo.ApplicantPersonID);
            personDetails.ShowDialog();
        }

        private void FrmVisionTest_Load(object sender, EventArgs e)
        {
            ctrlVisionTest1.LinkablePersonInfo += linkLabel1_LinkClicked;
            _DataLoad();
            DataGridViewHandlerStyle();
            DataGridViewHandlerWidth();
            RecordsNumber();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvTestAppointments.Rows.Count.ToString();
        }

        private void DataGridViewHandlerWidth()
        {

            DataTable dtSourceTestAppointments = _AppointmentInfo.GetAllTestAppointments
                    (_LocalDrivingLicenseApplicationID);
            dgvTestAppointments.DataSource = dtSourceTestAppointments;

            if (dtSourceTestAppointments.Rows.Count != 0)
            {
                dgvTestAppointments.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns["TestAppointmentID"].Width = 120;

                dgvTestAppointments.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns["AppointmentDate"].Width = 150;

                dgvTestAppointments.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns["PaidFees"].Width = 130;

                dgvTestAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
                dgvTestAppointments.Columns["IsLocked"].Width = 100;
            }
        }

        private void DataGridViewHandlerStyle()
        {
            dgvTestAppointments.BorderStyle = BorderStyle.None;
            dgvTestAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTestAppointments.RowHeadersVisible = false;

            dgvTestAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTestAppointments.MultiSelect = false;
            dgvTestAppointments.ReadOnly = true;
            dgvTestAppointments.EnableHeadersVisualStyles = false;

            dgvTestAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvTestAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTestAppointments.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvTestAppointments.DefaultCellStyle.BackColor = Color.White;
            dgvTestAppointments.DefaultCellStyle.ForeColor = Color.Black;
            dgvTestAppointments.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvTestAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        private void ReloadData()
        {
            DataTable dtSourceTestAppointments = _AppointmentInfo.GetAllTestAppointments
                     (_LocalDrivingLicenseApplicationID);
            dgvTestAppointments.DataSource = dtSourceTestAppointments;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (dgvTestAppointments.Rows.Count != 0)
            {
                if (clsTests.IsPassedTest(Convert.ToInt32(dgvTestAppointments
                    .Rows[dgvTestAppointments.Rows.Count - 1].Cells[0].Value)))
                {
                    MessageBox.Show("This Person Already Passed This Test", "Erorr"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmAddNewVisionTest frmAddNewVisionTest
                    = new FrmAddNewVisionTest(2 , _LDAppInfo, _ApplicationInfo);
                    frmAddNewVisionTest.ShowDialog();
                    ReloadData();
                    RecordsNumber();
                }
            }
            else
            {
                FrmAddNewVisionTest frmAddNewVisionTest
                = new FrmAddNewVisionTest(_LDAppInfo, _ApplicationInfo);
                frmAddNewVisionTest.ShowDialog();
                ReloadData();
                RecordsNumber();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32
                (dgvTestAppointments.CurrentRow.Cells[0].Value);
            FrmAddNewVisionTest frmAddNewVisionTest
               = new FrmAddNewVisionTest
               (_LDAppInfo, _ApplicationInfo,AppointmentID);
            frmAddNewVisionTest.ShowDialog();
            ReloadData();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32
                (dgvTestAppointments.CurrentRow.Cells[0].Value);
            FrmTakeTest frmTakeTest = new FrmTakeTest 
                (AppointmentID, _LDAppInfo, _ApplicationInfo);
            frmTakeTest.ShowDialog();
            ReloadData();
        }
    }
}
