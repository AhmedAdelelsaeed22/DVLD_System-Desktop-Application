using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        // ---------- CONSTRUCTOR (ADD MODE) ----------
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;

            _Mode = enMode.Add;
        }


        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsLocalDrivingLicenseApplication(
            int localDrivingLicenseApplicationID,
            int applicationID,
            int licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;

            //_Mode = enMode.Update;
        }

        // ---------- FIND ----------
        public static clsLocalDrivingLicenseApplication Find(
            int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData
                .FindLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID,
                    ref ApplicationID,
                    ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID,
                    ApplicationID,
                    LicenseClassID);
            }

            return null;
        }


        // ---------- ADD ----------
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationsData.InsertNewLocalDrivingLicenseApplication(
                    ApplicationID,
                    LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    return _AddNewLocalDrivingLicenseApplication();
            }

            return false;
        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }


        public static bool IsExistClassApplicationWithStatusNew(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseApplicationsData.IsExistClassApplicationWithStatusNew(NationalNo , ClassName);
        }


        public static bool IsExistClassApplicationWithStatusCompleted(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseApplicationsData.IsExistClassApplicationWithStatusCompleted(NationalNo, ClassName);
        }


        public static string GetLocalDrivingLicenseStatus(int LocalDrivingLicenseID)
        {
            return clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseStatus(LocalDrivingLicenseID);
        }


        public static int GetPassedTestCount(int LDAppID)
        {
            return clsLocalDrivingLicenseApplicationsData.GetPassedTestCount(LDAppID);
        }

        // ---------------- GET NATIONAL NO ----------------
        public static string GetNationalNo_ByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData
                .GetNationalNo_ByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }


        // ---------------- UPDATE APPLICATION STATUS ----------------
        public static bool UpdateApplicationStatus(
        int ApplicationID,
        byte ApplicationStatus)
        {

            return clsLocalDrivingLicenseApplicationsData
                .UpdateApplicationStatus(
                ApplicationID,
                ApplicationStatus);

        }


        public static bool Delete(int LocalDrivingLicenseApplicationID)
        {

            return clsLocalDrivingLicenseApplicationsData
                .DeleteLocalDrivingLicenseApplication(
                LocalDrivingLicenseApplicationID);

        }
    }

}
