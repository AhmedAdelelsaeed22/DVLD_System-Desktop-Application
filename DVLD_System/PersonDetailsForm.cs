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
    public partial class PersonDetailsForm : Form
    {


        int _PersonID = -1;
        clsBusineesLayer _PersonDetails;


        public PersonDetailsForm(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }


        private string _FullName(string FirstName , string Secondname)
        {
            return FirstName + " " + Secondname;
        }


        private void _DataLoad()
        {

            _PersonDetails = clsBusineesLayer.FindPersonUsingPersonID(_PersonID);


            if (_PersonDetails != null)
            {
                ctrlPersonDetails1.PersonID = _PersonDetails.PersonID.ToString();
                ctrlPersonDetails1.NationalNo = _PersonDetails.NationalNO;
                ctrlPersonDetails1.FullName = _FullName(_PersonDetails.FirstName 
                    , _PersonDetails.SecondName);
                ctrlPersonDetails1.DateOfBirth = _PersonDetails.DateOfBirth.ToLongDateString();
                ctrlPersonDetails1.Gendor = _PersonDetails.Gendor.ToString();

                ctrlPersonDetails1.Phone = _PersonDetails.Phone;
                ctrlPersonDetails1.Email = _PersonDetails.Email;
                ctrlPersonDetails1.Address = _PersonDetails.Address;
                ctrlPersonDetails1.CountryName = clsCountries.FindCountryUsingID(_PersonDetails.NationalityCountryID).CountryName;
                ctrlPersonDetails1.ImagePath = _PersonDetails.ImagePath;
            }
            else
            {
                MessageBox.Show("This Form will close because data is not found"
                    , "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void _ShowEditScreen(object sender, EventArgs e)
        {
            PersonInfo Edit = new PersonInfo(_PersonID);
            Edit.ShowDialog();
        }

        private void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            _DataLoad();
            ctrlPersonDetails1.ShowEditForm += _ShowEditScreen;
        }
    }
}
