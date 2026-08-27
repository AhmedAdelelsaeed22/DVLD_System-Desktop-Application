using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsApplicationType
    {

        // ---------- PROPERTIES ----------
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        // ---------- GET ALL ----------
        public static DataTable GetAllApplicationTypes()
        {
           return clsApplicationTypeData.GetAllApplicationTypes();
        }

        // ---------- CONSTRUCTOR ----------
        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = null;
            ApplicationFees = 0;
        }

        private clsApplicationType(
        int applicationTypeID,
        string applicationTypeTitle,
        decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;

        }

        //------------- FIND ---------------


        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            if (clsApplicationTypeData.FindApplicationType(
                ApplicationTypeID,
                ref ApplicationTypeTitle,
                ref ApplicationFees))
            {
                return new clsApplicationType(
                    ApplicationTypeID,
                    ApplicationTypeTitle,
                    ApplicationFees);
            }
            else
            {
                return null;
            }
        }



        // ---------- UPDATE ----------
        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(
                ApplicationTypeID,
                ApplicationTypeTitle,
                ApplicationFees);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static decimal GetApplicationFees(int ApplicationID)
        {
            return clsApplicationTypeData.GetApplicationFees(ApplicationID);
        }

        public static string GetApplicationTypeTitle(int ApplicationTypeID)
        {
            return clsApplicationTypeData.GetApplicationTypeTitle(ApplicationTypeID);
        }
    }
}
