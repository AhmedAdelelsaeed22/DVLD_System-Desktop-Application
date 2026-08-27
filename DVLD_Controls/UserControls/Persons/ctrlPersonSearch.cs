using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Controls.UserControls
{
    public partial class ctrlPersonSearch : UserControl
    {
        public ctrlPersonSearch()
        {
            InitializeComponent();
        }

        
        public string TextFilter
        {
            get { return txtFilter.Text; }
            set { txtFilter.Text = value; }
        }


        public event EventHandler<EventArgs> ButtonSearch;
        public event EventHandler<EventArgs> ButtonAdd;
        public event EventHandler<KeyPressEventArgs> TextKeyPress;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ButtonSearch?.Invoke(this, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ButtonAdd?.Invoke(this, e);
        }


        public int cbFilterIndexVal()
        {
            return cbFilter.SelectedIndex;
        }


        public void SelectFirstEelementInFlterBox()
        {
            cbFilter.SelectedIndex = 0;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress?.Invoke(this, e);
        }

    }
}
