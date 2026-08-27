using DVLD_AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsPeople
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0, Update = 1 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        // ---------- GET ALL ----------
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsPeople(
            int personID,
            string nationalNo,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            DateTime dateOfBirth,
            byte gendor,
            string address,
            string phone,
            string email,
            int nationalityCountryID,
            string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

            _Mode = enMode.Update;
        }

        // ---------- FIND ----------
        public static clsPeople FindPerson(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "",
                   ThirdName = "", LastName = "", Address = "",
                   Phone = "", Email = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1;

            if (clsPeopleData.FindPerson(
                PersonID,
                ref NationalNo,
                ref FirstName,
                ref SecondName,
                ref ThirdName,
                ref LastName,
                ref DateOfBirth,
                ref Gendor,
                ref Address,
                ref Phone,
                ref Email,
                ref NationalityCountryID,
                ref ImagePath))
            {
                return new clsPeople(
                    PersonID,
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath);
            }
            else
            {
                return null;
            }
        }


        public static clsPeople FindPersonUsingNationalNo(string NationalNo)
        {
            int PersonID = -1; string FirstName = "", SecondName = "",
                   ThirdName = "", LastName = "", Address = "",
                   Phone = "", Email = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1;

            if (clsPeopleData.FindPersonUsingNationalNo(
                NationalNo,
                ref PersonID,
                ref FirstName,
                ref SecondName,
                ref ThirdName,
                ref LastName,
                ref DateOfBirth,
                ref Gendor,
                ref Address,
                ref Phone,
                ref Email,
                ref NationalityCountryID,
                ref ImagePath))
            {
                return new clsPeople(
                    PersonID,
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath);
            }
            else
            {
                return null;
            }
        }

        // ---------- PUBLIC CONSTRUCTOR (ADD MODE) ----------
        public clsPeople()
        {
            PersonID = -1;
            NationalNo = null;
            FirstName = null;
            SecondName = null;
            ThirdName = null;
            LastName = null;
            Address = null;
            Phone = null;
            Email = null;
            ImagePath = null;
            NationalityCountryID = -1;
            DateOfBirth = DateTime.Now;
            Gendor = 0;

            _Mode = enMode.Add;
        }

        // ---------- ADD ----------
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.InsertNewPerson(
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gendor,
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath);

            return (this.PersonID != -1);
        }

        // ---------- UPDATE ----------
        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(
                PersonID,
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gendor,
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    return _AddNewPerson();

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        // ---------- DELETE ----------
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }


        public static bool IsNationalNoExists(string NationalNo)
        {
            return clsPeopleData.IsNationalNoExists(NationalNo);
        }



        public static string GetPersonFirstName(int PersonID)
        {
            return clsPeopleData.GetPersonFirstName(PersonID);
        }


    }
}
