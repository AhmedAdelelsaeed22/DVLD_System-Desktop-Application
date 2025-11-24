using DVLD_Business;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Users;

namespace DVLD_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageMentPeople manage = new ManageMentPeople();
            manage.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersForm Users = new ManageUsersForm();
            Users.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo\login_log.txt";
            string UserName = "";

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] parts = content.Split('|');
                UserName = parts[0].Trim();
               
            }

            int UserID = clsUsers.UserIDUsingInCurrentLogin(UserName);

            UserDetailsForm userDetailsForm = new UserDetailsForm(UserID);
            userDetailsForm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo\login_log.txt";
            string UserName = "";

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] parts = content.Split('|');
                UserName = parts[0].Trim();

            }

            int UserID = clsUsers.UserIDUsingInCurrentLogin(UserName);

            ChangePassword changePasswordForm = new ChangePassword(UserID);
            changePasswordForm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes appForm = new ManageApplicationTypes();
            appForm.ShowDialog();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestType TestType = new ManageTestType();
            TestType.ShowDialog();
        }

        private void loalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLocalLicenseForm licenseForm = new AddLocalLicenseForm(-1);
            licenseForm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDrivingLicenseApp appForm = new ManageLocalDrivingLicenseApp();
            appForm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDriversForm driversForm = new ShowDriversForm();
            driversForm.ShowDialog();
        }
    }
}
