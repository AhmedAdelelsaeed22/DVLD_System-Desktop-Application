using DVLD_AccessData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_DrivingLicenseApp
{
    public class clsDrivingLicense
    {

        public static DataTable GetAllLicensesClasses()
        {
            return clsDataLayer.GetAllLicensesClasses();
        }


        public static int GetIDUsingLicenseClass(string ClassName)
        {
            return clsDataLayer.GetIDUsingLicenseClass(ClassName);
        }


        public int LocalDrivingLicenseID { get; set;}

        public int ApplicationID {get;set;}

        public int LicenseClassID { get;set;}


        private clsDrivingLicense(int LocalDrivingLicenseID , int ApplicationID , int LicenseClassID)
        {
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        public clsDrivingLicense()
        {
            this.LocalDrivingLicenseID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }

        public static clsDrivingLicense FindLocalDrivingLicenseApplications(int LocalDrivingLicenseID)
        {
            int ApplicationID = 0, LicenseClassID = 0;
            if (clsDataLayer.FindLocalDrivingLicenseApplications(LocalDrivingLicenseID , ref ApplicationID , ref LicenseClassID))
            {
                return new clsDrivingLicense(LocalDrivingLicenseID, ApplicationID, LicenseClassID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewLocalDrivingLicense()
        {
            this.LocalDrivingLicenseID = clsDataLayer.AddNewLocalDriverLicense(ApplicationID , LicenseClassID);
            return (LocalDrivingLicenseID != -1);
        }


        public bool Save()
        {
            return _AddNewLocalDrivingLicense();
        }


        public static DataTable GetAllLocalDrivingLicense()
        {
            return clsDataLayer.GetAllLocalDrivingLicense();
        }


        public static int GetDrivingLicenseCount()
        {
            return clsDataLayer.GetDrivingLicenseCount();
        }


        public static DataTable GetLocalDrivingLicenseUsingNationalNo(string NationalNo)
        {
            return clsDataLayer.GetLocalDrivingLicenseUsingNationalNo(NationalNo);
        }


        public static DataTable GetLocalDrivingLicenseUsingID(int LDAppID)
        {
            return clsDataLayer.GetLocalDrivingLicenseUsingID(LDAppID);
        }


        public static string GetClassNameUsingID(int LicenseClassID)
        {
            return clsDataLayer.GetClassNameUsingID(LicenseClassID);
        }


        public string ClassName { get; set; }


        public string NationalNo { get; set; }


        public string FullName { get; set; }


        public DateTime ApplicationDate { get; set; }


        public int PassedTestAccount {  get; set; }


        public string Status { get; set; }


        private clsDrivingLicense(int LDAppID , string ClassName , string NationalNo
            ,string FullName , DateTime ApplicationDate , int PassedTestAccount , string Status)
        {
            this.LocalDrivingLicenseID = LDAppID;
            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.ApplicationDate = ApplicationDate;
            this.PassedTestAccount = PassedTestAccount;
            this.Status = Status;
        }


        public static clsDrivingLicense GetLocalDrivingLicenseDetails(int LDAppID)
        {
            string ClassName = "", NationalNo ="", FullName = "";
            DateTime ApplicationDate = DateTime.Now;
            int PassedTestAccount = 0;
            string Status = "";
            if (clsDataLayer.GetLocalDrivingLicenseDetails(LDAppID , ref ClassName , ref NationalNo , ref FullName 
                ,ref ApplicationDate, ref PassedTestAccount , ref Status))
            {
                return new clsDrivingLicense(LDAppID , ClassName , NationalNo , FullName 
                    , ApplicationDate , PassedTestAccount , Status);
            }
            else
            {
                return null;
            }
        }


        public static bool DeleteLocalDrivingLicense(int LDAppID)
        {
            return clsDataLayer.DeleteLocalDrivingLicense(LDAppID);
        }


        public static DataTable GetAllDrivers()
        {
            return clsDataLayer.GetAllDrivers();
        }


        public static int GetCountDrivers()
        {
            return clsDataLayer.GetCountDrivers();
        }
    }
}
