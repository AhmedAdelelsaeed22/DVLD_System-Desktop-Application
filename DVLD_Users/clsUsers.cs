using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_AccessData;

namespace DVLD_Users
{
    public class clsUsers
    {
        public enum enModeUser {AddMode = 0, UpdateMode = 1}
        private enModeUser _ModeUser;

        public int UserID {get; set;}

        public int PersonID {get; set;}

        public string UserName {get; set;}

        public string Password {get; set;}

        public byte IsActive { get; set;}

        private bool _AddNewUser()
        {
            this.UserID = clsDataLayer.AddNewUserInSystem(PersonID, UserName, Password , IsActive);
            return (this.UserID != -1);
        }


        private bool _UpdateUser()
        {
            return clsDataLayer.UpdateUserInSystem(this.UserID, this.PersonID,
                this.UserName, this.Password, this.IsActive);
        }

        private clsUsers(int UserID , int PersonID , string UserName 
            , string Password , byte IsActive) 
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            _ModeUser = enModeUser.UpdateMode;
        }


        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = 0;

            _ModeUser= enModeUser.AddMode;
        }


        public static clsUsers FindUser(int UserID)
        {
            int PersonID = -1; string UserName = "";
            string Password = ""; byte IsActive = 0;
            if (clsDataLayer.FindUsersUsingUserID(UserID , ref PersonID 
                , ref UserName , ref Password, ref IsActive))
            {
                return new clsUsers(UserID , PersonID , UserName , Password , IsActive);
            }
            else
            {
                return null;
            }
        }


        public bool Save()
        {
            switch (_ModeUser) 
            {
                case enModeUser.AddMode:
                    if (_AddNewUser())
                    {
                        _ModeUser = enModeUser.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enModeUser.UpdateMode:
                    return _UpdateUser();
            }
            
            return false;
        }


        public static DataTable GetUsersByUserID(int UserID)
        {
            return clsDataLayer.GetUsersByUserID(UserID);
        }


        public static DataTable GetUsersByIsActive(byte IsActive)
        {
            return clsDataLayer.GetUsersByIsActive(IsActive);
        }


        public static bool DeleteUserFromSystem(int UserID)
        {
            return clsDataLayer.DeleteUserFromSystem(UserID);
        }


        public static string IsExistPassword(int UserID)
        {
            return clsDataLayer.IsExistPassword(UserID);
        }


        public static bool ChangeUserPassword(int UserID , string NewPassword)
        {
            return clsDataLayer.ChangeUserPassword(UserID, NewPassword);
        }
    
    
    
        public static int UserIDUsingInCurrentLogin(string UserName)
        {
            return clsDataLayer.UserIDUsingInCurrentLogin(UserName);
        }
    }
}
