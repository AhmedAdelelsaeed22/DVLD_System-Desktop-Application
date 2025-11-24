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
    public partial class ChangePassword : Form
    {


        int _UserID;
        clsBusineesLayer _PersonInfo;
        clsUsers _UserInfo;


        public ChangePassword(int UserID)
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

        private void Change_Password_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPass.Text != clsUsers.IsExistPassword(_UserID))
            {
                e.Cancel = true;
                errorProviderCurrentPass.SetError(txtCurrentPass , "This password is wrong");
            }
            else
            {
                errorProviderCurrentPass.SetError(txtCurrentPass, "");
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                e.Cancel= true;
                errorProviderNewPass.SetError(txtNewPass , "This feild must not empty");
            }
            else
            {
                errorProviderNewPass.SetError(txtNewPass, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPass.Text != txtNewPass.Text)
            {
                e.Cancel = true;
                errorProviderConfirmPass.SetError(txtConfirmPass, "The password is not match");
            }
            else
            {
                errorProviderConfirmPass.SetError(txtConfirmPass, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsUsers.ChangeUserPassword(_UserID , txtNewPass.Text))
            {
                MessageBox.Show("Save is successfully" , "Successfully" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save is not successfully", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
