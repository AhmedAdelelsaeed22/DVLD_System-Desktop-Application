using DVLD_Business;
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
    public partial class ctrlAddNewUser : UserControl
    {
        public ctrlAddNewUser()
        {
            InitializeComponent();
        }


        public int txtFindValueInt
        {
            get {return  Convert.ToInt32(txtFind.Text); }
            set { txtFind.Text = value.ToString(); }
        }

        public string txtFindValueNationalNo
        {
             get { return txtFind.Text; }
        }

        public int comboBoxFilteration
        {
            get { return cbFilteration.SelectedIndex; }
            set { cbFilteration.SelectedIndex = value; }
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
            get { return lblGendorValue.Text; }

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
            get { return lblCountryValue.Text; }
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


        public bool EditLink
        {
            get { return lblEditPerson.Enabled; }
            set { lblEditPerson.Enabled = value; }
        }


        public void LoadPersonInfo(clsBusineesLayer _PersonInfo)
        {
            PersonID = _PersonInfo.PersonID.ToString();
            FullName = _PersonInfo.FirstName + " " + _PersonInfo.SecondName;
            NationalNo = _PersonInfo.NationalNO.ToString();
            DateOfBirth = _PersonInfo.DateOfBirth.ToLongDateString();
            Gendor = _PersonInfo.Gendor.ToString();
            CountryName = clsCountries.FindCountryUsingID(_PersonInfo.NationalityCountryID).CountryName;
            Email = _PersonInfo.Email;
            Phone = _PersonInfo.Phone;
            Address = _PersonInfo.Address;
            ImagePath = _PersonInfo.ImagePath;
        }

        public void UnEnabled()
        {
            cbFilteration.Enabled = false;
            txtFind.Enabled = false;
            btnAddUser.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilteration.SelectedIndex == 0)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; 
                }
            }
        }


        public event EventHandler Finding;

        public event EventHandler AddNew;

        public event EventHandler Edit;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Finding?.Invoke(this, e);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddNew?.Invoke(this, e);
        }

        private void lblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Edit?.Invoke(this, e);
        }
    }
}
