using DVLD_Business;
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
    public partial class ManageMentPeople : Form
    {
        public ManageMentPeople()
        {
            InitializeComponent();
        }


        private void _RefereshData()
        {
            dgvAllPersons.DataSource = clsBusineesLayer.GetAllPersons();
        }


        private void _FilterationUsingID()
        {

            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                _RefereshData();
            }
            else
            {
                clsBusineesLayer person = clsBusineesLayer.FindPersonUsingPersonID(Convert.ToInt32(txtFilter.Text));
                if (person != null)
                {

                    List<clsBusineesLayer> personsList = new List<clsBusineesLayer> { person };

                    dgvAllPersons.DataSource = personsList;
                }
                else
                {
                    dgvAllPersons.DataSource = null;
                    dgvAllPersons.Rows.Clear();
                }
            }
        }


        private void _FilterationUsingNationalNo()
        {

            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                _RefereshData();
            }
            else
            {
                clsBusineesLayer person = clsBusineesLayer.FindPersonUsingNationalNo(txtFilter.Text);
                if (person != null)
                {

                    List<clsBusineesLayer> personsList = new List<clsBusineesLayer> { person };

                    dgvAllPersons.DataSource = personsList;
                }
                else
                {
                    dgvAllPersons.DataSource = null;
                    dgvAllPersons.Rows.Clear();
                }
            }
        }


        private void ManageMentPeople_Load(object sender, EventArgs e)
        {
            dgvAllPersons.DataSource = clsBusineesLayer.GetAllPersons();
            lblRecordNumber.Text = clsBusineesLayer.GetCountRecords().ToString();
            cbFilterType.SelectedIndex = 0;
            if (cbFilterType.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(-1);
            personInfo.ShowDialog();
            _RefereshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetailsForm personDetailsForm = new PersonDetailsForm(Convert.ToInt32(dgvAllPersons.CurrentRow.Cells[0].Value));
            personDetailsForm.ShowDialog();
            _RefereshData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(-1);
            personInfo.ShowDialog();
            _RefereshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(Convert.ToInt32(dgvAllPersons.CurrentRow.Cells[0].Value));
            personInfo.ShowDialog();
            _RefereshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Deleted This Person" , "Warning" , MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsBusineesLayer.DeletePersonFromSystem(Convert.ToInt32(dgvAllPersons.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Deleted Is Successfully", "SuccessFully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                         _RefereshData();
                }
                else
                {
                    MessageBox.Show("Deleted Is Not Successfully", "Error"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fiture Is Not Found", "Warning"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fiture Is Not Found", "Warning"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cbFilterType.SelectedIndex != 0)
            txtFilter.Visible = true;
            else
            txtFilter.Visible = false;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterType.SelectedIndex == 1)
                _FilterationUsingID();
            else if (cbFilterType.SelectedIndex == 2)
                _FilterationUsingNationalNo();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterType.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; 
                }
            }
        }
    }
}
