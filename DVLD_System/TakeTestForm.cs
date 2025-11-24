using DVLD_ApplicationNumberTwo;
using DVLD_Appointment;
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
    public partial class TakeTestForm : Form
    {

        clsDrivingLicense _DrivingLicenseInfo;
        clsApplication2 _AppInfo;
        int _LDAppID;
        int _TestID;

        string ResultTest = "";

        public event Action<string> TestDone;

        public TakeTestForm(int LDAppID , int TestID)
        {
            InitializeComponent();
            _LDAppID = LDAppID;
            _TestID = TestID;
        }


        private void _DataLoad()
        {
            _DrivingLicenseInfo = clsDrivingLicense.FindLocalDrivingLicenseApplications(_LDAppID);

            if (_DrivingLicenseInfo != null)
            {
                lblAppIdVal.Text = _DrivingLicenseInfo.LocalDrivingLicenseID.ToString();
                lblClass.Text = clsDrivingLicense.GetClassNameUsingID(_DrivingLicenseInfo.LicenseClassID);
            }

            _AppInfo = clsApplication2.FindApplicationUsingID(_DrivingLicenseInfo.ApplicationID);

            if (_AppInfo != null)
            {
                lblName.Text = clsApplication2.GetPersonNameForApplication(_AppInfo.ApplicationPersonID);
            }

            lblFees.Text = clsAppointment.GetFeesForVisionTest().ToString();
            lblDate.Text = clsAppointment.GetDateAppintmentTest(_LDAppID);
        }


            

        private void TakeTestForm_Load(object sender, EventArgs e)
        {
            _DataLoad();
            rbPass.Checked = false;
            rbFail.Checked = false;
        }

        private void clsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clsSave_Click(object sender, EventArgs e)
        {
            if (clsAppointment.SaveLockedAppointment(_TestID))
            {
                MessageBox.Show("Save Is Successfully" , "Successfully" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save Is Successfully", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPass_CheckedChanged(object sender, EventArgs e)
        {
            ResultTest = "Pass";
            TestDone?.Invoke(ResultTest);
        }

        private void rbFail_CheckedChanged(object sender, EventArgs e)
        {
            ResultTest = "Fail";
            TestDone?.Invoke(ResultTest);
        }
    }
}
