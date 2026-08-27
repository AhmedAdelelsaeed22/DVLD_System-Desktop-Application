using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsLicenseClass
    {
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static int GetLicenseClassIDByClassName_SP(string ClassName)
        {
            return clsLicenseClassData.GetLicenseClassIDByClassName_SP(ClassName);
        }


        public static string GetLicenseClassName(int LicenseClassID)
        {
            return clsLicenseClassData.GetLicenseClassName(LicenseClassID);
        }


        public static byte GetDefaultValidityLength(int LicenseClassID)
        {

            return clsLicenseClassData
            .GetDefaultValidityLength(LicenseClassID);

        }
    }
}
