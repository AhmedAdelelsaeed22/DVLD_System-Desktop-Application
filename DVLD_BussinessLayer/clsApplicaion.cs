using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsApplication
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int ApplicationID { get; private set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        // ---------- CONSTRUCTOR (ADD MODE) ----------
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now.AddYears(3);
            PaidFees = 0;
            CreatedByUserID = -1;

            _Mode = enMode.Add;
        }


        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsApplication(
            int applicationID,
            int applicantPersonID,
            DateTime applicationDate,
            int applicationTypeID,
            byte applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            //_Mode = enMode.Update;
        }

        // ---------- FIND ----------
        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            int ApplicationTypeID = -1;
            int CreatedByUserID = -1;
            byte ApplicationStatus = 0;
            decimal PaidFees = 0;

            DateTime ApplicationDate = DateTime.Now;
            DateTime LastStatusDate = DateTime.Now;

            if (clsApplicationsData.FindApplication(
                ApplicationID,
                ref ApplicantPersonID,
                ref ApplicationDate,
                ref ApplicationTypeID,
                ref ApplicationStatus,
                ref LastStatusDate,
                ref PaidFees,
                ref CreatedByUserID))
            {
                return new clsApplication(
                    ApplicationID,
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationTypeID,
                    ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID);
            }

            return null;
        }

        // ---------- ADD ----------
        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.InsertNewApplication(
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    return _AddNewApplication();
            }

            return false;
        }

        public static bool CancelPersonApplication(int ApplicationID)
        {
            return clsApplicationsData.CancelPersonApplication(ApplicationID);
        }


        public static int GetApplicationIDUsingLDAppID(int LocalDrivingLicenseID)
        {
            return clsApplicationsData.GetApplicationIDUsingLDAppID(LocalDrivingLicenseID);
        }


        // ---------------- DELETE APPLICATION ----------------
        public static bool Delete(int ApplicationID)
        {

            return clsApplicationsData
                .DeleteApplication(ApplicationID);

        }
    }

}
