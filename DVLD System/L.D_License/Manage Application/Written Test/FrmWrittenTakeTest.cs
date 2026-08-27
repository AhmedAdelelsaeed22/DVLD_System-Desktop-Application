using DVLD_BussinessLayer;
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

namespace DVLD_System.L.D_License.Manage_Application.Written_Test
{
    public partial class FrmWrittenTakeTest : MaterialSkin.Controls.MaterialForm
    {

        private int _TestAppointmentID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseAppInfo;
        private clsApplication _ApplicationInfo;
        private clsApplicationTestAppointment _AppointmentInfo;
        private clsTests _TestInfo;

        public FrmWrittenTakeTest(int TestAppointmentID
            , clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo
            , clsApplication ApplicationInfo)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseAppInfo = LocalDrivingLicenseAppInfo;
            _ApplicationInfo = ApplicationInfo;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void _LoadDataToControl(clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo
          , clsApplication ApplicationInfo)
        {
            lblLDAppID.Text = LocalDrivingLicenseAppInfo.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = clsLicenseClass.GetLicenseClassName(LocalDrivingLicenseAppInfo.LicenseClassID);
            lblName.Text = clsPeople.GetPersonFirstName(ApplicationInfo.ApplicantPersonID);
            lblFees.Text = clsApplicationTestType.GetApplicationTestTypeFees(2).ToString();

            _AppointmentInfo = clsApplicationTestAppointment.Find(_TestAppointmentID);

            if (_AppointmentInfo != null)
            {
                lblDate.Text = _AppointmentInfo.AppointmentDate.ToString();
            }
        }

        private void FrmWrittenTakeTest_Load(object sender, EventArgs e)
        {
            _LoadDataToControl(_LocalDrivingLicenseAppInfo, _ApplicationInfo);
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


        private bool HandleTestResult()
        {
            if (rbPass.Checked)
                return true;
            else
                return false;
        }

        private void _LoadDataToObject(clsTests TestInfo)
        {
            TestInfo.TestAppointmentID = _TestAppointmentID;
            TestInfo.TestResult = HandleTestResult();
            TestInfo.Notes = txtNote.Text;
            TestInfo.CreatedByUserID = clsUsers.GetUserIDUsingUserName
                (GetCurrentUserName());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestInfo = new clsTests();
            _LoadDataToObject(_TestInfo);
            if (_TestInfo.Save())
            {
                MessageBox.Show("Save Is Successfully", "Successfully"
                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTestID.Text = _TestInfo.TestID.ToString();
                clsApplicationTestAppointment.UpdateIsLockedTestAppointment
                    (_TestAppointmentID);
            }
            else
            {
                MessageBox.Show("Save Is Not Successfully", "Error"
                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
