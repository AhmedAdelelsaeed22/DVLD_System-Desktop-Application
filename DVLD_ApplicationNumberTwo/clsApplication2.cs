using DVLD_AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_ApplicationNumberTwo
{
    public class clsApplication2
    {
        public int ApplicationID {  get; set; }


        public int ApplicationPersonID { get; set; }



        public DateTime ApplicationDate { get; set; }


        public int ApplicationTypeID { get; set; }


        public int ApplicationStatus {  get; set; }


        public DateTime ApplicationLastDate { get; set; }


        public Double PaidFees { get; set; }


        public int CreatedByUserID { get; set; }


        public clsApplication2()
        {
            this.ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID =  1;
            this.ApplicationStatus = 1;
            this.ApplicationLastDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        private clsApplication2(int ApplicationID , int ApplicationPersonID 
            ,DateTime ApplicationDate , int AplicationTypeID , int ApplicationStatus 
            ,DateTime ApplicationLastDate , Double PadiFees , int CreatedBy)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = AplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationLastDate = ApplicationLastDate;
            this.PaidFees= PadiFees;
            this.CreatedByUserID = CreatedBy;
        }


        public static clsApplication2 FindApplicationUsingID(int ApplicationID)
        {
            int ApplicationPersonID = 0;
            DateTime ApplicationDate = DateTime.Now, ApplicationLastDate = DateTime.Now;
            int ApplicationStatus = 0, ApplicationTypeID = 0, CreatedBy = 0;
            Double PaidFees = 0;
            if (clsDataLayer.FindApplicationUsingID(ApplicationID , ref ApplicationPersonID 
                ,ref ApplicationDate ,ref ApplicationTypeID ,ref ApplicationStatus ,ref ApplicationLastDate 
                ,ref PaidFees ,ref CreatedBy))
            {
                return new clsApplication2(ApplicationID , ApplicationPersonID , ApplicationDate 
                    ,ApplicationTypeID , ApplicationStatus , ApplicationLastDate 
                    ,PaidFees , CreatedBy);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsDataLayer.AddNewApplication(ApplicationPersonID, ApplicationLastDate
                , ApplicationTypeID, ApplicationStatus, ApplicationLastDate, PaidFees, CreatedByUserID);

            return (this.ApplicationID != -1);
        }


        public static int  GetIDUserUsingLogIn(string UserName)
        {
            return clsDataLayer.GetIDUserUsingLogIn(UserName);
        }

        public bool Save()
        {
            return _AddNewApplication();
        }

        public static bool IsExistLocalDrivingInSystem(string ClassName , string NationalNo)
        {
            return clsDataLayer.IsExistLocalDrivingInSystem(ClassName, NationalNo);
        }


        public static string GetPersonNameForApplication(int ApplicationPerson)
        {
            return clsDataLayer.GetPersonNameForApplication(ApplicationPerson);
        }


        public static string GetApplicationTitleForApplication(int ApplicationTypeID) 
        {
            return clsDataLayer.GetApplicationTitleForApplication(ApplicationTypeID);
        }


        public static string GetUserNameForApplication(int UserID)
        {
            return clsDataLayer.GetUserNameForApplication(UserID);
        }


        public static bool DeleteApplicationUsingAppID(int ApplicationID)
        {
            return clsDataLayer.DeleteApplicationUsingAppID(ApplicationID);
        }
    }
}
