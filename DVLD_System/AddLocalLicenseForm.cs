using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using System.IO;
using DVLD_Countries;
using DVLD_Application;
using DVLD_DrivingLicenseApp;
using DVLD_ApplicationNumberTwo;
using System.Security.Cryptography;

namespace DVLD_System
{
    public partial class AddLocalLicenseForm : Form
    {
        


        int _LDAppID;
        clsBusineesLayer _PersonInfo;
        string userNameLogin = "";

        public AddLocalLicenseForm(int LDAppID)
        {
            InitializeComponent();
           
            _LDAppID = LDAppID;
        }


        private void _DataLoad()
        {
            DataTable LicenseClasses = clsDrivingLicense.GetAllLicensesClasses();
            if (tabControl1.SelectedIndex == 1)
            {
                foreach (DataRow row in LicenseClasses.Rows)
                {
                    cbLicenseClass.Items.Add(row[0]);
                }
            }

            cbLicenseClass.SelectedIndex = 0;
            lblAppDate.Text = DateTime.Now.ToLongDateString();
            lblAppFees.Text = clsApplication.GetApplicationFeesForLocalLicense(1).ToString();
            lblCreatedBy.Text = UserName_usingInLogIn();
        }

        private void AddLocalLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlAddNewUser1.Finding += FindingPerson;
            ctrlAddNewUser1.AddNew += btnAddNewPerson;
            ctrlAddNewUser1.Edit += LinkbelEdit_Person;
            ctrlAddNewUser1.comboBoxFilteration = 0;
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
                MessageBox.Show(ex.Message, "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FindingPerson(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_PersonInfo != null)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("The feild searching is emptry!", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string UserName_usingInLogIn()
        {
            string path = @"C:\Users\NV\Desktop\Course 19\DVLD_System\bin\Debug\UsersLoginInfo\login_log.txt";
            


            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] parts = content.Split('|');
                userNameLogin = parts[0].Trim();
                
            }

                return userNameLogin;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsApplication2 App = new clsApplication2();
                if (ctrlAddNewUser1.comboBoxFilteration == 0)
                {

                    App.ApplicationPersonID = ctrlAddNewUser1.txtFindValueInt;
                }
                else
                {
                    App.ApplicationPersonID = clsBusineesLayer.GetPersonIDUsingNationalNo(ctrlAddNewUser1.txtFindValueNationalNo);
                }

                App.PaidFees = Convert.ToDouble(lblAppFees.Text);
                App.CreatedByUserID = clsApplication2.GetIDUserUsingLogIn(lblCreatedBy.Text);


                if (clsApplication2.IsExistLocalDrivingInSystem(cbLicenseClass.Text, ctrlAddNewUser1.txtFindValueNationalNo))
                {
                    MessageBox.Show("This nationality number already have this application", "Error"
                     , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    App.Save();
                }

                clsDrivingLicense NewDrivingLicense = new clsDrivingLicense();
                NewDrivingLicense.ApplicationID = App.ApplicationID;
                NewDrivingLicense.LicenseClassID = clsDrivingLicense.GetIDUsingLicenseClass(cbLicenseClass.Text);


                if (NewDrivingLicense.Save())
                {
                    MessageBox.Show("Save is Successfully", "Successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblAppIdValue.Text = NewDrivingLicense.LocalDrivingLicenseID.ToString();
                }
                else
                {
                    MessageBox.Show("Save is Not Successfully", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
