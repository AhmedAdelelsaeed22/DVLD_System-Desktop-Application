using DVLD_BussinessLayer;
using MaterialSkin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.LogIn
{
    public partial class FrmLoginScreen : MaterialSkin.Controls.MaterialForm
    {
        public FrmLoginScreen()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void SaveLoginData()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\SOFTWARE\DVLDAPP"))
            {
                key.SetValue("Username", txtUserName.Text);
                key.SetValue("Password", txtPassword.Text);
                key.SetValue("Remember", cbRemember.Checked);
            }
            
        }


        private void GetLoginData()
        {
            using (RegistryKey key = 
                Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\SOFTWARE\DVLDAPP"))
            {
                string username = "";
                string password = "";
                bool remember = false;

                if (key != null)
                {
                    username = key.GetValue("Username", "").ToString();
                    password = key.GetValue("Password", "").ToString();
                    remember = Convert.ToBoolean(key.GetValue("Remember", ""));
                    if (remember)
                    {
                        txtUserName.Text = username;
                        txtPassword.Text = password;
                        cbRemember.Checked = remember;
                    }
                }
            }
            
        }

        private void FrmLoginScreen_Load(object sender, EventArgs e)
        {
            GetLoginData();
        }

        private void btnLogIn_Click_1(object sender, EventArgs e)
        {
            if (clsUsers.CheckLoginInfo(txtUserName.Text, txtPassword.Text))
            {
                SaveLoginData();
                FrmMain MainForm = new FrmMain();
                MainForm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UserName/Password InValid", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
