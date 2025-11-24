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
    public partial class ManageTestType : Form
    {
        public ManageTestType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            dgvAllTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblRecordsValue.Text = clsTestType.GetCountRecordesTestTypes().ToString();
        }


        private void _ReferechData()
        {
            dgvAllTestTypes.DataSource = clsTestType.GetAllTestTypes();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTestTypes TestType = new EditTestTypes(Convert.ToInt32(dgvAllTestTypes.CurrentRow.Cells[0].Value));
            TestType.ShowDialog();
            _ReferechData();
        }
    }
}
