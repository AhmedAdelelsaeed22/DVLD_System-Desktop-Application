using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;
using utilities;


namespace DVLD_Controls
{
    public partial class ctrlAddorEditPerson: UserControl
    {
        public ctrlAddorEditPerson()
        {
            InitializeComponent();
        }


        public string FirstName
        {
            get {return txtFirstName.Text;}
            set {txtFirstName.Text = value;}
        }


        public string SecondName
        {
            get { return txtSecondName.Text; }
            set { txtSecondName.Text = value; }
        }


        public string ThridName
        {
            get { return txtThridName.Text; }
            set { txtThridName.Text = value; }
        }


        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }


        public string NationalNo
        {
            get { return txtNationalNo.Text; }
            set { txtNationalNo.Text = value; }
        }


        public DateTime DateOfBirth
        {
            get { return dtpDateOfBirth.Value; }
            set { dtpDateOfBirth.Value = value; }
        }


        public string ImagePath
        {
            get { return pbImagePerson.ImageLocation; }
            set { pbImagePerson.ImageLocation = value; }
        }


        public string Gendor
        {
            get 
            {
                if (rbMale.Checked)
                {
                   
                    return "Male";
                }
                else
                {
                   
                    return "Female";
                }
            }

            set
            {
                if (Convert.ToString(value) != "0")
                {
                    rbMale.Checked = true;
                   
                }
                else
                {
                    rbFmale.Checked = true;
                   
                }
            }
        }


        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }


        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }


        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }


        public void DateOfBirthHandler()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }


        public void CustomCountriesHandler()
        {
            customCountries1.LoadDataCountries();
            customCountries1.SelectElementOne();
        }

        private Byte GendorHandler()
        {
            if (Gendor == "Male")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void LoadDataToObject(clsPeople PeopleInfo)
        {
            PeopleInfo.NationalNo = NationalNo;
            PeopleInfo.FirstName =  FirstName;
            PeopleInfo.SecondName = SecondName;
            PeopleInfo.ThirdName = ThridName;
            PeopleInfo.LastName = LastName;
            PeopleInfo.DateOfBirth = DateOfBirth;
            PeopleInfo.Gendor = GendorHandler();
            PeopleInfo.Address = Address;
            PeopleInfo.Phone = Phone;
            PeopleInfo.Email = Email;
            PeopleInfo.NationalityCountryID = 
                clsCountries.GetCountryIdUsingCountryName(customCountries1.Text);
            PeopleInfo.ImagePath = ImagePath;
        }


        public void LoadDataToControl(clsPeople PeopleInfo)
        {
            NationalNo = PeopleInfo.NationalNo;
            FirstName = PeopleInfo.FirstName;
            SecondName = PeopleInfo.SecondName;
            ThridName = PeopleInfo.ThirdName;
            LastName = PeopleInfo.LastName;
            DateOfBirth = PeopleInfo.DateOfBirth;
            Gendor = PeopleInfo.Gendor.ToString();
            Address = PeopleInfo.Address;
            Phone = PeopleInfo.Phone;
            Email = PeopleInfo.Email;
            customCountries1.Text = 
                clsCountries.GetCountryNameUsingCountryID(PeopleInfo.NationalityCountryID);
            ImagePath = PeopleInfo.ImagePath;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbImagePerson.Image = Image.FromFile("C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/male.png");
            }
            else
            {
                pbImagePerson.Image = Image.FromFile("C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/Female.png");
            }
        }


        public event EventHandler SaveChanges; 
        public event EventHandler CloseForm;
        public event EventHandler SetImage;
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm.Invoke(this, e);
        }

        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetImage.Invoke(this, e);
        }

        private void linkLabelRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImagePath = null;
            pbImagePerson.Image = Image.FromFile("C:/Users/NV/Desktop/DVLD_System/DVLD System/Images/male.png");
            LinkableVisibleRemoveImage();
        }

        private void FirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                errorProviderFirstName.SetError(txtFirstName, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProviderFirstName.SetError(txtFirstName, "");
            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(SecondName))
            {
                errorProviderSecondName.SetError(txtSecondName, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProviderSecondName.SetError(txtSecondName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LastName))
            {
                errorProviderLastName.SetError(txtLastName, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProviderLastName.SetError(txtLastName, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(NationalNo) || 
                clsPeople.IsNationalNoExists(NationalNo))
            {
                errorProviderNationalNo.SetError(txtNationalNo, 
                    "The NationalNo Is empty or already exist!");
                e.Cancel = true;
            }
            else
            {
                errorProviderNationalNo.SetError(txtNationalNo, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Phone))
            {
                errorProviderPhone.SetError(txtPhone, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProviderPhone.SetError(txtPhone, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsUtilities.IsValidEmail(Email))
            {
                errorProviderEmail.SetError(txtEmail, "This Email Is not Valid");
                e.Cancel = true;
            }
            else
            {
                errorProviderEmail.SetError(txtEmail, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Address))
            {
                errorProviderAddress.SetError(txtAddress, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProviderAddress.SetError(txtAddress, "");
            }
        }

        public void LinkableVisibleRemoveImage()
        {
            if (ImagePath != null)
            {
                linkLabelRemoveImage.Visible = true;
            }
            else
            {
                linkLabelRemoveImage.Visible = false;
            }
        }

        
    }
}
