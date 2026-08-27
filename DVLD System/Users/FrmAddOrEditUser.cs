using DVLD_BussinessLayer;
using DVLD_System.People;
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
using static DVLD_System.People.FrmAddOrEditPerson;

namespace DVLD_System.Users
{
    public partial class FrmAddOrEditUser : MaterialSkin.Controls.MaterialForm
    {

        public enum enMode { Add = 0, Update = 1 }
        private enMode _Mode;


        private int _UserID = -1;
        private int _PersonID = -1;


        clsPeople _PersonInfo;
        clsUsers _UserInfo;

        public FrmAddOrEditUser()
        {
            InitializeComponent();


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);

            _Mode = enMode.Add;
        }


        public FrmAddOrEditUser(int UserID , int PersonID)
        {
            InitializeComponent();


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);

            _UserID = UserID;
            _PersonID = PersonID;

            _Mode = enMode.Update;
        }


        private void EventsHandler()
        {
            ctrlPersonSearch1.SelectFirstEelementInFlterBox();
            ctrlPersonSearch1.TextKeyPress += Text_KeyPress;
            ctrlPersonSearch1.ButtonAdd += btnAddPerson_Click;
            ctrlPersonSearch1.ButtonSearch += btnSearchPerson_Click;
            ctrlPersonDetails1.LinkEdit += linkLabelEditPersonalInfo_LinkClicked;
        }

        private void FrmAddOrEditUser_Load(object sender, EventArgs e)
        {
            EventsHandler();
            _DataLoad();
        }


        private void btnSearchPerson_Click(object sender, EventArgs e) 
        {
            if (ctrlPersonSearch1.cbFilterIndexVal() == 0)
            {
                if (!string.IsNullOrEmpty(ctrlPersonSearch1.TextFilter))
                {
                    _PersonInfo = clsPeople.FindPerson(Convert.ToInt32(ctrlPersonSearch1.TextFilter));
                }

                if (_PersonInfo != null) 
                {
                    ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
                }
            }
            else
            {

                if (!string.IsNullOrEmpty(ctrlPersonSearch1.TextFilter))
                {
                    _PersonInfo = clsPeople.FindPersonUsingNationalNo(ctrlPersonSearch1.TextFilter);
                }
          
                if (_PersonInfo != null)
                {
                    ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
                }
            }
        }


        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddOrEditPerson AddPerson = new FrmAddOrEditPerson();
            AddPerson.PersonIDSent += RecivePersonID;
            AddPerson.ShowDialog();
        }


        private void RecivePersonID(object sender, SendPersonIDEvent e)
        {
            ctrlPersonSearch1.TextFilter = e.PersonID.ToString();

            _PersonInfo = clsPeople.FindPerson(e.PersonID);

            if (_PersonInfo != null) 
            {
                ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
            }
        }


        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ctrlPersonSearch1.cbFilterIndexVal() == 0)
            {
                // Allow numbers only
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


        private void linkLabelEditPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonInfo != null)
            {
                FrmAddOrEditPerson editPerson = new FrmAddOrEditPerson(_PersonInfo.PersonID);
                editPerson.ShowDialog();
            }
            else
            {
                MessageBox.Show("The Filter Field Is Empty" , "Error" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_PersonInfo == null)
            {
                MessageBox.Show("Somethings Error!", "Error"
                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUsers.IsExistUser(_PersonInfo.PersonID))
            {
                MessageBox.Show("This Person Is Already User In System!", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProviderUserName.SetError(txtUserName, "This Feild Is Empty!");
            }
            else
            {
                errorProviderUserName.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProviderPassword.SetError(txtPassword, "This Feild Is Empty!");
            }
            else
            {
                errorProviderPassword.SetError(txtPassword, "");
            }
        }

        private void txtCPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtCPassword.Text)
            {
                e.Cancel = true;
                errorProviderCPassword.SetError(txtCPassword, "This Feild Not Match Password!");
            }
            else
            {
                errorProviderCPassword.SetError(txtCPassword, "");
            }
        }


        private void _LoadDataToObject(clsUsers UserInfo)
        {
            UserInfo.PersonID = _PersonInfo.PersonID;
            UserInfo.UserName = txtUserName.Text;
            UserInfo.Password = txtPassword.Text;
            UserInfo.IsActive = cbIsActive.Checked;
        }


        private void _LoadDataToForm(clsUsers UserInfo)
        {
            lblUserID.Text = UserInfo.UserID.ToString();
            txtUserName.Text = UserInfo.UserName;
            txtPassword.Text = UserInfo.Password;
            txtCPassword.Text = UserInfo.Password;
            cbIsActive.Checked = UserInfo.IsActive;
        }


        private void _DataLoad()
        {
            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add New User";
                _UserInfo = new clsUsers();
                return;
            }

            groupBoxFIlter.Enabled = false;
            lblTitle.Text = "Update User";
            _PersonInfo = clsPeople.FindPerson(_PersonID);

            if (_PersonInfo != null)
            {
                ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
            }

            _UserInfo = clsUsers.FindUser(_UserID);

            if (_UserInfo != null) 
            {
                _LoadDataToForm(_UserInfo);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadDataToObject(_UserInfo);
            if (_UserInfo.Save())
            {
                MessageBox.Show("Saving Is Successfully" , "Successfully" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Information);
                lblUserID.Text = _UserInfo.UserID.ToString();
            }
            else
            {
                MessageBox.Show("Saving Is Not Successfully", "Error"
                                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
