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

namespace DVLD_System.Users
{
    public partial class FrmManagementUsers : MaterialSkin.Controls.MaterialForm
    {
        public FrmManagementUsers()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }

        private DataTable dtSourceUsers = clsUsers.GetAllUsers();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllUsers.Rows.Count.ToString();
        }


        private void DataGridViewHandlerWidth()
        {
            dgvAllUsers.DataSource = dtSourceUsers;

            dgvAllUsers.Columns["UserID"].HeaderText = "User ID";
            dgvAllUsers.Columns["UserID"].Width = 80;

            dgvAllUsers.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllUsers.Columns["PersonID"].Width = 110;

            dgvAllUsers.Columns["FName"].HeaderText = "Full Name";
            dgvAllUsers.Columns["FName"].Width = 100;

            dgvAllUsers.Columns["UserName"].HeaderText = "User Name";
            dgvAllUsers.Columns["UserName"].Width = 110;

            dgvAllUsers.Columns["IsActive"].HeaderText = "Is Active";
            dgvAllUsers.Columns["IsActive"].Width = 120;

            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllUsers.BorderStyle = BorderStyle.None;
            dgvAllUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllUsers.RowHeadersVisible = false;
            
            dgvAllUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllUsers.MultiSelect = false;
            dgvAllUsers.ReadOnly = true;
            dgvAllUsers.EnableHeadersVisualStyles = false;
            
            dgvAllUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllUsers.DefaultCellStyle.BackColor = Color.White;
            dgvAllUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllUsers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllUsers.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FrmManagementUsers_Load(object sender, EventArgs e)
        {
            DataGridViewHandlerWidth();
            DataGridViewHandlerStyle();
            RecordsNumber();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
            }
        }


        private void ApplyFilter()
        {
            string FilterColumn = "";
            if (cbFilter.SelectedIndex == 1)
            {
                FilterColumn = "UserID";
                dtSourceUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
            else if (cbFilter.SelectedIndex == 2)
            {
                FilterColumn = "PersonID";
                dtSourceUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }else if (cbFilter.SelectedIndex == 3)
            {
                FilterColumn = "UserName";
                dtSourceUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                ApplyFilter();
            }
            else
            {
                dtSourceUsers.DefaultView.RowFilter = "";
                RecordsNumber();
                return;
            }
        }

        private void ReloadData()
        {
            dtSourceUsers = clsUsers.GetAllUsers();
            dgvAllUsers.DataSource = dtSourceUsers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddOrEditUser AddUser = new FrmAddOrEditUser();
            AddUser.ShowDialog();
            ReloadData();
            RecordsNumber();
        }

        private void addStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmAddOrEditUser AddUser = new FrmAddOrEditUser();
            AddUser.ShowDialog();
            ReloadData();
            RecordsNumber();
        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);
            int PersonID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[1].Value);

            FrmAddOrEditUser UpdateUser = new FrmAddOrEditUser
                (UserID , PersonID);
            UpdateUser.ShowDialog();
            ReloadData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserDetails userDetails = new FrmUserDetails
                (Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            userDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword ChangePass = new FrmChangePassword
                (Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            ChangePass.ShowDialog();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete this user", "Warning"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUsers.DeleteUser
                (Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Delete Is Successfully", "Successfully", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                    ReloadData();
                    RecordsNumber();
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Error", MessageBoxButtons.OK
                  , MessageBoxIcon.Error);
                }
            }
        }
    }
}
