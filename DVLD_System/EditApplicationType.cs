using DVLD_Application;
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
    public partial class EditApplicationType : Form
    {

        int _ApplicationID;
        clsApplication _App;

        public EditApplicationType(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _DataLoad()
        {
            _App = clsApplication.FindApplicationUsingID(_ApplicationID);
            lblIDValue.Text = _App.ApplicationID.ToString();
            txtAppTitle.Text = _App.ApplicationTitle;
            txtAppFees.Text = _App.ApplicationFees.ToString();
        }

        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _App = new clsApplication();
            _App.ApplicationID = Convert.ToInt32(lblIDValue.Text);
            _App.ApplicationTitle = txtAppTitle.Text;
            _App.ApplicationFees = Convert.ToDouble(txtAppFees.Text);

            if (_App.Save())
            {
                MessageBox.Show("Save Is Successfully" , "Successfully" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Somthing Error", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
