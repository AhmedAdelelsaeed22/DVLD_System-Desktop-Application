using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsTests
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        // ---------- CONSTRUCTOR ----------
        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;

            _Mode = enMode.Add;
        }

        // ---------- ADD ----------
        private bool _AddNewTest()
        {
            this.TestID =
                clsTestsData.InsertTest(
                    TestAppointmentID,
                    TestResult,
                    Notes,
                    CreatedByUserID);

            return (this.TestID != -1);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            if (_Mode == enMode.Add)
                return _AddNewTest();

            return false;
        }


        public static bool IsPassedTest(int TestAppointmentID)
        {
            return clsTestsData.IsPassedTest(TestAppointmentID);
        }
    }
}
