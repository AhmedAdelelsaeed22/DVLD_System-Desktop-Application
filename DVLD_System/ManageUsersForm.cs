using DVLD_Business;
using DVLD_Users;
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
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            dgvAllUsers.DataSource = clsBusineesLayer.GetAllUsers();
            lblRecordNumber.Text = clsBusineesLayer.GetAllRecordsForUsers().ToString();
            cbFilterType.SelectedIndex = 0;
            cbActive.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshData()
        {
            dgvAllUsers.DataSource = clsBusineesLayer.GetAllUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewUserForm addusersForm = new AddNewUserForm(-1);
            addusersForm.ShowDialog();
            _RefreshData();
        }


        private void _ApplyFilter()
        {
            DataTable Data = new DataTable();

          
            if (cbFilterType.SelectedIndex == 1)
            {
                txtFilter.Visible = true;
                cbActive.Visible = false;

                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                    Data = clsUsers.GetUsersByUserID(Convert.ToInt32(txtFilter.Text));
                    dgvAllUsers.DataSource = Data;
                }
            }
           
            else if (cbFilterType.SelectedIndex == 2)
            {
                txtFilter.Visible = false;
                cbActive.Visible = true;

                byte Active = 0;

                if (cbActive.SelectedIndex == 0) Active = 1;
                if (cbActive.SelectedIndex == 1) Active = 1;   // Active
                if (cbActive.SelectedIndex == 2) Active = 0;   // Not Active

                Data = clsUsers.GetUsersByIsActive(Active);
                dgvAllUsers.DataSource = Data;
            }
        }


        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUserForm addusersForm = new AddNewUserForm(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            addusersForm.ShowDialog();
            _RefreshData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUserForm addusersForm = new AddNewUserForm(-1);
            addusersForm.ShowDialog();
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Deleted This User" , "Warning" 
                , MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUsers.DeleteUserFromSystem(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("User Is Deleted", "Successfully"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }
                else
                {
                    MessageBox.Show("This user can not delete", "Error"
               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changepassform = new ChangePassword(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            changepassform.ShowDialog();
            _RefreshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetailsForm UserdetailsForm = new UserDetailsForm(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            UserdetailsForm.ShowDialog();
        }
    }
}
