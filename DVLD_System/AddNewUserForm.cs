using DVLD_Business;
using DVLD_Countries;
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
    public partial class AddNewUserForm : Form
    {
        public enum enMode {Add = 0 , Update = 1}
        private enMode _Mode;

        int _UserID = -1;

        public AddNewUserForm(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if(_UserID == -1)
                _Mode = enMode.Add;
            else
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Edit Users Screen";
            }
        }


        clsBusineesLayer _PersonInfo;
        clsUsers _UserInfo;


        private void _DataLoad()
        {

            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add New User";
                _UserInfo = new clsUsers();
                return;
            }


            _UserInfo = clsUsers.FindUser(_UserID);


            if (_UserInfo != null)
            {
                ctrlAddNewUser1.UnEnabled();
                clsBusineesLayer data = clsBusineesLayer.FindPersonUsingPersonID(_UserInfo.PersonID);
                ctrlAddNewUser1.LoadPersonInfo(data);
                ctrlAddNewUser1.txtFindValueInt = data.PersonID;

                lblUserIDValue.Text = _UserInfo.UserID.ToString();
                txtUserName.Text = _UserInfo.UserName;
                txtPassword.Text = _UserInfo.Password;
                if (_UserInfo.IsActive == 0)
                {
                    cbIsActive.Checked = false;
                }
                else
                {
                    cbIsActive.Checked = true;
                }
                txtConfirmPass.Text = txtPassword.Text;
            }
        }

        public void btn_FindClick(object sender, EventArgs e)
        {
            
            try
            {
                if (ctrlAddNewUser1.comboBoxFilteration == 0)
                {
                    _PersonInfo = clsBusineesLayer.FindPersonUsingPersonID(ctrlAddNewUser1.txtFindValueInt);

                    if (_PersonInfo != null)
                    {
                        ctrlAddNewUser1.LoadPersonInfo(_PersonInfo);
                    }
                    else
                    {
                        MessageBox.Show("This person is not found", "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (ctrlAddNewUser1.comboBoxFilteration == 1)
                {
                    _PersonInfo = clsBusineesLayer.FindPersonUsingNationalNo(ctrlAddNewUser1.txtFindValueNationalNo);

                    if (_PersonInfo != null)
                    {
                        ctrlAddNewUser1.LoadPersonInfo(_PersonInfo);
                    }
                    else
                    {
                        MessageBox.Show("This person is not found", "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewUserForm_Load(object sender, EventArgs e)
        {
            ctrlAddNewUser1.comboBoxFilteration = 0;
            ctrlAddNewUser1.Finding += btn_FindClick;
            ctrlAddNewUser1.AddNew += btnAddNewPerson;
            ctrlAddNewUser1.Edit += LinkbelEdit_Person;
            _DataLoad();


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsBusineesLayer.IsExistPersonInSystem(Convert.ToInt32(ctrlAddNewUser1.PersonID)))
                {
                    MessageBox.Show("This person is already User In system", "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabControl1.SelectedIndex = 1;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == enMode.Add)
                {
                    _UserInfo.PersonID = _PersonInfo.PersonID;
                }
                else
                {
                    _UserInfo.PersonID = _UserInfo.PersonID;
                }
                    _UserInfo.UserName = txtUserName.Text;
                _UserInfo.Password = txtPassword.Text;
                if (cbIsActive.Checked)
                    _UserInfo.IsActive = 1;
                else
                    _UserInfo.IsActive = 0;


                if (_UserInfo.Save())
                {
                    MessageBox.Show("Save is successfully", "Successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save is not successfully", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblTitle.Text = "Edit User Screen";
                lblUserIDValue.Text = Convert.ToString(_UserInfo.UserID);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProviderUserName.SetError(txtUserName, "This faild mustn`t be emptry");
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
                errorProviderPassword.SetError(txtPassword, "This faild mustn`t be emptry");
            }
            else
            {
                errorProviderPassword.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPass.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProviderConfirmPass.SetError(txtConfirmPass, "Must be match password");
            }
            else
            {
                errorProviderConfirmPass.SetError(txtConfirmPass, "");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _DataLoad();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAddNewPerson(object sender, EventArgs e)
        {
            PersonInfo PersonForm = new PersonInfo(-1);
            PersonForm.DataReturned += frm_DataReturned;
            PersonForm.ShowDialog();
            
        }


        private void frm_DataReturned(int PersonID)
        {
            ctrlAddNewUser1.txtFindValueInt = PersonID;
            _PersonInfo = clsBusineesLayer.FindPersonUsingPersonID(PersonID);
            ctrlAddNewUser1.LoadPersonInfo(_PersonInfo);
        }


        private void LinkbelEdit_Person(object sender, EventArgs e)
        {
            try
            {
                PersonInfo Form = new PersonInfo(ctrlAddNewUser1.txtFindValueInt);
                Form.ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message , "Error" 
                    , MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            
        }
    }
}
