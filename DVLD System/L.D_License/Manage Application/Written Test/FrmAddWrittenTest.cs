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
    public partial class FrmAddWrittenTest : MaterialSkin.Controls.MaterialForm
    {

        enum enMode { Add = 0, Update = 1, Retake = 2 }
        private enMode _Mode;

        private int _AppointmentID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseAppInfo;
        private clsApplication _ApplicationInfo;
        private clsApplicationTestAppointment _AppointmentInfo;


        public FrmAddWrittenTest(clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo, clsApplication ApplicationInfo)
        {
            InitializeComponent();

            _LocalDrivingLicenseAppInfo = LocalDrivingLicenseAppInfo;
            _ApplicationInfo = ApplicationInfo;
            _Mode = enMode.Add;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        public FrmAddWrittenTest(clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo
            , clsApplication ApplicationInfo
            , int AppointmentID)
        {
            InitializeComponent();

            _LocalDrivingLicenseAppInfo = LocalDrivingLicenseAppInfo;
            _ApplicationInfo = ApplicationInfo;
            _Mode = enMode.Update;
            _AppointmentID = AppointmentID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        public FrmAddWrittenTest(int ModeNumber, clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo,
           clsApplication ApplicationInfo)
        {
            InitializeComponent();

            _LocalDrivingLicenseAppInfo = LocalDrivingLicenseAppInfo;
            _ApplicationInfo = ApplicationInfo;

            if (ModeNumber == 2)
                _Mode = enMode.Retake;


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
        }


        private void _DataLoad()
        {
            _LoadDataToControl(_LocalDrivingLicenseAppInfo, _ApplicationInfo);
            if (_Mode == enMode.Add)
            {
                _AppointmentInfo = new clsApplicationTestAppointment();
                return;
            }

            if (_Mode == enMode.Retake)
            {
                groupBox1.Enabled = true;
                lblAppFees.Text = "5";
                decimal fees = Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblAppFees.Text);
                lblTotalFees.Text = fees.ToString();
                lblTitle.Text = "Retake Test";
                _AppointmentInfo = new clsApplicationTestAppointment();
                return;
            }

            if (clsApplicationTestAppointment.IsLockedTestAppointment
                (_LocalDrivingLicenseAppInfo.LocalDrivingLicenseApplicationID))
            {
                dateTimePicker1.Enabled = false;
                groupBox1.Enabled = true;
                btnSave.Enabled = false;
                lblMessage.Enabled = true;
            }


            _AppointmentInfo = clsApplicationTestAppointment.Find
                (_AppointmentID);

            lblTitle.Text = "Update Test";

            if (_AppointmentInfo != null)
            {
                dateTimePicker1.Value = _AppointmentInfo.AppointmentDate;
            }
        }

        private void FrmAddWrittenTest_Load(object sender, EventArgs e)
        {
            _DataLoad();
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

        private void _LoadDataToObject(clsApplicationTestAppointment AppointmentInfo,
          clsLocalDrivingLicenseApplication LocalDrivingLicenseAppInfo)
        {
            AppointmentInfo.TestTypeID = 2;
            AppointmentInfo.LocalDrivingLicenseApplicationID =
                LocalDrivingLicenseAppInfo.LocalDrivingLicenseApplicationID;
            AppointmentInfo.AppointmentDate = dateTimePicker1.Value;
            AppointmentInfo.PaidFees = Convert.ToDecimal(lblFees.Text);
            AppointmentInfo.CreatedByUserID =
                clsUsers.GetUserIDUsingUserName(GetCurrentUserName());
            AppointmentInfo.IsLocked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadDataToObject(_AppointmentInfo, _LocalDrivingLicenseAppInfo);

            if (_AppointmentInfo.Save())
            {
                MessageBox.Show("Save Is Successfully", "Successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
