using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using AccessDataSettingLayer;


namespace DVLD_AccessDataLayer
{
    public class clsPeopleData
    {
        // ---------------- GET ALL PEOPLE ----------------
        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_People_GetAll();", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtPeople.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtPeople;
        }

        // ---------------- FIND PERSON ----------------
        public static bool FindPerson(
            int PersonID,
            ref string NationalNo,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref DateTime DateOfBirth,
            ref byte Gendor,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_People_GetPerson(@PersonID);", connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NationalNo = reader["NationalNo"].ToString();
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"].ToString();
                            if (reader["ThirdName"] != DBNull.Value)
                            {
                                ThirdName = reader["ThirdName"].ToString();
                            }
                            else
                            {
                                ThirdName = "Don`t enter Third Name";
                            }
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gendor = (byte)reader["Gendor"];
                            Address = reader["Address"].ToString();
                            Phone = reader["Phone"].ToString();
                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = reader["Email"].ToString();
                            }
                            else
                            {
                                Email = "Don`t enter Email";
                            }

                            NationalityCountryID = (int)reader["NationalityCountryID"];
                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                ImagePath = reader["ImagePath"].ToString();
                            }
                            else
                            {
                                ImagePath = null;
                            }

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

        // ---------------- INSERT PERSON ----------------
        public static int InsertNewPerson(
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            byte Gendor,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath)
        {
            int PersonID = -1;

            string query = @"DECLARE @NewID INT;
                             EXEC sp_People_Add
                                @NationalNo = @NationalNo,
                                @FirstName = @FirstName,
                                @SecondName = @SecondName,
                                @ThirdName = @ThirdName,
                                @LastName = @LastName,
                                @DateOfBirth = @DateOfBirth,
                                @Gendor = @Gendor,
                                @Address = @Address,
                                @Phone = @Phone,
                                @Email = @Email,
                                @NationalityCountryID = @NationalityCountryID,
                                @ImagePath = @ImagePath,
                                @NewPersonID = @NewID OUTPUT;
                             SELECT @NewID;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                if (ThirdName != null)
                {
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                }
                else
                {
                    command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                }

                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                if (Email != null)
                {
                    command.Parameters.AddWithValue("@Email", Email);
                }
                else
                {
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                if (ImagePath != null)
                {
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                }
                else
                {
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                }

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            PersonID = ID;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLogErrors.LogError(ex);
                    }
            }

            return PersonID;
        }

        // ---------------- UPDATE PERSON ----------------
        public static bool UpdatePerson(
            int PersonID,
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            byte Gendor,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_People_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                if (ThirdName != null)
                {
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                }
                else
                {
                    command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                }
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                if (Email != null)
                {
                    command.Parameters.AddWithValue("@Email", Email);
                }
                else
                {
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                if (ImagePath != null)
                {
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                }
                else
                {
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                }

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

        // ---------------- DELETE PERSON ----------------
        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_People_Delete", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static bool IsNationalNoExists(string NationalNo)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_IsNationalNoExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        IsExists = (value == 1);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsExists;
        }



        public static bool FindPersonUsingNationalNo(
            string NationalNo,
            ref int PersonID,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref DateTime DateOfBirth,
            ref byte Gendor,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM dbo.fn_People_GetPersonUsingNationalNo(@NationalNo);", connection))
            {
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PersonID = (int)reader["PersonID"];
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"].ToString();
                            if (reader["ThirdName"] != DBNull.Value)
                            {
                                ThirdName = reader["ThirdName"].ToString();
                            }
                            else
                            {
                                ThirdName = "Don`t enter Third Name";
                            }
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gendor = (byte)reader["Gendor"];
                            Address = reader["Address"].ToString();
                            Phone = reader["Phone"].ToString();
                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = reader["Email"].ToString();
                            }
                            else
                            {
                                Email = "Don`t enter Email";
                            }

                            NationalityCountryID = (int)reader["NationalityCountryID"];
                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                ImagePath = reader["ImagePath"].ToString();
                            }
                            else
                            {
                                ImagePath = "Don`t enter Image";
                            }

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


        public static string GetPersonFirstName(int PersonID)
        {
            string FirstName = "";

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_People_GetFirstNameByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        FirstName = result.ToString();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return FirstName;
        }
    }
}
