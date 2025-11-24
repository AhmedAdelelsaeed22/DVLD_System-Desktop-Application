using DVLD_Business;
using DVLD_Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class UserDetailsForm : Form
    {

        int _UserID;
        clsBusineesLayer _PersonInfo;
        clsUsers _UserInfo;


        public UserDetailsForm(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }


        private void _DataLoad()
        {
            _UserInfo = clsUsers.FindUser(_UserID);

            if (_UserInfo != null)
            {
                ctrlUserDetails1.LoadUserInfo(_UserInfo);
            }

            _PersonInfo = clsBusineesLayer.FindPersonUsingPersonID(_UserInfo.PersonID);

            if (_PersonInfo != null)
            {
                ctrlUserDetails1.LoadPersonInfo(_PersonInfo);
            }
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
