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
    public partial class ShowApplicationDetails : Form
    {

        int _LDAppID = 0;
        clsDrivingLicense DrivingLicense;

        public ShowApplicationDetails(int LDAppID)
        {
            InitializeComponent();
            _LDAppID = LDAppID;
        }

        private void ShowApplicationDetails_Load(object sender, EventArgs e)
        {
            DrivingLicense = clsDrivingLicense.GetLocalDrivingLicenseDetails(_LDAppID);

            if (DrivingLicense != null)
            {
                lblAppIDVal.Text = DrivingLicense.LocalDrivingLicenseID.ToString();
                lblClassName.Text = DrivingLicense.ClassName;
                lblNationalNo.Text = DrivingLicense.NationalNo;
                lblFullName.Text = DrivingLicense.FullName;
                lblApplicationDate.Text = DrivingLicense.ApplicationDate.ToString();
                lblPassedTest.Text = DrivingLicense.PassedTestAccount.ToString();
                lblStatus.Text = DrivingLicense.Status;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
