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
    public partial class VisionTestAppiontMent : Form
    {


        int _LDAppID = 0;
        string ResultTest = "";

        clsDrivingLicense _DrivingLicenseInfo;
        clsApplication2 _AppInfo;

        public VisionTestAppiontMent(int LDAppID)
        {
            InitializeComponent();
            _LDAppID = LDAppID;
        }


        private void _DataLoad()
        {
            _DrivingLicenseInfo = clsDrivingLicense.FindLocalDrivingLicenseApplications(_LDAppID);

            if (_DrivingLicenseInfo != null)
            {
                ctrlApplicationInfo1.AppID = _DrivingLicenseInfo.LocalDrivingLicenseID.ToString();
                ctrlApplicationInfo1.ApplicationLicense = clsDrivingLicense.GetClassNameUsingID(_DrivingLicenseInfo.LicenseClassID);
            }


            _AppInfo = clsApplication2.FindApplicationUsingID(_DrivingLicenseInfo.ApplicationID);

            if (_AppInfo != null) 
            {
                ctrlApplicationInfo1.ID = _AppInfo.ApplicationID.ToString();

                if (_AppInfo.ApplicationStatus == 1)
                    ctrlApplicationInfo1.Status = "New";
                else if (_AppInfo.ApplicationStatus == 2)
                    ctrlApplicationInfo1.Status = "Cancelled";
                else
                    ctrlApplicationInfo1.Status = "Completed";

                ctrlApplicationInfo1.Person = clsApplication2.GetPersonNameForApplication(_AppInfo.ApplicationPersonID);
                ctrlApplicationInfo1.TypeApplication = clsApplication2.GetApplicationTitleForApplication(_AppInfo.ApplicationTypeID);
                ctrlApplicationInfo1.Fees = _AppInfo.PaidFees.ToString();
                ctrlApplicationInfo1.Date = _AppInfo.ApplicationDate.ToString();
                ctrlApplicationInfo1.StatusDate = _AppInfo.ApplicationLastDate.ToString();
                ctrlApplicationInfo1.CreatedBy = clsApplication2.GetUserNameForApplication(_AppInfo.CreatedByUserID);
            }
        }


        private void _RefreshData()
        {
            dgvAllAppointments.DataSource = clsAppointment.GetAllAppointments(_LDAppID);
        }

        private void VisionTestAppiontMent_Load(object sender, EventArgs e)
        {
            _DataLoad();
            ctrlApplicationInfo1.ShowPersonInfo += ClickPersonInfo_Linkable;
            dgvAllAppointments.DataSource = clsAppointment.GetAllAppointments(_LDAppID);
            lblrecordsVal.Text = clsAppointment.GetCountRecordsForAppointments(_LDAppID).ToString();
        }


        private void ClickPersonInfo_Linkable(object sender, EventArgs e)
        {
            PersonDetailsForm detailsForm = new PersonDetailsForm(_AppInfo.ApplicationPersonID);
            detailsForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clsAppointment.CheckHaveVisionTest(_LDAppID))
            {
                MessageBox.Show("This Person is already have an active appointment" 
                    ,"Not Allowed" ,MessageBoxButtons.OK , MessageBoxIcon.Error);
            }else if (ResultTest == "Pass")
            {
                MessageBox.Show("This Person is already pass this Test"
                   , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SechduleTest TestForm = new SechduleTest(_LDAppID , ResultTest);
                TestForm.ShowDialog();
                _RefreshData();
            }   
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SechduleTest TestForm = new SechduleTest(_LDAppID , Convert.ToInt32(dgvAllAppointments.CurrentRow.Cells[0].Value) , ResultTest);
            TestForm.ShowDialog();
            _RefreshData();
        }

        

        private void _ValueTest(string value)
        {
            ResultTest = value;
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeTestForm takeTest = new TakeTestForm(_LDAppID, Convert.ToInt32(dgvAllAppointments.CurrentRow.Cells[0].Value));
            takeTest.TestDone += _ValueTest;
            takeTest.ShowDialog();
            _RefreshData();
        }
    }
}
