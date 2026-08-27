using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsApplicationTestType
    {

        // ---------- PROPERTIES ----------
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        // ---------- GET ALL ----------
        public static DataTable GetAllApplicationTestTypes()
        {
            return clsApplicationTestTypeData.GetAllApplicationTestTypes();
        }

        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsApplicationTestType(
            int testTypeID,
            string testTypeTitle,
            string testTypeDescription,
            decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;

        }

        // ---------- FIND ----------
        public static clsApplicationTestType Find(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (clsApplicationTestTypeData.FindApplicationTestType(
                TestTypeID,
                ref TestTypeTitle,
                ref TestTypeDescription,
                ref TestTypeFees))
            {
                return new clsApplicationTestType(
                    TestTypeID,
                    TestTypeTitle,
                    TestTypeDescription,
                    TestTypeFees);
            }
            else
            {
                return null;
            }
        }

        // ---------- PUBLIC CONSTRUCTOR ----------
        public clsApplicationTestType()
        {
            TestTypeID = -1;
            TestTypeTitle = null;
            TestTypeDescription = null;
            TestTypeFees = 0;

        }

        // ---------- UPDATE ----------
        private bool _UpdateApplicationTestType()
        {
            return clsApplicationTestTypeData.UpdateApplicationTestType(
                TestTypeID,
                TestTypeTitle,
                TestTypeDescription,
                TestTypeFees);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            return _UpdateApplicationTestType();
        }


        public static decimal GetApplicationTestTypeFees(int TestTypeID)
        {
            return clsApplicationTestTypeData.GetApplicationTestTypeFees(TestTypeID);
        }
    }
}
