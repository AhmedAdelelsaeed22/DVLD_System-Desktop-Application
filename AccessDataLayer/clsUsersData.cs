using AccessDataSettingLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccessDataLayer
{
    public class clsUsersData
    {
        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_Users_GetAll();", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtUsers;
        }


        public static bool FindUser(
        int UserID,
        ref int PersonID,
        ref string UserName,
        ref string Password,
        ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_Users_GetUser(@UserID);", connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PersonID = (int)reader["PersonID"];
                            UserName = reader["UserName"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = (bool)reader["IsActive"];

                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsFound;
        }


        public static int InsertNewUser(
        int PersonID,
        string UserName,
        string Password,
        bool IsActive)
        {
            int UserID = -1;

            string query = @"DECLARE @NewID INT;
                     EXEC sp_Users_Add
                        @PersonID = @PersonID,
                        @UserName = @UserName,
                        @Password = @Password,
                        @IsActive = @IsActive,
                        @NewUserID = @NewID OUTPUT;
                     SELECT @NewID;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        UserID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return UserID;
        }


        public static bool UpdateUser(
        int UserID,
        int PersonID,
        string UserName,
        string Password,
        bool IsActive)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_Users_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return (RowsAffected > 0);
        }


        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;

            string query = @"EXEC sp_Users_Delete
                            @UserID = @userID;
                        SELECT @@ROWCOUNT as RowAffected;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@userID", UserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString() , out int CountAffect)) 
                    {
                        RowsAffected = CountAffect;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return (RowsAffected > 0);
        }



        public static bool CheckLoginInfo(string UserName, string Password)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM fn_Users_CheckLogIn(@UserName , @Password);", connection))
            {
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString() , out int val)) 
                    {
                        Found = (val == 1) ? true : false; 
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Found;
        }


        public static bool IsExistUser(int PersonID)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fn_Users_IsExistUser(@PersonID);", connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int val))
                    {
                        Found = (val == 1) ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Found;
        }


       public static bool ChangePassword(int UserID, string NewPassword)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_Users_ChangePassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Password", NewPassword);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return (RowsAffected > 0);
        }


       public static bool IsExistPassword(int UserID , string Password)
       {
            bool Exist = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fn_Users_IsExistPassword(@UserID , @Password);", connection))
            {
                
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int val))
                    {
                        Exist = (val == 1) ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Exist;
       }


       public static int GetUserIDUsingUserName(string UserName)
        {
            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fn_Users_GetUserIDUsingUserName(@UserName);", connection))
            {
                command.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int val))
                    {
                        UserID = val;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return UserID;
        }
    }
}
