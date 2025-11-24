using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_AccessData;


namespace DVLD_Application
{
    public class clsApplication
    {

        public int ApplicationID { get; set; }

        public string ApplicationTitle { get; set; }


        public Double ApplicationFees {  get; set; }


        private clsApplication(int ApplicationID , string ApplicationTitle , Double ApplicationFees) 
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationTitle = ApplicationTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicationTitle = "";
            this.ApplicationFees = 0; 
        }

        private bool _UpdateApp()
        {
            return clsDataLayer.UpdateApplicationType(ApplicationID, ApplicationTitle, ApplicationFees);
        }

        public static clsApplication FindApplicationUsingID(int ApplicationID)
        {
            string ApplicationTitle = ""; Double ApplicationFees = 0;
            if (clsDataLayer.FindApplicationUsingID(ApplicationID , ref ApplicationTitle , ref ApplicationFees))
            {
                return new clsApplication(ApplicationID , ApplicationTitle , ApplicationFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllApplicationType()
        {
            return clsDataLayer.GetAllApplicationType();
        }

        public static int GetCountRecordsInApplicationType()
        {
            return clsDataLayer.GetCountRecordsInApplicationType();
        }


       public bool Save()
       {
            return _UpdateApp();
       }


      public static int GetApplicationFeesForLocalLicense(int AppID)
      {
            return clsDataLayer.GetApplicationFeesForLocalLicense(AppID);
      }
    }
}
