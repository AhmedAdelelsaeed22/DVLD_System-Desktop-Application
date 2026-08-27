using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int LicenseID { get; set; }

        public int ApplicationID { get; set; }

        public int DriverID { get; set; }

        public int LicenseClass { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public byte IssueReason { get; set; }

        public int CreatedByUserID { get; set; }


        // Default Constructor

        public clsLicense()
        {

            this.LicenseID = -1;

            this.ApplicationID = -1;

            this.DriverID = -1;

            this.LicenseClass = -1;

            this.IssueDate = DateTime.Now;

            this.ExpirationDate = DateTime.Now;

            this.Notes = "";

            this.PaidFees = 0;

            this.IsActive = true;

            this.IssueReason = 0;

            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        private clsLicense(
            int LicenseID,
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            decimal PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {

            this.LicenseID = LicenseID;

            this.ApplicationID = ApplicationID;

            this.DriverID = DriverID;

            this.LicenseClass = LicenseClass;

            this.IssueDate = IssueDate;

            this.ExpirationDate = ExpirationDate;

            this.Notes = Notes;

            this.PaidFees = PaidFees;

            this.IsActive = IsActive;

            this.IssueReason = IssueReason;

            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;

        }


        private bool _AddNewLicense()
        {

            this.LicenseID =
            clsLicenseData.InsertLicense(

                this.ApplicationID,
                this.DriverID,
                this.LicenseClass,
                this.IssueDate,
                this.ExpirationDate,
                this.Notes,
                this.PaidFees,
                this.IsActive,
                this.IssueReason,
                this.CreatedByUserID
            );

            return (this.LicenseID != -1);

        }


        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewLicense())
                    {
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:

                    return false;

            }

            return false;

        }


        public static clsLicense Find(int LicenseID)
        {

            int ApplicationID = -1;

            int DriverID = -1;

            int LicenseClass = -1;

            DateTime IssueDate = DateTime.Now;

            DateTime ExpirationDate = DateTime.Now;

            string Notes = "";

            decimal PaidFees = 0;

            bool IsActive = false;

            byte IssueReason = 0;

            int CreatedByUserID = -1;



            if (clsLicenseData.FindLicenseByID(

                LicenseID,
                ref ApplicationID,
                ref DriverID,
                ref LicenseClass,
                ref IssueDate,
                ref ExpirationDate,
                ref Notes,
                ref PaidFees,
                ref IsActive,
                ref IssueReason,
                ref CreatedByUserID
                ))

            {

                return new clsLicense(

                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason,
                    CreatedByUserID

                    );

            }

            else

                return null;

        }



        // ---------------- FIND LICENSE BY APPLICATION ID ----------------
        public static clsLicense FindByApplicationID(int ApplicationID)
        {

            int LicenseID = -1;

            int DriverID = -1;

            int LicenseClass = -1;

            DateTime IssueDate = DateTime.Now;

            DateTime ExpirationDate = DateTime.Now;

            string Notes = "";

            decimal PaidFees = 0;

            bool IsActive = false;

            byte IssueReason = 0;

            int CreatedByUserID = -1;



            if (clsLicenseData.FindLicenseByApplicationID(

                ApplicationID,
                ref LicenseID,
                ref DriverID,
                ref LicenseClass,
                ref IssueDate,
                ref ExpirationDate,
                ref Notes,
                ref PaidFees,
                ref IsActive,
                ref IssueReason,
                ref CreatedByUserID
                ))

            {

                return new clsLicense(

                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason,
                    CreatedByUserID

                    );

            }

            else

                return null;

        }

        // ---------------- IS LICENSE EXISTS BY APPLICATION ID ----------------
        public static bool IsLicenseExists_ByApplicationID(int ApplicationID)
        {
            return clsLicenseData.IsLicenseExists_ByApplicationID(ApplicationID);
        }



        // ---------------- GET LICENSES BY APPLICATION ID ----------------
        public static DataTable GetLicensesByApplicationID(
        int ApplicationID)
        {

            return clsLicenseData
                .GetLicenses_ByApplicationID(
                ApplicationID);

        }
    }
}
