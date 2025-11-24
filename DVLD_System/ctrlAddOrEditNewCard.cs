using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;


namespace DVLD_System
{
    public partial class ctrlAddOrEditNewCard : UserControl
    {
       
        public ctrlAddOrEditNewCard()
        {
            InitializeComponent();
        }


        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }


        public string SecondName
        {
            get { return txtSecondName.Text; }
            set { txtSecondName.Text = value; }
        }


        public string ThirdName
        {
            get { return txtThirdName.Text; }
            set { txtThirdName.Text = value; }
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
            get { return dtpBirthOfDate.Value; }
            set { dtpBirthOfDate.Value = value; }
        }


        public byte Gendor
        {
            get
            {
                if (rbMale.Checked)
                    return Convert.ToByte(rbMale.Tag);
                else
                    return Convert.ToByte(rbFmale.Tag);
            }


            set
            {
               if (value == Convert.ToByte(rbMale.Tag))
                    rbMale.Checked = true;
              else
                    rbFmale.Checked = true;
            }
        }


        public int CountryNameIndex
        {
            get { return cbCountries.SelectedIndex; }
            set { cbCountries.SelectedIndex = value; }
        }


        public void AddInComboBox(object value)
        {
            cbCountries.Items.Add(value);
        }


        public string CountryNameString()
        {
            return cbCountries.Text;
        }

        public int SearchInComboBox(string value)
        {
            return cbCountries.FindString(value);
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }


        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }


        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string ImagePath
        {
            get { return pbImage.ImageLocation; }
            set { pbImage.ImageLocation = value; }
        }



        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsBusineesLayer nationalno = clsBusineesLayer.FindPersonUsingNationalNo(txtNationalNo.Text);
            if (nationalno != null || string.IsNullOrEmpty(txtNationalNo.Text)) 
            {
               e.Cancel = true;
               errorProviderNationalNo.SetError(txtNationalNo, "This NationalNo Already Exist.");
            }
            else
            {
                errorProviderNationalNo.SetError(txtNationalNo, "");
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbImage.Image = Properties.Resources.Male;
            }
            else
            {
                pbImage.Image = Properties.Resources.Fmale;
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtPhone, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtPhone, "");
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtEmail.Text.Contains("@gmail.com"))
            {
                e.Cancel= true;
                errorProviderEmail.SetError(txtEmail, "The Email Is Not Valid");
            }
            else
            {
                errorProviderEmail.SetError(txtEmail, "");
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtFirstName, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtFirstName, "");
            }
        }

        private void txtSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtSecondName, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtSecondName, "");
            }
        }

        private void txtThirdName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtThirdName, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtThirdName, "");
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtLastName, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtLastName, "");
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(txtAddress, "This Field Is Required.");
            }
            else
            {
                errorProviderPhone.SetError(txtAddress, "");
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 

            openFileDialogSetImage.Title = "Select an Image";
            openFileDialogSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";


            if (openFileDialogSetImage.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(openFileDialogSetImage.FileName);
                pbImage.ImageLocation = openFileDialogSetImage.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();

            if(parent != null) 
                parent.Close();
        }


        public event EventHandler SaveClicked;

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
