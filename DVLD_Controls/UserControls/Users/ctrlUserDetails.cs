using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Controls.UserControls.Users
{
    public partial class ctrlUserDetails : UserControl
    {
        public ctrlUserDetails()
        {
            InitializeComponent();
        }


        public void LoadDataToForm(clsPeople PersonInfo , clsUsers UserInfo)
        {
            ctrlPersonDetails1.LoadDataToControl(PersonInfo);
            lblUserID.Text = UserInfo.UserID.ToString();
            lblUserName.Text = UserInfo.UserName;
            lblIsActive.Text = (UserInfo.IsActive) ? "Yes" : "No";
        }
    }
}
