using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Controls.CustomControlls
{
    public partial class CustomLicenseClasses : ComboBox
    {
        public CustomLicenseClasses()
        {
            InitializeComponent();
        }

        public void LoadDataLicenseClasses()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow item in dtLicenseClasses.Rows)
            {
                this.Items.Add(item["ClassName"]);
            }
        }


        public void SelectFirstElement()
        {
            this.SelectedIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
