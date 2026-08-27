using DVLD_BussinessLayer;
using DVLD_System.People;
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
using static DVLD_System.People.FrmAddOrEditPerson;

namespace DVLD_System.L.D_License
{
    public partial class FrmNewLocalDriverLicense : MaterialSkin.Controls.MaterialForm
    {


        clsApplication _ApplicationInfo;
        clsLocalDrivingLicenseApplication _LocalDriverLicenseInfo;
        clsPeople _PersonInfo;

        public FrmNewLocalDriverLicense()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void EventsHandler()
        {
            ctrlPersonSearch1.SelectFirstEelementInFlterBox();
            ctrlPersonSearch1.TextKeyPress += Text_KeyPress;
            ctrlPersonSearch1.ButtonAdd += btnAddPerson_Click;
            ctrlPersonSearch1.ButtonSearch += btnSearchPerson_Click;
            ctrlPersonDetails1.LinkEdit += linkLabelEditPersonalInfo_LinkClicked;
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
                MessageBox.Show("The Filter Field Is Empty", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNewLocalDriverLicense_Load(object sender, EventArgs e)
        {
            EventsHandler();
            _DataLoad();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_PersonInfo == null)
            {
                MessageBox.Show("Somethings Error!", "Error"
                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                tabControl1.SelectedIndex++;
            }
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

        private void _DataLoad()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            customLicenseClasses1.LoadDataLicenseClasses();
            customLicenseClasses1.SelectFirstElement();
            lblAppFees.Text = clsApplicationType.GetApplicationFees(1).ToString();
            lblCreatedBy.Text = GetCurrentUserName();
        }

        private void _LoadDataApplicationToObject(clsApplication ApplicationInfo)
        {
            ApplicationInfo.ApplicantPersonID = _PersonInfo.PersonID;
            ApplicationInfo.ApplicationDate = Convert.ToDateTime(lblAppDate.Text);
            ApplicationInfo.ApplicationStatus = 1;
            ApplicationInfo.ApplicationTypeID = 1;
            ApplicationInfo.PaidFees = Convert.ToDecimal(lblAppFees.Text);
            ApplicationInfo.CreatedByUserID = clsUsers.GetUserIDUsingUserName(lblCreatedBy.Text);
        }

        private void _LoadDataLocalDriverLicenseToObject(clsLocalDrivingLicenseApplication LocalDriverLicenseInfo)
        {
            LocalDriverLicenseInfo.ApplicationID = _ApplicationInfo.ApplicationID;
            LocalDriverLicenseInfo.LicenseClassID = clsLicenseClass.GetLicenseClassIDByClassName_SP
                (customLicenseClasses1.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            

            if (clsLocalDrivingLicenseApplication.IsExistClassApplicationWithStatusNew
                (_PersonInfo.NationalNo , customLicenseClasses1.Text) || 
                clsLocalDrivingLicenseApplication.IsExistClassApplicationWithStatusCompleted
                (_PersonInfo.NationalNo, customLicenseClasses1.Text))
            {
                MessageBox.Show("This Application Is Already Exist For This Person!" , "Erorr" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            else
            {
                _ApplicationInfo = new clsApplication();
                _LoadDataApplicationToObject(_ApplicationInfo);
                if (_ApplicationInfo.Save())
                {
                    _LocalDriverLicenseInfo = new clsLocalDrivingLicenseApplication();
                    _LoadDataLocalDriverLicenseToObject(_LocalDriverLicenseInfo);
                    if (_LocalDriverLicenseInfo.Save())
                    {
                        MessageBox.Show("Saving Is Successfully", "Successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblID.Text = _LocalDriverLicenseInfo.LocalDrivingLicenseApplicationID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Saving Is Not Successfully", "Error"
                                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
