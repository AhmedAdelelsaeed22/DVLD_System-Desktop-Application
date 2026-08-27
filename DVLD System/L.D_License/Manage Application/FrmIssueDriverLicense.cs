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

namespace DVLD_System.L.D_License.Manage_Application
{
    public partial class FrmIssueDriverLicense : MaterialSkin.Controls.MaterialForm
    {

        private clsDrivers _DriverInfo;
        private clsLicense _LicenseInfo;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LDAppInfo;
        private clsApplication _ApplicationInfo;

        public FrmIssueDriverLicense(int LocalDrivingLicenseApplicationID)
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
                ctrlVisionTest1.LoadDataToControl(_ApplicationInfo, _LDAppInfo);
            }

            ctrlVisionTest1.CreatedBy = GetCurrentUserName();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails personDetails = new FrmPersonDetails
                (_ApplicationInfo.ApplicantPersonID);
            personDetails.ShowDialog();
        }

        private void FrmIssueDriverLicense_Load(object sender, EventArgs e)
        {
            ctrlVisionTest1.LinkablePersonInfo += linkLabel1_LinkClicked;
            _DataLoad();
        }

        private void LoadDataDriverAndSave(clsDrivers DriverInfo)
        {
            DriverInfo.PersonID = _ApplicationInfo.ApplicantPersonID;
            DriverInfo.CreatedByUserID = _ApplicationInfo.CreatedByUserID;
            DriverInfo.CreatedDate = DateTime.Now;

            DriverInfo.Save();
        }

        private byte GetExpirtedDate()
        {
            return clsLicenseClass.GetDefaultValidityLength(_LDAppInfo.LicenseClassID);
        }

        private void LoadLicenseData(clsLicense LicenseInfo)
        {
            LicenseInfo.ApplicationID = _LDAppInfo.ApplicationID;
            LicenseInfo.DriverID = _DriverInfo.DriverID;
            LicenseInfo.LicenseClass = _LDAppInfo.LicenseClassID;
            LicenseInfo.IssueDate = DateTime.Now;
            LicenseInfo.ExpirationDate = DateTime.Now.AddYears(GetExpirtedDate());
            LicenseInfo.Notes = txtNote.Text;
            LicenseInfo.PaidFees = Convert.ToDecimal(0.00);
            LicenseInfo.IsActive = true;
            LicenseInfo.IssueReason = 1;
            LicenseInfo.CreatedByUserID = _ApplicationInfo.CreatedByUserID;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _DriverInfo = new clsDrivers();
            LoadDataDriverAndSave(_DriverInfo);
            _LicenseInfo = new clsLicense();
            LoadLicenseData(_LicenseInfo);

            if (_LicenseInfo.Save())
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
