using DVLD_AccessData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Appointment
{
    public class clsAppointment
    {

        public enum enMode {Add =0 , Update = 1}
        private enMode _Mode; 


        public int TestID { get; set; }

        public int LDAppID { get; set; }

        public int TestTypeID { get; set; }

        public DateTime AppointmentDate { get; set; }


        public Double PaidFees { get; set; }


        public int CreatedByUserID { get; set; }


        public bool IsLocked {  get; set; }


        public clsAppointment()
        {
            LDAppID = 0;
            TestTypeID = 1;
            AppointmentDate = DateTime.Now;
            PaidFees = 10;
            CreatedByUserID = 0;
            IsLocked = false;

            _Mode = enMode.Add;
        }


        private clsAppointment(int testID, int lDAppID, int testTypeID
            , DateTime appointmentDate, double paidFees, int createdByUserID, bool isLocked)
        {
            TestID = testID;
            LDAppID = lDAppID;
            TestTypeID = testTypeID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;

            _Mode = enMode.Update;
        }


        public static clsAppointment FindAppointMentTest(int TestID)
        {
            int LDAppID = 0, TestTypeID = 0;
            DateTime AppointmentDate = DateTime.Now;
            Double PaidFees = 0;
            int CreatedByUserID = 0;
            bool IsLocked = false;
            if (clsDataLayer.FindAppointMentTest(TestID , ref LDAppID ,ref TestTypeID 
                ,ref AppointmentDate,ref PaidFees ,ref CreatedByUserID ,ref IsLocked))
            {
                return new clsAppointment(TestID,  LDAppID,  TestTypeID
                ,  AppointmentDate,  PaidFees,  CreatedByUserID,  IsLocked);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewAppointment()
        {
            this.TestID = clsDataLayer.AddNewAppointMentTest(TestTypeID, LDAppID 
                ,AppointmentDate , PaidFees , CreatedByUserID , IsLocked);

            return (TestID != 0);
        }

        private bool _UpdateAppointment()
        {
            return clsDataLayer.UpdateAppointmentTest(TestID , TestTypeID , LDAppID ,AppointmentDate 
                ,PaidFees , CreatedByUserID , IsLocked);
        }

        public static DataTable GetAllAppointments(int LDAppID)
        {
            return clsDataLayer.GetAllAppointments(LDAppID);
        }


        public static int GetCountRecordsForAppointments(int LDAppID)
        {
            return clsDataLayer.GetCountRecordsForAppointments(LDAppID);
        }


        public static Double GetFeesForVisionTest()
        {
            return clsDataLayer.GetFeesForVisionTest();
        }


        public static bool CheckHaveVisionTest(int LDAppID)
        {
            return clsDataLayer.CheckHaveVisionTest(LDAppID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                  if (_AddNewAppointment())
                  {
                        _Mode = enMode.Update;
                        return true;
                  }
                  else
                  {
                        return false;
                  }

                  case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }


        public static string GetDateAppintmentTest(int LDAppID)
        {
            return clsDataLayer.GetDateAppintmentTest(LDAppID);
        }


        public static bool SaveLockedAppointment(int TestID)
        {
            return clsDataLayer.SaveLockedAppointment(TestID);
        }


        public static bool GetLockedForTest(int TestID)
        {
            return clsDataLayer.GetLockedForTest(TestID);
        }
    }
}
