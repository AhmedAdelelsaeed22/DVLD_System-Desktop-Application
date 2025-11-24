using DVLD_ApplicationNumberTwo;
using DVLD_Appointment;
using DVLD_DrivingLicenseApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_System
{
    public partial class SechduleTest : Form
    {

        int _LDAppID = 0;
        int _TestID = 0;
        string _ResultTest = "";

        clsDrivingLicense _DrivingLicenseInfo;
        clsApplication2 _AppInfo;
        string UserName = "";

        public enum enMode { Add = 0 ,Update = 1}
        private enMode _Mode;

        public SechduleTest(int LDAppID , string ResultTest)
        {
            InitializeComponent();
            _LDAppID = LDAppID;
            _ResultTest = ResultTest;
            _Mode = enMode.Add;
        }



        public SechduleTest(int LDAppID , int TestID , string ResultTest)
        {
            InitializeComponent();
            _LDAppID = LDAppID;
            _TestID = TestID;
            _ResultTest = ResultTest;
            _Mode = enMode.Update;
        }

        private void _CheckIsLocked(int TestID)
        {
            if (clsAppointment.GetLockedForTest(TestID))
            {
               dateTimePicker1.Enabled = false;
               btnSave.Enabled = false;
            }
        }


        private void _RetakeTest()
        {
            if (_ResultTest == "Fail")
            {
                gbRetake.Enabled = true;
                lblAppFees.Text = "5";
                lblTotalFees.Text = "15";
            }
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


            _RetakeTest();


            if (_Mode == enMode.Update)
            {
                clsAppointment appointment = clsAppointment.FindAppointMentTest(_TestID);
                dateTimePicker1.Value = appointment.AppointmentDate;
                lblAppIdVal.Text = _DrivingLicenseInfo.LocalDrivingLicenseID.ToString(); ;
                lblClass.Text = clsDrivingLicense.GetClassNameUsingID(_DrivingLicenseInfo.LicenseClassID);
                lblName.Text = clsApplication2.GetPersonNameForApplication(_AppInfo.ApplicationPersonID);
                lblFees.Text = clsAppointment.GetFeesForVisionTest().ToString();
                _RetakeTest();
                lblTestID.Text = _TestID.ToString();
            }
        }

        private void SechduleTest_Load(object sender, EventArgs e)
        {
            _CheckIsLocked(_TestID);
            _DataLoad();
            _UserCreated();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string _UserCreated()
        {
            string path = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo\login_log.txt";
            


            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] parts = content.Split('|');
                UserName = parts[0].Trim();
            }

            return UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                clsAppointment appointment = new clsAppointment();
                appointment.LDAppID = Convert.ToInt32(lblAppIdVal.Text);
                appointment.CreatedByUserID = clsApplication2.GetIDUserUsingLogIn(UserName);
                appointment.AppointmentDate = dateTimePicker1.Value;
                if (appointment.Save())
                {
                    MessageBox.Show("Save Is Successfully", "Successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (_Mode == enMode.Update)
            {
                clsAppointment appointment = clsAppointment.FindAppointMentTest(_TestID);
                appointment.LDAppID = Convert.ToInt32(lblAppIdVal.Text);
                appointment.CreatedByUserID = clsApplication2.GetIDUserUsingLogIn(UserName);
                appointment.TestTypeID = 1;
                appointment.AppointmentDate = dateTimePicker1.Value;
                if (appointment.Save())
                {
                    MessageBox.Show("Save Is Successfully", "Successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
