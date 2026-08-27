using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;


        public int DriverID { get; set; }

        public int PersonID { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate { get; set; }



        // Default Constructor

        public clsDrivers()
        {

            this.DriverID = -1;

            this.PersonID = -1;

            this.CreatedByUserID = -1;

            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;

        }



        // Private Constructor

        private clsDrivers(
            int DriverID,
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {

            this.DriverID = DriverID;

            this.PersonID = PersonID;

            this.CreatedByUserID = CreatedByUserID;

            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;

        }



        // Add New

        private bool _AddNewDriver()
        {

            this.DriverID =
                clsDriversData.InsertDriver(

                    this.PersonID,
                    this.CreatedByUserID,
                    this.CreatedDate
                );

            return (this.DriverID != -1);

        }



        // Save

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewDriver())
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


        // ---------------- GET ALL DRIVERS ----------------
        public static DataTable GetAllDrivers()
        {

            return clsDriversData.GetAllDrivers();

        }

    }
}
