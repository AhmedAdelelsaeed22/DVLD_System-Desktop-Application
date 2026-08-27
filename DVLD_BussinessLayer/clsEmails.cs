using AccessDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsEmails
    {
        
        public int EmailID { get; private set; }
        public string EmailRequeist { get; set; }
        public string EmailResponse { get; set; }
        public string Message { get; set; }
        public int PersonID { get; set; }

        // =======================
        // Constructor
        // =======================
        public clsEmails()
        {
            EmailID = -1;
            EmailRequeist = string.Empty;
            EmailResponse = string.Empty;
            Message = string.Empty;
            PersonID = -1;
        }

        
        public static DataTable GetAllEmails()
        {
            return clsEmailsData.GetAllEmails();
        }


        private bool _AddNewEmail()
        {
            EmailID = clsEmailsData.InsertNewEmail(
                EmailRequeist,
                EmailResponse,
                Message,
                PersonID
            );

            return (EmailID != -1);
        }


        public bool Save()
        {
           return _AddNewEmail();
        }
    }
}
