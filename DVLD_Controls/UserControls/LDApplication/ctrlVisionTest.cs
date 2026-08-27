using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Controls.UserControls.LDApplication
{
    public partial class ctrlVisionTest : UserControl
    {
        public ctrlVisionTest()
        {
            InitializeComponent();
        }


        public string LDAppID
        {
            get {return lblLDAppID.Text;}
            set {lblLDAppID.Text = value;}
        }


        public string ClassName
        {
            get {return lblClassName.Text;}
            set {lblClassName.Text = value;}
        }


        public string PassedTest
        {
            get {  return lblPassedTest.Text;}
            set {lblPassedTest.Text = value;}
        }

        public string ApplicationID
        {
            get { return lblApplicationID.Text;}
            set {lblApplicationID.Text = value;}
        }


        public string Status
        {
            get { return lblStatus.Text;}
            set {lblStatus.Text = value;}
        }


        public string Fees
        {
            get { return lblFees.Text; }
            set { lblFees.Text = value; }
        }


        public string Type
        {
            get { return lblType.Text; }
            set { lblType.Text = value; }
        }


        public string Applicant
        {
            get { return lblApplicant.Text;}
            set {lblApplicant.Text = value;}
        }


        public string Date
        {
            get {return lblAppDate.Text;}
            set {lblAppDate.Text = value; }
        }


        public string LastDate
        {
            get { return lblLastDate.Text; }
            set { lblLastDate.Text = value; }
        }


        public string CreatedBy
        {
            get { return lblCreatedBy.Text; }
            set { lblCreatedBy.Text = value; }
        }


        public void LoadDataToControl(clsApplication ApplicationInfo 
            ,clsLocalDrivingLicenseApplication LDAppInfo)
        {
            LDAppID = LDAppInfo.LocalDrivingLicenseApplicationID.ToString();
            ClassName = clsLicenseClass.GetLicenseClassName(LDAppInfo.LicenseClassID);
            PassedTest = "0/3";
            ApplicationID = ApplicationInfo.ApplicationID.ToString();
            Status = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseStatus(LDAppInfo.LocalDrivingLicenseApplicationID);
            Fees = clsApplicationType.GetApplicationFees(ApplicationInfo.ApplicationTypeID).ToString();
            Type = clsApplicationType.GetApplicationTypeTitle(ApplicationInfo.ApplicationTypeID);
            Applicant = clsPeople.GetPersonFirstName(ApplicationInfo.ApplicantPersonID);
            Date = ApplicationInfo.ApplicationDate.ToString();
            LastDate = ApplicationInfo.LastStatusDate.ToString();
        }


        public event EventHandler<LinkLabelLinkClickedEventArgs> LinkablePersonInfo;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkablePersonInfo.Invoke(this , e);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
