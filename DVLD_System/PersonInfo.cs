using DVLD_Business;
using DVLD_Countries;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_System
{
    public partial class PersonInfo : Form
    {

        public event Action<int> DataReturned;

        public enum enMode {Add = 0 , Update = 1};
        private enMode _Mode;

        int _PersonID;
        clsBusineesLayer _Person;


        public PersonInfo(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if(_PersonID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;
        }


        private void _FillCountriesInComboBox()
        {
            DataTable Countries = clsBusineesLayer.GetAllCountries();

            foreach (DataRow row in Countries.Rows)
            {
                ctrlAddOrEditNewCard1.AddInComboBox(row["CountryName"]);
            }
        }


        private void _DataLoad()
        {
            _FillCountriesInComboBox();
            ctrlAddOrEditNewCard1.CountryNameIndex = 50;

            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsBusineesLayer();
                return;
            }


            _Person = clsBusineesLayer.FindPersonUsingPersonID(_PersonID);


            if (_Person != null)
            {
                lblIDNumber.Text = _Person.PersonID.ToString();
                ctrlAddOrEditNewCard1.FirstName = _Person.FirstName;
                ctrlAddOrEditNewCard1.SecondName = _Person.SecondName;
                ctrlAddOrEditNewCard1.ThirdName = _Person.ThirdName;
                ctrlAddOrEditNewCard1.LastName = _Person.LastName;
                ctrlAddOrEditNewCard1.NationalNo = _Person.NationalNO;
                ctrlAddOrEditNewCard1.DateOfBirth = _Person.DateOfBirth;
                ctrlAddOrEditNewCard1.Gendor = _Person.Gendor;

                ctrlAddOrEditNewCard1.Phone = _Person.Phone;
                ctrlAddOrEditNewCard1.Email = _Person.Email;
                ctrlAddOrEditNewCard1.Address = _Person.Address;
                ctrlAddOrEditNewCard1.CountryNameIndex = ctrlAddOrEditNewCard1.SearchInComboBox(clsCountries.FindCountryUsingID(_Person.NationalityCountryID).CountryName);
                ctrlAddOrEditNewCard1.ImagePath = _Person.ImagePath;
            }
            else
            {
                MessageBox.Show("This Form will close because data is not found"
                    , "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }


        private void _SaveClicked(object sender, EventArgs e)
        {
            int Country_ID = clsCountries.FindCountryUsingName(ctrlAddOrEditNewCard1.CountryNameString()).CountryID;
            _Person.FirstName =  ctrlAddOrEditNewCard1.FirstName;
            _Person.SecondName = ctrlAddOrEditNewCard1.SecondName;
            _Person.ThirdName =  ctrlAddOrEditNewCard1.ThirdName;
            _Person.LastName =   ctrlAddOrEditNewCard1.LastName;
            _Person.NationalNO = ctrlAddOrEditNewCard1.NationalNo;
            _Person.DateOfBirth = ctrlAddOrEditNewCard1.DateOfBirth;
            _Person.Gendor =      ctrlAddOrEditNewCard1.Gendor;
            _Person.Email =       ctrlAddOrEditNewCard1.Email;
            _Person.Phone =       ctrlAddOrEditNewCard1.Phone;
            _Person.NationalityCountryID = Country_ID;
            _Person.ImagePath = ctrlAddOrEditNewCard1.ImagePath;
            _Person.Address = ctrlAddOrEditNewCard1.Address;

            if (_Person.Save())
            {
                MessageBox.Show("Saved Is Successfully" , "Successfully" 
                    , MessageBoxButtons.OK , MessageBoxIcon.Information);
                if (ctrlAddOrEditNewCard1.ImagePath != null)
                {
                    string originalPath = ctrlAddOrEditNewCard1.ImagePath;

                    string folderPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "PersonImages");


                    if (!Directory.Exists(folderPath)) 
                    {
                        Directory.CreateDirectory(folderPath);
                    }


                    string extention = Path.GetExtension(originalPath);
                    string newFileName = Guid.NewGuid().ToString() + extention;

                    string newPath = Path.Combine(folderPath, newFileName);

                    File.Copy(originalPath , newPath , true);


                    MessageBox.Show("Your Picture Is Save", "Successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your Picture Is Not Found", "Warning"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Saved Is Not Successfully");
            }

            lblTitle.Text = "Edit Person Screen";
            lblIDNumber.Text = _Person.PersonID.ToString();
            DataReturned?.Invoke(_Person.PersonID);
        }


        private void PersonInfo_Load(object sender, EventArgs e)
        {
            _DataLoad();
            ctrlAddOrEditNewCard1.SaveClicked += _SaveClicked;
        }

        
    }
}
