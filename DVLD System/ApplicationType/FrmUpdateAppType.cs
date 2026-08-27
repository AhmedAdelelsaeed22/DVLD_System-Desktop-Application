using DVLD_BussinessLayer;
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

namespace DVLD_System.ApplicationLicense
{
    public partial class FrmUpdateAppType : MaterialSkin.Controls.MaterialForm
    {

        clsApplicationType _ApplicationInfo;
        int _AppID;

        public FrmUpdateAppType(int AppID)
        {
            InitializeComponent();

            _AppID = AppID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void LoadDataToObject(clsApplicationType ApplicationInfo)
        {
            ApplicationInfo.ApplicationTypeID = _AppID;
            ApplicationInfo.ApplicationTypeTitle = txtTitle.Text;
            ApplicationInfo.ApplicationFees = Convert.ToDecimal(txtFees.Text);
        }


        private void LoadDataToForm(clsApplicationType ApplicationInfo)
        {
            lblID.Text = ApplicationInfo.ApplicationTypeID.ToString();
            txtTitle.Text = ApplicationInfo.ApplicationTypeTitle;
            txtFees.Text = ApplicationInfo.ApplicationFees.ToString();

        }


        private void DataLoad()
        {
            _ApplicationInfo = clsApplicationType.Find(_AppID);

            if (_ApplicationInfo != null) 
            {
                LoadDataToForm(_ApplicationInfo);
            }
        }

        private void FrmUpdateAppType_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadDataToObject(_ApplicationInfo);
            if (_ApplicationInfo.Save())
            {
                MessageBox.Show("Save Successfully", "Successfully"
                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erorr Saving", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
