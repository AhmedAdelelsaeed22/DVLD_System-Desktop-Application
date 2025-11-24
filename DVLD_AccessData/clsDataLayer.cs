using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;



namespace DVLD_AccessData
{
    public class clsDataLayer
    {
        public static bool FindPeopleUsingPersonID(int PersonID
            , ref string NationalNO, ref string FirstName, ref string SecondName
            , ref string ThirdName, ref string LastName
            , ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone
            , ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "SELECT * FROM People where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    NationalNO = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    if (reader["NationalityCountryID"] != DBNull.Value)
                    {
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                    }
                    else
                    {
                        NationalityCountryID = -1;
                    }

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }



        public static bool FindPeopleUsingNationalNO(ref int PersonID
      , string NationalNO, ref string FirstName, ref string SecondName
      , ref string ThirdName, ref string LastName
      , ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone
      , ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From People where NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];

                    if (reader["NationalityCountryID"] != DBNull.Value)
                    {
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                    }
                    else
                    {
                        NationalityCountryID = -1;
                    }

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static int AddNewPersonInSystem(
            string NationalNO, string FirstName, string SecondName
            , string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gendor, string Address, string Phone
            , string Email, int NationalityCountryID, string ImagePath)
        {
            int Id = -1;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"INSERT INTO People
                   (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                VALUES
                   (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                    Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            if (NationalityCountryID != -1)
            {
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            }
            else
            {
                command.Parameters.AddWithValue("@NationalityCountryID", DBNull.Value);
            }
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
                if (result != null && int.TryParse(result.ToString(), out int Idintity))
                {
                    Id = Idintity;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return Id;
        }



        public static bool UpdatePersonInSystem(int PersonID
            , string NationalNO, string FirstName, string SecondName
            , string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gendor, string Address, string Phone
            , string Email, int NationalityCountryID, string ImagePath)
        {

            int rowAffect = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"UPDATE People
                   SET NationalNo = @NationalNo
                  ,FirstName = @FirstName
                  ,SecondName = @SecondName
                  ,ThirdName = @ThirdName
                  ,LastName = @LastName
                  ,DateOfBirth = @DateOfBirth
                  ,Gendor = @Gendor
                  ,Address = @Address
                  ,Phone = @Phone
                  ,Email = @Email
                  ,NationalityCountryID = @NationalityCountryID
                  ,ImagePath = @ImagePath
                   WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNO);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            if (NationalityCountryID != -1)
            {
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            }
            else
            {
                command.Parameters.AddWithValue("@NationalityCountryID", DBNull.Value);
            }
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
                rowAffect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return (rowAffect > 0);
        }



        public static bool DeletePersonFromSystem(int PersonID)
        {
            int rowAffect = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"DELETE FROM People
                                WHERE PersonID = @PersonID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowAffect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //....
            }
            finally
            {
                connection.Close();
            }

            return (rowAffect > 0);
        }


        public static DataTable GetAllPersonsFromSystem()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "SELECT * FROM People;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return result;
        }



        public static DataTable GetAllCountries()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "SELECT * FROM Countries;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return result;
        }


        public static bool FindCountryUsingID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From Countries where CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                //......
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static int GetPersonIDUsingNationalNo(string NationalNo)
        {
            int PersonID = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select PersonID From People Where NationalNo = @NationalNo;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
                //...
            }
            finally { connection.Close(); }

