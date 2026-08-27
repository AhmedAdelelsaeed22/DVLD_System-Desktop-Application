using AccessDataSettingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLayer
{
    public class clsCountriesData
    {
        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_GetAllCountries", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtCountries.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtCountries;
        }

        public static int GetCountryIdUsingCountryName(string CountryName)
        {
            int CountryID = -1;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fn_getCountryID(@CountryName);", connection))
            {
                command.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString() , out int ID)) 
                    {
                        CountryID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return CountryID;
        }


        public static string GetCountryNameUsingCountryID(int CountryID)
        {

            string CountryName = "";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fn_GetCountryName(@CountryID);", connection))
            {
                command.Parameters.AddWithValue("@CountryID", CountryID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        CountryName = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return CountryName;
        }
    }
}
