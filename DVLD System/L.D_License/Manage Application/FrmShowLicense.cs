using DVLD_BussinessLayer;
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

namespace DVLD_System.L.D_License.Manage_Application
{
    public partial class FrmShowLicense : MaterialSkin.Controls.MaterialForm
    {

        private int _LDAppID;
        private clsLocalDrivingLicenseApplication _LDAppInfo;
        private clsApplication _ApplicationInfo;
        private clsDrivers _DriverInfo;
        private clsPeople _PersonInfo;
        private clsLicense _LicenseInfo;

        public FrmShowLicense(int LDAppID)
        {
            InitializeComponent();

            _LDAppID = LDAppID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void LoadData()
        {
            _LDAppInfo = clsLocalDrivingLicenseApplication.Find(_LDAppID);

            if (_LDAppInfo != null)
            {
                _ApplicationInfo = clsApplication.Find(_LDAppInfo.ApplicationID);
            }

            if( _ApplicationInfo != null) 
            {
                _PersonInfo = clsPeople.FindPerson(_ApplicationInfo.ApplicantPersonID);
                _LicenseInfo = clsLicense.FindByApplicationID(_LDAppInfo.ApplicationID);
            }

            if (_PersonInfo != null && _LicenseInfo != null)
            {
                ctrlShowLicense1.LoadDataToControle(_PersonInfo 
                    , _LDAppInfo , _LicenseInfo);
                ctrlShowLicense1.IsDetained = "No";
            }
        }

        private void FrmShowLicense_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
