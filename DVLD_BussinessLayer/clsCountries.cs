using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

        public static int GetCountryIdUsingCountryName(string CountryName)
        {
            return clsCountriesData.GetCountryIdUsingCountryName(CountryName);
        }
    
    
        public static string GetCountryNameUsingCountryID(int CountryID)
        {
            return clsCountriesData.GetCountryNameUsingCountryID(CountryID);
        }


    }
}
