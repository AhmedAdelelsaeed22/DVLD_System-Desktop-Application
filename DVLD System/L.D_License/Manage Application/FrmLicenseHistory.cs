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

namespace DVLD_System.L.D_License.Manage_Application
{
    public partial class FrmLicenseHistory : MaterialSkin.Controls.MaterialForm
    {

        private clsLocalDrivingLicenseApplication _LDAppInfo;
        private clsApplication _ApplicationInfo;
        private clsPeople _PersonInfo;
        private int _LDAppID;

        public FrmLicenseHistory(int lDAppID)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
            _LDAppID = lDAppID;
        }


        private void DataLoad()
        {
            ctrlPersonDetails1.LinkEdit += linkLabelEditPersonalInfo_LinkClicked;
            _LDAppInfo = clsLocalDrivingLicenseApplication.Find(_LDAppID);
            if (_LDAppInfo != null) 
            {
                _ApplicationInfo = clsApplication.Find(_LDAppInfo.ApplicationID);
                if( _ApplicationInfo != null)
                {
                    _PersonInfo = clsPeople.FindPerson(_ApplicationInfo.ApplicantPersonID);
                    ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
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

        private void FrmLicenseHistory_Load(object sender, EventArgs e)
        {
            DataLoad();
            DataGridViewHandlerWidth();
            DataGridViewHandlerStyle();
            RecordsNumber();
        }


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvLocalLicense.Rows.Count.ToString();
        }

        private void DataGridViewHandlerWidth()
        {

            DataTable dtSourceLocalLicense = clsLicense.GetLicensesByApplicationID(_ApplicationInfo.ApplicationID);
                   
            dgvLocalLicense.DataSource = dtSourceLocalLicense;

            if (dtSourceLocalLicense.Rows.Count != 0)
            {
                dgvLocalLicense.Columns["LicenseID"].HeaderText = "Lic.ID";
                dgvLocalLicense.Columns["LicenseID"].Width = 120;

                dgvLocalLicense.Columns["ApplicationID"].HeaderText = "App ID";
                dgvLocalLicense.Columns["ApplicationID"].Width = 150;

                
                dgvLocalLicense.Columns["LicenseClass"].HeaderText = "Class Name";
                dgvLocalLicense.Columns["LicenseClass"].Width = 130;

                dgvLocalLicense.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvLocalLicense.Columns["IssueDate"].Width = 100;

                dgvLocalLicense.Columns["ExpirationDate"].HeaderText = "Ex Date";
                dgvLocalLicense.Columns["ExpirationDate"].Width = 110;

                dgvLocalLicense.Columns["IsActive"].HeaderText = "Is Active";
                dgvLocalLicense.Columns["IsActive"].Width = 120;
            }
        }

        private void DataGridViewHandlerStyle()
        {
            dgvLocalLicense.BorderStyle = BorderStyle.None;
            dgvLocalLicense.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLocalLicense.RowHeadersVisible = false;

            dgvLocalLicense.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocalLicense.MultiSelect = false;
            dgvLocalLicense.ReadOnly = true;
            dgvLocalLicense.EnableHeadersVisualStyles = false;

            dgvLocalLicense.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvLocalLicense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLocalLicense.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLocalLicense.DefaultCellStyle.BackColor = Color.White;
            dgvLocalLicense.DefaultCellStyle.ForeColor = Color.Black;
            dgvLocalLicense.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvLocalLicense.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
