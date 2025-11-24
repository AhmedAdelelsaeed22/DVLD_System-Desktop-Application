using DVLD_TestTypes;
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
    public partial class EditTestTypes : Form
    {
        int _TestID;
        clsTestType _TestInfo;
        public EditTestTypes(int testID)
        {
            InitializeComponent();
            _TestID = testID;
        }

        private void _DataLoad()
        {
            _TestInfo = clsTestType.FindTestTypeUsingID(_TestID);
            lblIDValue.Text = _TestInfo.TestTypeID.ToString();
            txtTestTitle.Text = _TestInfo.TestTypeTitle;
            txtTestDesc.Text = _TestInfo.TestTypeDescription;
            txtTestFees.Text = _TestInfo.TestTypeFees.ToString();
        }

        private void EditTestTypes_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestInfo = new clsTestType();
            _TestInfo.TestTypeID = _TestID;
            _TestInfo.TestTypeTitle = txtTestTitle.Text;
            _TestInfo.TestTypeDescription = txtTestDesc.Text;
            _TestInfo.TestTypeFees = Convert.ToDouble(txtTestFees.Text);


            if (_TestInfo.Save())
            {
                MessageBox.Show("Save Is Successfully", "Successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Somthing Error", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
