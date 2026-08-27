using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsUsers
    {
        // ---------- MODE ----------
        public enum enMode { Add = 0, Update = 1 }
        private enMode _Mode;

        // ---------- PROPERTIES ----------
        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        // ---------- GET ALL ----------
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        // ---------- PRIVATE CONSTRUCTOR (UPDATE MODE) ----------
        private clsUsers(
            int userID,
            int personID,
            string userName,
            string password,
            bool isActive)
        {
            UserID = userID;
            this.PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;

            _Mode = enMode.Update;
        }

        // ---------- FIND ----------
        public static clsUsers FindUser(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUsersData.FindUser(
                UserID,
                ref PersonID,
                ref UserName,
                ref Password,
                ref IsActive))
            {
                return new clsUsers(
                    UserID,
                    PersonID,
                    UserName,
                    Password,
                    IsActive);
            }
            else
            {
                return null;
            }
        }

        // ---------- PUBLIC CONSTRUCTOR (ADD MODE) ----------
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = null;
            Password = null;
            IsActive = true;

            _Mode = enMode.Add;
        }

        // ---------- ADD ----------
        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.InsertNewUser(
                PersonID,
                UserName,
                Password,
                IsActive);

            return (this.UserID != -1);
        }

        // ---------- UPDATE ----------
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(
                UserID,
                PersonID,
                UserName,
                Password,
                IsActive);
        }

        // ---------- SAVE ----------
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    return _AddNewUser();

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        // ---------- DELETE ----------
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }


        public static bool CheckLoginInfo(string UserName, string Password)
        {
            return clsUsersData.CheckLoginInfo(UserName, Password);
        }


        public static bool IsExistUser(int PersonID)
        {
            return clsUsersData.IsExistUser(PersonID);
        }


        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return clsUsersData.ChangePassword(UserID, NewPassword);
        }


        public static bool IsExistPassword(int UserID, string Password)
        {
            return clsUsersData.IsExistPassword(UserID, Password);
        }


        public static int GetUserIDUsingUserName(string UserName)
        {
            return clsUsersData.GetUserIDUsingUserName(UserName);
        }
    }
}