            return PersonID;
        }


        public static bool FindCountryUsingName(string CountryName, ref int CountryID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From Countries where CountryName = @CountryName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryID = (int)reader["CountryID"];
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                //......
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static int GetCountRecords()
        {
            int Records = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select count(*) From People;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    Records = Count;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return Records;
        }


        public static bool IsExistsUser(string UserName, string Password)
        {
            bool Exist = false;

            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select * from Users where UserName = @UserName 
                            AND Password = @Password 
                            AND IsActive = 1;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName" , UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Exist = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return Exist;
        }
    
    
        public static DataTable GetAllUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection connection = new SqlConnection( clsAccessDataSettings.ConnectionString);


            string query = "Select UserID , PersonID , UserName , IsActive From Users; ";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Users.Load(reader);
                }
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return Users;
        }


        public static int GetCountRecordsForUsers()
        {
            int Records = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select count(*) From Users;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    Records = Count;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return Records;
        }


        public static bool IsExistPersonInSystem(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = "Select * From Users where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID" , PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                }

                reader.Close();
            }
            catch
            {
                //...
            }finally { connection.Close(); }

            return IsFound;
        }


        public static int AddNewUserInSystem(int PersonID , string UserName 
            , string Password , byte IsActive)
        {
            int Identity = 0;
            SqlConnection connection = new SqlConnection (clsAccessDataSettings.ConnectionString);

            string query = @"INSERT INTO Users
                               (PersonID,UserName,Password,IsActive)
                         VALUES
                               (@PersonID,@UserName,@Password,@IsActive);
                                Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@PersonID" , PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    Identity = Id;
                }
            }
            catch (Exception ex) 
            {
                //..
            }
            finally
            {
                connection.Close();
            }

            return Identity;
        }


        public static bool UpdateUserInSystem(int UserId , int PersonID, string UserName
            , string Password, byte IsActive)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"UPDATE Users
                           SET PersonID =   @PersonID
                              ,UserName =   @UserName
                              ,Password =   @Password
                              ,IsActive =   @IsActive
                           WHERE UserId =   @UserId";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@PersonID" , PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //..
            }
            finally 
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }


        public static bool FindUsersUsingUserID(int UserId, ref int PersonID, ref string UserName
            , ref string Password, ref byte IsActive)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From Users where UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID" , UserId);

            try
            {
                connection.Open();
                SqlDataReader redaer = command.ExecuteReader();
                if (redaer.Read())
                {
                    PersonID = (int)redaer["PersonID"];
                    UserName = (string)redaer["UserName"];
                    Password = (string)redaer["Password"];
                    IsActive = (byte)redaer["IsActive"];
                    Found = true;
                }

                redaer.Close();
            }
            catch (Exception ex)
            {
                //....
            }
            finally
            {
                connection.Close();
            }

            return Found;
        } 



        public static DataTable GetUsersByUserID(int UserID)
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection( clsAccessDataSettings.ConnectionString);

            string query = "Select UserID , PersonID , UserName , IsActive From Users where UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID" , UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return result;
        }


        public static DataTable GetUsersByIsActive(byte IsActive)
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select UserID , PersonID , UserName , IsActive From Users where IsActive = @IsActive;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@IsActive" , IsActive);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result.Load(reader);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                //....
            }
            finally 
            { 
                connection.Close(); 
            }

            return result;
        }


        public static bool DeleteUserFromSystem(int UserID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"DELETE FROM Users
                                WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue ("@UserId" , UserID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }


        public static string IsExistPassword(int UserID)
        {
            string Password = "";

            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"SELECT Password
                             FROM Users
                             WHERE UserId = @UserId;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@UserId" , UserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Password = (string)result;
                }
            }
            catch (Exception ex) 
            {
                //..
            }
            finally
            {
                connection.Close();
            }

            return Password;
        }


        public static bool ChangeUserPassword(int UserID , string NewPassword)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"UPDATE Users
                           SET Password = @NewPassword
                           WHERE UserId = @UserId;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@UserId", UserID);
            command.Parameters.AddWithValue("@NewPassword" , NewPassword);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //....
            }finally 
            { 
                connection.Close(); 
            }

            return (rowAffected > 0);
        }
    
    
        public static int UserIDUsingInCurrentLogin(string UserName)
        {
            int identity = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select UserID From Users
                                where UserName = @UserName;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@UserName" , UserName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    identity = id;
                }
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return identity;
        }
    

        public static DataTable GetAllApplicationType()
        {
            DataTable ApplicationData = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From ApplicationTypes;";

            SqlCommand command = new SqlCommand(query , connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ApplicationData.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //....
            }
            finally
            {
                connection.Close();
            }

            return ApplicationData;
        }


        public static int GetCountRecordsInApplicationType()
        {
            int RecordsCount = 0;
            SqlConnection connection = new SqlConnection( clsAccessDataSettings.ConnectionString);

            string query = "Select Count(*) From ApplicationTypes;";

            SqlCommand command = new SqlCommand(query , connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int count))
                {
                    RecordsCount = count;
                }
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return RecordsCount;
        }


        public static bool UpdateApplicationType(int ApplicationTypeID ,string ApplicationTitle , Double ApplicationFees)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes
                             SET ApplicationTypeTitle = @ApplicationTypeTitle
                                ,ApplicationFees = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }


        public static bool FindApplicationUsingID(int ApplicationTypeID, ref string ApplicationTitle, ref Double ApplicationFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection (clsAccessDataSettings.ConnectionString);

            string query = @"Select * From ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";


            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID" , ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (Double)reader["ApplicationFees"];
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool FindTestTypeUsingID(int TestTypeID , ref string TestTypeTitle , ref string TestTypeDescription , ref Double TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select * From TestTypes Where TestTypeID = @TestTypeID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (Double)reader["TestTypeFees"];
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static bool UpdateTestTypeUsingID(int TestTypeID , string TestTypeTitle , string TestTypeDescription , Double TestTypeFees)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @TestTypeTitle
                                 ,TestTypeDescription = @TestTypeDescription
                                 ,TestTypeFees = @TestTypeFees
                             WHERE TestTypeID = @TestTypeID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }


        public static int GetAllCountRecordsInTestType()
        {
            int RecordsCount = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select count(*) From TestTypes;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int count))
                {
                    RecordsCount = count;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally
            {
                connection.Close();
            }

            return RecordsCount;
        }


        public static DataTable GetAllTestTypes() 
        {
            DataTable TestTypes = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select * From TestTypes;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    TestTypes.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //....
            }
            finally
            {
                connection.Close();
            }

            return TestTypes;
        }


        public static DataTable GetAllLicensesClasses() 
        {
            DataTable LinsesClasses = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "SELECT ClassName FROM LicenseClasses;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LinsesClasses.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //....
            }
            finally
            {
                connection.Close();
            }

            return LinsesClasses;
        }


        public static int GetApplicationFeesForLocalLicense(int AppID)
        {
            int Fees = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = "Select ApplicationFees From ApplicationTypes where ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID" , AppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int identity))
                {
                    Fees = identity;
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally 
            { connection.Close(); }

            return Fees;
        }



        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID
            , int ApplicationStatus, DateTime LastStatusDate, Double PaidFees, int CreatedByUserID)
        {
            int identity = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"INSERT INTO [dbo].[Applications]
                               (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                         VALUES
                               (@ApplicantPersonID, @ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate, @PaidFees,@CreatedByUserID);
                                Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    identity = ID;
                }
            }
            catch (Exception ex) 
            {
                //..
            }finally { connection.Close(); }

            return identity;
        }



        public static int AddNewLocalDriverLicense(int ApplicationID ,int LicenseClassID)
        {
            int identity = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"INSERT INTO LocalDrivingLicenseApplications
                                   (ApplicationID,LicenseClassID)
                             VALUES
                                   (@ApplicationID,@LicenseClassID);
                                    Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    identity = ID;
                }
            }
            catch (Exception ex)
            {
                //..
            }
            finally { connection.Close(); }

            return identity;
        } 


        public static int GetIDUserUsingLogIn(string UserName)
        {
            int UserID = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select UserID From Users where UserName = @UserName;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName" , UserName);

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
                //...
            }finally { connection.Close(); }

            return UserID;
        }


        public static int GetIDUsingLicenseClass(string ClassName)
        {
            int LicenseClassID = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select LicenseClassID From LicenseClasses where ClassName = @ClassName;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    LicenseClassID = ID;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return LicenseClassID;
        }


        public static bool IsExistLocalDrivingInSystem(string ClassName , string NationalNo)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select ClassName , NationalNo From LocalDrivingLicenseApplications_View
                                 where ClassName = @ClassName AND NationalNo = @NationalNo
                                 AND Status = 'New';";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }


            return Found;
        }


        public static DataTable GetAllLocalDrivingLicense()
        {
            DataTable localDrivinglicensetable = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = "Select * From LocalDrivingLicenseApplications_View;";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    localDrivinglicensetable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //....
            }
            finally { connection.Close(); }

            return localDrivinglicensetable;
        }


        public static int GetDrivingLicenseCount() 
        {
            int DrivingLicenseCount = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = "Select count(*) From LocalDrivingLicenseApplications_View;";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString() , out int count))
                {
                    DrivingLicenseCount = count;
                }
            }
            catch (Exception ex)
            {
                //....
            }
            finally { connection.Close(); }

            return DrivingLicenseCount;
        }


        public static DataTable GetLocalDrivingLicenseUsingNationalNo(string NationalNo)
        {
            DataTable Table = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From LocalDrivingLicenseApplications_View
                                     where NationalNo = @NationalNo;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Table.Load(reader);
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }


            return Table;
        }


        public static DataTable GetLocalDrivingLicenseUsingID(int LDAppID)
        {
            DataTable Table = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From LocalDrivingLicenseApplications_View
                                      where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID", LDAppID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Table.Load(reader);
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }


            return Table;
        }


        public static string GetClassNameUsingID(int LicenseClassID)
        {
            string ClassName = "";
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select ClassName From LicenseClasses 
                                  where LicenseClassID = @LicenseClassID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID" , LicenseClassID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ClassName = result.ToString();
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }

            return ClassName;
        }


        public static bool FindLocalDrivingLicenseApplications(int LDAppID , ref int ApplicationID , ref int LicenseClass)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From LocalDrivingLicenseApplications
                                  where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID" , LDAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClass = (int)reader["LicenseClassID"];
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //..
            }
            finally {  connection.Close(); }

            return IsFound;
        }


        public static bool FindApplicationUsingID(int ApplicationID ,ref int ApplicationPersonID 
            , ref DateTime ApplicationDate , ref int ApplicationTypeID , ref int ApplicationStatus , ref DateTime LastStatusDate 
            , ref Double PaidFess , ref int CreatedBy)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From Applications
                               where ApplicationID = @ApplicationID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (int)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFess = (Double)reader["PaidFees"];
                    CreatedBy = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //..
            }
            finally { connection.Close(); }

            return IsFound;
        }


        public static string GetPersonNameForApplication(int ApplicationPersonID)
        {
            string PersonName = "";
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select FirstName + ' ' + LastName From People
                                   where PersonID = @PersonID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ApplicationPersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    PersonName = result.ToString();
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }

            return PersonName;
        }


        public static string GetApplicationTitleForApplication(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select ApplicationTypeTitle From ApplicationTypes
                                    where ApplicationTypeID = @ApplicationTypeID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ApplicationTypeTitle = result.ToString();
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return ApplicationTypeTitle;
        }


        public static string GetUserNameForApplication(int UserID)
        {
            string UserName = "";
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"Select UserName From Users
                                    where UserID = @UserID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    UserName = result.ToString();
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return UserName;
        }


        public static DataTable GetAllAppointments(int LDAppID)
        {
            DataTable appointments = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select TestAppointmentID , AppointmentDate , PaidFees , IsLocked
          From TestAppointments where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID" , LDAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    appointments.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return appointments;
        }


        public static int GetCountRecordsForAppointments(int LDAppID)
        {
            int CountRecords = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select Count(*)
          From TestAppointments where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID", LDAppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    CountRecords = Count;
                }
            }
            catch (Exception ex) 
            {
                //....
            }finally { connection.Close(); }

            return CountRecords;
        }


        public static Double GetFeesForVisionTest()
        {
            Double FeesForTest = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select TestTypeFees From TestTypes where TestTypeID = 1; ";


            SqlCommand command = new SqlCommand(query , connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    FeesForTest = Convert.ToDouble(result);
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }

            return FeesForTest;
        }


        public static bool CheckHaveVisionTest(int LDAppID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection (clsAccessDataSettings.ConnectionString);


            string query = @"Select * From TestAppointments where TestTypeID = 1 
                                 AND LocalDrivingLicenseApplicationID = @LDAppID AND IsLocked = 0; ";


            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@LDAppID" , LDAppID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                }
            }
            catch (Exception ex) 
            {
                //....
            }
            finally {  connection.Close(); }

            return IsFound;
        }


        public static int AddNewAppointMentTest(int TestTypeID , int LDAppID , DateTime AppointmentDate 
            ,Double PaidFees , int CreatedByUserID , bool IsLocked)
        {
            int TestID = 0;
            SqlConnection connection = new SqlConnection (clsAccessDataSettings.ConnectionString);


            string query = @"INSERT INTO TestAppointments
                            (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                             PaidFees, CreatedByUserID, IsLocked)
                        VALUES
                            (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                             @PaidFees, @CreatedByUserID, @IsLocked);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@TestTypeID" , TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDAppID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString() , out int ID)) 
                {
                    TestID = ID; 
                }
            }
            catch (Exception ex) 
            {
                //..
            }finally { connection.Close(); }


            return TestID;
        }


        public static bool FindAppointMentTest(int TestID ,ref int TestTypeID,ref int LDAppID,ref DateTime AppointmentDate
            , ref Double PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From TestAppointments where TestAppointmentID = @TestID;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@TestID" , TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LDAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (Double)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }finally {connection.Close(); }

            return IsFound;
        }


        public static bool UpdateAppointmentTest(int TestID , int TestTypeID, int LDAppID, DateTime AppointmentDate
            , Double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"UPDATE TestAppointments
                           SET TestTypeID = @TestTypeID
                              ,LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                              ,AppointmentDate = @AppointmentDate
                              ,PaidFees = @PaidFees
                              ,CreatedByUserID = @CreatedByUserID
                              ,IsLocked = @IsLocked
                               WHERE TestAppointmentID = @TestID";


            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@TestTypeID" , TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDAppID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            } catch (Exception ex) 
            {
                //...
            }
            finally { connection.Close(); }

            return (RowAffected > 0);
        }


        public static string GetDateAppintmentTest(int LDAppID)
        {
            string date = "";
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);

            string query = @"SELECT AppointmentDate FROM TestAppointments 
                                    where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand (query , connection);
            command.Parameters.AddWithValue("@LDAppID" , LDAppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    date = result.ToString();
                }
            }
            catch (Exception ex) 
            {
                //..
            }finally { connection.Close(); }

            return date;
        }


        public static bool SaveLockedAppointment(int TestID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"UPDATE TestAppointments
                            SET IsLocked = 1
                            WHERE TestAppointmentID = @TestID;";


            SqlCommand command = new SqlCommand (query , connection);
            command.Parameters.AddWithValue("@TestID" , TestID);

            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }

            return (RowAffected > 0);
        }


        public static bool GetLockedForTest(int TestID)
        {
            bool IsLocked = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select IsLocked From TestAppointments
                                where TestAppointmentID = @TestID;";

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@TestID" , TestID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    IsLocked = (bool)Result;
                }
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }

            return IsLocked;
        }


        public static bool GetLocalDrivingLicenseDetails(int LDAppID , ref string ClassName,ref string NationalNo
            ,ref string FullName , ref DateTime ApplicationDate , ref int PassedTestAccount ,ref string Status)
        {
            bool Success = false;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From LocalDrivingLicenseApplications_View
                                  where LocalDrivingLicenseApplicationID = @LDAppID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID", LDAppID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    NationalNo = (string)reader["NationalNo"];
                    FullName = (string)reader["FullName"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PassedTestAccount = (int)reader["PassedTestCount"];
                    Status = (string)reader["Status"];

                    Success = true;
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }finally { connection.Close(); }


            return Success;
        }



        public static bool DeleteLocalDrivingLicense(int LDAppID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"DELETE FROM [dbo].[LocalDrivingLicenseApplications]
                                  WHERE LocalDrivingLicenseApplicationID = @LDAppID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDAppID" , LDAppID);

            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                //....
            }finally { connection.Close(); }

            return (RowAffected > 0);
        }


        public static bool DeleteApplicationUsingAppID(int ApplicationID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"DELETE FROM Applications
                               WHERE ApplicationID = @ApplicationID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //....
            }
            finally { connection.Close(); }

            return (RowAffected > 0);
        }


        public static DataTable GetAllDrivers()
        {
            DataTable drivers = new DataTable();
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select * From Drivers_View;";

            SqlCommand command = new SqlCommand(query , connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    drivers.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                //...
            }finally {connection.Close(); }

            return drivers;
        }

        public static int GetCountDrivers()
        {
            int CountDrivers = 0;
            SqlConnection connection = new SqlConnection(clsAccessDataSettings.ConnectionString);


            string query = @"Select Count(*) From Drivers_View;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString() , out int Count)) 
                {
                    CountDrivers = Count;
                }
            }
            catch (Exception ex)
            {
                //...
            }
            finally { connection.Close(); }

            return CountDrivers;
        }
    }
}
