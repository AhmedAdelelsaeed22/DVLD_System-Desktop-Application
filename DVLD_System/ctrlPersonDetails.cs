using DVLD_Countries;
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
    public partial class ctrlPersonDetails : UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }


        public string PersonID
        {
            get { return lblIdValue.Text; }
            set { lblIdValue.Text = value; }
        }

        public string FullName
        {
            get { return lblNameValue.Text; }
            set { lblNameValue.Text = value; }
        }


        public string NationalNo
        {
            get { return lblNationalValue.Text; }
            set { lblNationalValue.Text = value; }
        }


        public string DateOfBirth
        {
            get { return lblDateOfBirthVakue.Text; }
            set { lblDateOfBirthVakue.Text = value; }
        }


        public string Gendor
        {
            get {return lblGendorValue.Text;}

            set
            {
                if (value == "0")
                    lblGendorValue.Text = "Male";
                else
                    lblGendorValue.Text = "Female";
            }
        }


        public string CountryName
        {
            get {return lblCountryValue.Text;}
            set { lblCountryValue.Text = value; }
        }


        public string Email
        {
            get { return lblEmailValue.Text; }
            set { lblEmailValue.Text = value; }
        }


        public string Phone
        {
            get { return lblPhoneValue.Text; }
            set { lblPhoneValue.Text = value; }
        }


        public string Address
        {
            get { return lblAddressValue.Text; }
            set { lblAddressValue.Text = value; }
        }

        public string ImagePath
        {
            get { return pbImage.ImageLocation; }
            set { pbImage.ImageLocation = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form Parent = this.FindForm();
            if(Parent != null)
            {
                Parent.Close();
            }
        }


        public event EventHandler ShowEditForm;

        private void lblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            ShowEditForm?.Invoke(this, EventArgs.Empty);
        }
    }
}
