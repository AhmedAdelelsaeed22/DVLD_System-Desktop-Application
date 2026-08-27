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
    public partial class ctrlShowLicense : UserControl
    {
        public ctrlShowLicense()
        {
            InitializeComponent();
        }

        public string LicenseID
        {
            get { return lblLicenseID.Text; }
            set { lblLicenseID.Text = value; }
        }

        public string FName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }


        public string NationalNo
        {
            get { return lblNationalNo.Text; }
            set { lblNationalNo.Text = value; }
        }


        public string DateOfBirth
        {
            get { return lblDateOfBirth.Text; }
            set { lblDateOfBirth.Text = value; }
        }


        public string IssueDate
        {
            get { return lblIssueDate.Text; }
            set { lblIssueDate.Text = value; }
        }

        public string ExpirationDate
        {
            get { return lblExpirationDate.Text; }
            set { lblExpirationDate.Text = value; }
        }


        public string DriverID
        {
            get { return lblDriverID.Text; }
            set { lblDriverID.Text = value; }
        }

        public string ImagePath
        {
            get { return pbImagePerson.ImageLocation; }
            set { pbImagePerson.ImageLocation = value; }
        }


        public string Gendor
        {
            get { return lblGendor.Text; }
            set { lblGendor.Text = value; }
        }


        public string ClassName
        {
            get { return lblClass.Text; }
            set { lblClass.Text = value; }
        }


        public string IsActive
        {
            get { return lblIsActive.Text; }
            set { lblIsActive.Text = value; }
        }


        public string IssueResons
        {
            get { return lblIssueresons.Text; }
            set { lblIssueresons.Text = value; }
        }


        public string IsDetained
        {
            get { return lblIsDetained.Text; }
            set { lblIsDetained.Text = value; }
        }



        public void LoadDataToControle(clsPeople PersonInfo
            , clsLocalDrivingLicenseApplication LDAppInfo,
            clsLicense LicenseInfo)
        {
            ClassName = clsLicenseClass.GetLicenseClassName(LDAppInfo.LicenseClassID);
            FName = PersonInfo.FirstName + " " 
                + PersonInfo.SecondName + " " 
                + PersonInfo.ThirdName + " " 
                + PersonInfo.LastName;
            NationalNo = PersonInfo.NationalNo;
            LicenseID = LicenseInfo.LicenseID.ToString();
            Gendor = (PersonInfo.Gendor == 1) ? "Male" : "Female";
            IsActive = (LicenseInfo.IsActive) ? "Yes" : "No";
            DateOfBirth = PersonInfo.DateOfBirth.ToString();
            IssueDate = LicenseInfo.IssueDate.ToString();
            DriverID = LicenseInfo.DriverID.ToString();
            ExpirationDate = LicenseInfo.ExpirationDate.ToString();
            IssueResons = (LicenseInfo.IssueReason == 1) ? "FirstTime" : "SecondTime";
            if (PersonInfo.ImagePath == null)
            {
                if (Gendor == "Male")

                    ImagePath = "C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/male.png";

                else

                    ImagePath = "C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/Female.png";
            }
            else
            {
                ImagePath = PersonInfo.ImagePath;
            }
        }
    }
}
