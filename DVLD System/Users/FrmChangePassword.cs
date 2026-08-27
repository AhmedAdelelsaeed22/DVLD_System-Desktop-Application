using DVLD_BussinessLayer;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.Users
{
    public partial class FrmChangePassword : MaterialSkin.Controls.MaterialForm
    {

        int _UserID = -1;
        clsUsers _UserInfo;
        clsPeople _PersonInfo;


        public FrmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void DataLoad()
        {
            _UserInfo = clsUsers.FindUser(_UserID);

            if (_UserInfo != null)
            {
                _PersonInfo = clsPeople.FindPerson(_UserInfo.PersonID);
            }

            if (_PersonInfo != null)
            {
                ctrlUserDetails1.LoadDataToForm(_PersonInfo, _UserInfo);
            }
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPass.Text))
            {
                if (clsUsers.ChangePassword(_UserInfo.UserID , txtNewPass.Text))
                {
                    MessageBox.Show("Password Is Changed!" , "Successfully" 
                        ,MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Somwthing Error", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPass.Text) 
                || !clsUsers.IsExistPassword(_UserInfo.UserID , txtCurrentPass.Text))
            {
                e.Cancel = true;
                errorProviderCurrentPass.SetError(txtCurrentPass,
                    "This password is not found");
            }
            else
            {
                errorProviderCurrentPass.SetError(txtCurrentPass, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPass.Text != txtNewPass.Text)
            {
                e.Cancel = true;
                errorProviderConfirmPass.SetError(txtConfirmPass,
                    "This password is not match");
            }
            else
            {
                errorProviderConfirmPass.SetError(txtConfirmPass, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
