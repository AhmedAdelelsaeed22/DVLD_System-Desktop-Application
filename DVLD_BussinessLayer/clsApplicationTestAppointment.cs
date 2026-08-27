using AccessDataLayer;
using System;
using System.Data;

namespace DVLD_BussinessLayer
{
    public class clsApplicationTestAppointment
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0, Update = 1 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int TestAppointmentID { get; private set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsApplicationTestAppointment(
            int testAppointmentID,
            int testTypeID,
            int localDrivingLicenseApplicationID,
            DateTime appointmentDate,
            decimal paidFees,
            int createdByUserID,
            bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;

            _Mode = enMode.Update;
        }

        // ---------- FIND ----------
        public static clsApplicationTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            decimal PaidFees = 0;
            DateTime AppointmentDate = DateTime.Now;

            if (clsApplicationTestAppointmentData.FindTestAppointment(
                TestAppointmentID,
                ref TestTypeID,
                ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate,
                ref PaidFees,
                ref CreatedByUserID,
                ref IsLocked))
            {
                return new clsApplicationTestAppointment(
                    TestAppointmentID,
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked);
            }

            return null;
        }

        // ---------- PUBLIC CONSTRUCTOR (ADD MODE) ----------
        public clsApplicationTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;

            _Mode = enMode.Add;
        }

        // ---------- ADD ----------
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID =
                clsApplicationTestAppointmentData.InsertTestAppointment(
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked);

            return (this.TestAppointmentID != -1);
        }

        // ---------- UPDATE ----------
        private bool _UpdateTestAppointment()
        {
            return clsApplicationTestAppointmentData.UpdateTestAppointment(
                TestAppointmentID,
                TestTypeID,
                LocalDrivingLicenseApplicationID,
                AppointmentDate,
                PaidFees,
                CreatedByUserID,
                IsLocked);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    return _AddNewTestAppointment();

                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

        // ---------- OTHER METHODS ----------
        public DataTable GetAllTestAppointments(int LDAppID)
        {
            return clsApplicationTestAppointmentData.GetAllTestAppointments(LDAppID);
        }

        public static bool IsExistTestAppointment(int LDAppID)
        {
            return clsApplicationTestAppointmentData.IsExistTestAppointment(LDAppID);
        }


        public static bool UpdateIsLockedTestAppointment(int TestAppointmentID)
        {
            return clsApplicationTestAppointmentData.UpdateIsLockedTestAppointment(TestAppointmentID);
        }

        public static bool IsLockedTestAppointment(int LDAppID)
        {
            return clsApplicationTestAppointmentData.IsLockedTestAppointment(LDAppID);
        }


        public DataTable GetAllWrittenTestAppointments(int LDAppID)
        {
            return clsApplicationTestAppointmentData.GetAllWrittenTestAppointments(LDAppID);
        }

        public DataTable GetAllStreetTestAppointments(int LDAppID)
        {
            return clsApplicationTestAppointmentData.GetAllStreetTestAppointments(LDAppID);
        }
    }
}
