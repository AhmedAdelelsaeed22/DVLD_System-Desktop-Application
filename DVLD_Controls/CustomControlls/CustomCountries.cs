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

namespace DVLD_Controls
{
    public partial class CustomCountries : ComboBox
    {
        public CustomCountries()
        {
            InitializeComponent();
        }


        public void SelectElementOne()
        {
            this.SelectedIndex = 50;
        }


        public void LoadDataCountries()
        {
            DataTable dtCountries = clsCountries.GetAllCountries();
            foreach (DataRow item in dtCountries.Rows) 
            {
                this.Items.Add(item["CountryName"]);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
