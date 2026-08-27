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

namespace DVLD_System.ApplicationTestType
{
    public partial class FrmEditApplicationTestType : MaterialSkin.Controls.MaterialForm
    {

        clsApplicationTestType _ApplicationTestInfo;
        int _AppTestID;

        public FrmEditApplicationTestType(int AppTestID)
        {
            InitializeComponent();

            _AppTestID = AppTestID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void LoadDataToObject(clsApplicationTestType ApplicationTestInfo)
        {
            ApplicationTestInfo.TestTypeID = _AppTestID;
            ApplicationTestInfo.TestTypeTitle = txtTitle.Text;
            ApplicationTestInfo.TestTypeDescription = txtDescription.Text;
            ApplicationTestInfo.TestTypeFees = Convert.ToDecimal(txtFees.Text);
        }


        private void LoadDataToForm(clsApplicationTestType ApplicationTestInfo)
        {
            lblID.Text = ApplicationTestInfo.TestTypeID.ToString();
            txtTitle.Text = ApplicationTestInfo.TestTypeTitle;
            txtDescription.Text = ApplicationTestInfo.TestTypeDescription;
            txtFees.Text = ApplicationTestInfo.TestTypeFees.ToString();

        }


        private void DataLoad()
        {
            _ApplicationTestInfo = clsApplicationTestType.Find(_AppTestID);

            if (_ApplicationTestInfo != null)
            {
                LoadDataToForm(_ApplicationTestInfo);
            }
        }

        private void FrmEditApplicationTestType_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadDataToObject(_ApplicationTestInfo);
            if (_ApplicationTestInfo.Save())
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
