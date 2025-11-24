using DVLD_AccessData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_TestTypes
{
    public class clsTestType
    {
        public int TestTypeID {get; set;}

        public string TestTypeTitle { get; set;}


        public string TestTypeDescription { get; set;}


        public Double TestTypeFees {  get; set;}


        private bool _UpdateData()
        {
            return clsDataLayer.UpdateTestTypeUsingID(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        private clsTestType(int TestTypeID , string TestTypeTitle , string TestTypeDescription , Double TestTypeFees) 
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
        }

        public static clsTestType FindTestTypeUsingID(int TestTypeID)
        {
            string TestTypeTitle = "" , TestTypeDescription = "" ;
            Double TestTypeFees = 0;
            if (clsDataLayer.FindTestTypeUsingID(TestTypeID , ref TestTypeTitle 
                , ref TestTypeDescription , ref TestTypeFees))
            {
                return new clsTestType(TestTypeID , TestTypeTitle , TestTypeDescription , TestTypeFees);
            }
            else
            {
                return null;
            }
        }


        public static DataTable GetAllTestTypes()
        {
            return clsDataLayer.GetAllTestTypes();
        }


        public static int GetCountRecordesTestTypes()
        {
            return clsDataLayer.GetAllCountRecordsInTestType();
        }

        public bool Save()
        {
            return _UpdateData();
        }
    }
}
