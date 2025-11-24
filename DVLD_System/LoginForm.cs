using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DVLD_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsBusineesLayer.IsExistUsers(txtUserName.Text, txtPassword.Text))
            {
                
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();

                string folder = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo";
                string logPath = Path.Combine(folder, "login_log.txt");

                Directory.CreateDirectory(folder);


                string logData = $"{userName}|{password}|{cbremeber.Checked}";

                File.WriteAllText(logPath, logData);

                
                Main MainFor = new Main();
                MainFor.Show();


                this.Hide();
                
            }
            else
            {
                MessageBox.Show("UserName Or Password Invalid" , "Error" 
                    , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo\login_log.txt";

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] parts = content.Split('|');

                if (parts.Length >= 3)
                {
                    bool remember = bool.Parse(parts[2].Trim());
                    if (remember)
                    {
                        cbremeber.Checked = remember;

                        txtUserName.Text = parts[0].Trim();
                        txtPassword.Text = parts[1].Trim();
                    }
                }
            }
        }
    }
}
