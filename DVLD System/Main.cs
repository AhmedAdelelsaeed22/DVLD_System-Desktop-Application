using DVLD_BussinessLayer;
using DVLD_System.ApplicationLicense;
using DVLD_System.ApplicationTestType;
using DVLD_System.Drivers;
using DVLD_System.L.D_License;
using DVLD_System.L.D_License.Manage_Application;
using DVLD_System.LogIn;
using DVLD_System.People;
using DVLD_System.Users;
using MaterialSkin;
using MaterialSkin.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DVLD_System
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void peopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGetAllPeople PeopleForm = new FrmGetAllPeople();
            PeopleForm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagementUsers frmManagementUsers = new FrmManagementUsers();
            frmManagementUsers.ShowDialog();
        }


        private string GetCurrentUserName()
        {
            string username = "";
            using (RegistryKey key =
                Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\SOFTWARE\DVLDAPP"))
            {
                if (key != null)
                {
                    username = key.GetValue("Username", "").ToString();
                }
            }

            return username;

        }

        private int UserID = -1;

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = GetCurrentUserName();
            UserID = clsUsers.GetUserIDUsingUserName(userName);

            FrmUserDetails CurrentUserDetails = new FrmUserDetails(UserID);
            CurrentUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = GetCurrentUserName();
            UserID = clsUsers.GetUserIDUsingUserName(userName);

            FrmChangePassword ChangeCurrentPassword = new FrmChangePassword(UserID);
            ChangeCurrentPassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmLoginScreen loginScreen = new FrmLoginScreen();
            loginScreen.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageAppType manageAppTypes = new FrmManageAppType();
            manageAppTypes.ShowDialog();
        }

        private void manageApplicationTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTestType frmManageTestType = new FrmManageTestType();
            frmManageTestType.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewLocalDriverLicense newLocalDriverLicense = new FrmNewLocalDriverLicense();
            newLocalDriverLicense.ShowDialog();
        }

        private void localDriverLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocalDriverLicense manageLocalDriverLicense = new FrmManageLocalDriverLicense();
            manageLocalDriverLicense.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagmentDrivers frmManagmentDrivers = new FrmManagmentDrivers();
            frmManagmentDrivers.ShowDialog();
        }
    }
}
