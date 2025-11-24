using System;
using DVLD_AccessData;

namespace DVLD_Countries
{
    public class clsCountries
    {

        public string CountryName { get; set; }

        public int CountryID { get; set; }

        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountries FindCountryUsingID(int CountryID)
        {
            string CountryName = "";
            if (clsDataLayer.FindCountryUsingID(CountryID, ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }


        public static clsCountries FindCountryUsingName(string CountryName)
        {
            int CountryID = -1;
            if (clsDataLayer.FindCountryUsingName(CountryName, ref CountryID))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }
    }
}
