using AccessDataSettingLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccessDataLayer
{

    public class clsEmailsData
    {
        public static DataTable GetAllEmails()
        {
            DataTable dtEmails = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_Emails_GetAll();", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtEmails.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtEmails;
        }


        public static int InsertNewEmail(
        string EmailRequeist,
        string EmailResponse,
        string Message,
        int PersonID)
        {
            int EmailID = -1;

            string query = @"DECLARE @NewID INT;
                     EXEC sp_Emails_Add
                         @EmailRequeist = @EmailRequeist,
                         @EmailResponse = @EmailResponse,
                         @Message = @Message,
                         @PersonID = @PersonID,
                         @NewEmailID = @NewID OUTPUT;
                     SELECT @NewID;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
            
                    command.Parameters.AddWithValue("@EmailRequeist", EmailRequeist);
                
                    command.Parameters.AddWithValue("@EmailResponse", EmailResponse);

                    command.Parameters.AddWithValue("@Message", Message);

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        EmailID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return EmailID;
        }

    }

}
