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

namespace DVLD_Controls.UserControls
{
    public partial class ctrlPersonDetails : UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }


        public string PersonID
        {
            get { return lblPersonID.Text; }
            set { lblPersonID.Text = value; }
        }

        public string FullName
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


        public string Phone
        {
            get { return lblPhone.Text; }
            set { lblPhone.Text = value; }
        }


        public string Email
        {
            get { return lblEmail.Text; }
            set { lblEmail.Text = value; }
        }


        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }


        public string CountryName
        {
            get { return lblCountry.Text; }
            set { lblCountry.Text = value; }
        }


        

        public void LoadDataToControl(clsPeople PeopleInfo)
        {
            PersonID = PeopleInfo.PersonID.ToString();
            NationalNo = PeopleInfo.NationalNo;
            FullName = PeopleInfo.FirstName + " " + PeopleInfo.SecondName
                       + " " + PeopleInfo.ThirdName + " " + PeopleInfo.LastName;
            DateOfBirth = PeopleInfo.DateOfBirth.ToString();
            Gendor = (PeopleInfo.Gendor == 1) ? "Male" : "Female";
            Address = PeopleInfo.Address;
            Phone = PeopleInfo.Phone;
            Email = PeopleInfo.Email;
            CountryName =
                clsCountries.GetCountryNameUsingCountryID(PeopleInfo.NationalityCountryID);
            if (PeopleInfo.ImagePath == null)
            {
                if (Gendor == "Male")
                
                    ImagePath = "C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/male.png";
                
                else
                
                    ImagePath = "C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/Female.png";
            }
            else
            {
                ImagePath = PeopleInfo.ImagePath;
            }
        }

        public event EventHandler<LinkLabelLinkClickedEventArgs> LinkEdit;

        private void linkLabelEditPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkEdit?.Invoke(this, e);
        }
    }
}
