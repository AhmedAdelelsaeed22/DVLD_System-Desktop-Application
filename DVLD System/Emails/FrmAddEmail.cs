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

namespace DVLD_System.Emails
{
    public partial class FrmAddEmail : MaterialSkin.Controls.MaterialForm
    {

        clsEmails _EmailInfo;
        int _PersonID;

        public FrmAddEmail(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void _DataLoad()
        {
            _EmailInfo = new clsEmails();
        }

        private void FrmAddEmail_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }


        private void _LoadDataToObject(clsEmails EmailInfo)
        {
            _EmailInfo.EmailRequeist = txtEmailRequiest.Text;
            _EmailInfo.EmailResponse = txtEmailRespone.Text;
            _EmailInfo.Message = txtMessage.Text;
            _EmailInfo.PersonID = _PersonID;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _LoadDataToObject(_EmailInfo);
            if (_EmailInfo.Save())
            {
                MessageBox.Show("Send Is Successfully", "Successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblEmailID.Text = _EmailInfo.EmailID.ToString(); 
            }
            else
            {
                MessageBox.Show("Erorr Submit", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
