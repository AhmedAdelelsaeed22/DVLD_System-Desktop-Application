using System;
using System.Data;
using DVLD_AccessData;



namespace DVLD_Business
{
    public class clsBusineesLayer
    {
        public enum enMode {AddMode = 0, UpdateMode = 1};
        private enMode _Mode;

        public int PersonID { get; set; }

        public string NationalNO { get; set; }

        public string FirstName { get; set; }


        public string SecondName { get; set; }


        public string ThirdName { get; set; }


        public string LastName { get; set; }


        public DateTime DateOfBirth { get; set; }


        public byte Gendor {  get; set; }


        public string Address { get; set; }
        

        public string Phone { get; set; }


        public string Email { get; set; }


        public int NationalityCountryID { get; set; }


        public string ImagePath { get; set; }


        private bool _AddNewPerson()
        {
            this.PersonID = clsDataLayer.AddNewPersonInSystem(NationalNO,FirstName, SecondName
            , ThirdName,  LastName
            , DateOfBirth,  Gendor,  Address, Phone
            , Email,  NationalityCountryID, ImagePath);

            return (PersonID != -1);
        }


        private bool _UpdatePerson()
        {
            return clsDataLayer.UpdatePersonInSystem(
                PersonID, NationalNO
                ,FirstName, SecondName, ThirdName, LastName
                ,DateOfBirth, Gendor, Address, Phone, Email,
                 NationalityCountryID, ImagePath);
        }


        private clsBusineesLayer(int PersonID
            , string NationalNO, string FirstName, string SecondName
            , string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gendor, string Address, string Phone
            , string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNO = NationalNO;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            _Mode = enMode.UpdateMode;
        }


        public clsBusineesLayer()
        {
            this.PersonID = -1;
            this.NationalNO = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = 0;
            this.ImagePath = "";

            _Mode = enMode.AddMode;
        }


        public static clsBusineesLayer FindPersonUsingPersonID(int PersonID)
        {
            string NationalNO = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsDataLayer.FindPeopleUsingPersonID(PersonID
            , ref NationalNO, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName
            , ref DateOfBirth, ref Gendor, ref Address, ref Phone
            , ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsBusineesLayer(PersonID , NationalNO 
                    , FirstName , SecondName , ThirdName , LastName 
                    , DateOfBirth , Gendor , Address , Phone , Email , 
                    NationalityCountryID , ImagePath);
            }
            else
            {
                return null;
            }
        }


        public static clsBusineesLayer FindPersonUsingNationalNo(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsDataLayer.FindPeopleUsingNationalNO(ref PersonID
            , NationalNo, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName
            , ref DateOfBirth, ref Gendor, ref Address, ref Phone
            , ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsBusineesLayer(PersonID, NationalNo
                    , FirstName, SecondName, ThirdName, LastName
                    , DateOfBirth, Gendor, Address, Phone, Email,
                    NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }


        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddMode:
                    if (_AddNewPerson())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else {  return false; }

                case enMode.UpdateMode:
                    return _UpdatePerson();
            }

            return false;
        }


        public static bool DeletePersonFromSystem(int PersonID)
        {
            return clsDataLayer.DeletePersonFromSystem(PersonID);
        }


        public static DataTable GetAllPersons()
        {
            return clsDataLayer.GetAllPersonsFromSystem();
        }

        public static DataTable GetAllCountries()
        {
            return clsDataLayer.GetAllCountries();
        }

        public static int GetCountRecords()
        {
            return clsDataLayer.GetCountRecords();
        }

    
        public static bool IsExistUsers(string UserName , string Password)
        {
            return clsDataLayer.IsExistsUser(UserName , Password);
        }
    

        public static DataTable GetAllUsers()
        {
            return clsDataLayer.GetAllUsers();
        }


        public static int GetAllRecordsForUsers()
        {
            return clsDataLayer.GetCountRecordsForUsers();
        }


        public static bool IsExistPersonInSystem(int PersonID)
        {
            return clsDataLayer.IsExistPersonInSystem(PersonID);
        }


        public static int GetPersonIDUsingNationalNo(string NationalNo)
        {
            return clsDataLayer.GetPersonIDUsingNationalNo(NationalNo);
        }
    }
}
