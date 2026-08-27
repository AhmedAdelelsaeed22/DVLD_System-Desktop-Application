using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;
using DVLD_System.Emails;
using MaterialSkin;
using MaterialSkin.Controls;

namespace DVLD_System.People
{
    public partial class FrmGetAllPeople : MaterialSkin.Controls.MaterialForm
    {
        public FrmGetAllPeople()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900, 
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private DataTable dtSourcePeople = clsPeople.GetAllPeople();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void DataGridViewHandlerWidth()
        {
            dgvAllPeople.DataSource = dtSourcePeople;

            dgvAllPeople.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllPeople.Columns["PersonID"].Width = 80;

            dgvAllPeople.Columns["NationalNo"].HeaderText = "National No";
            dgvAllPeople.Columns["NationalNo"].Width = 110;

            dgvAllPeople.Columns["FullName"].HeaderText = "Full Name";
            dgvAllPeople.Columns["FullName"].Width = 100;

            dgvAllPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvAllPeople.Columns["DateOfBirth"].Width = 110;

            dgvAllPeople.Columns["Gender"].HeaderText = "Gender";
            dgvAllPeople.Columns["Gender"].Width = 120;

            dgvAllPeople.Columns["Address"].HeaderText = "Address";
            dgvAllPeople.Columns["Address"].Width = 130;

            dgvAllPeople.Columns["Phone"].HeaderText = "Phone";
            dgvAllPeople.Columns["Phone"].Width = 140;

            dgvAllPeople.Columns["Email"].HeaderText = "Email";
            dgvAllPeople.Columns["Email"].Width = 150;


            dgvAllPeople.Columns["CountryName"].HeaderText = "Country Name";
            dgvAllPeople.Columns["CountryName"].Width = 160;

            dgvAllPeople.Columns["ImagePath"].HeaderText = "Image Path";
            dgvAllPeople.Columns["ImagePath"].Width = 170;

            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllPeople.BorderStyle = BorderStyle.None;
            dgvAllPeople.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllPeople.RowHeadersVisible = false;

            dgvAllPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllPeople.MultiSelect = false;
            dgvAllPeople.ReadOnly = true;
            dgvAllPeople.EnableHeadersVisualStyles = false;

            dgvAllPeople.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllPeople.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllPeople.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllPeople.DefaultCellStyle.BackColor = Color.White;
            dgvAllPeople.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllPeople.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllPeople.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FrmGetAllPeople_Load(object sender, EventArgs e)
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
            if(cbFilter.SelectedIndex != 0)
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
                FilterColumn = "PersonID";
                dtSourcePeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
            else if (cbFilter.SelectedIndex == 2)
            {
                FilterColumn = "NationalNo";
                dtSourcePeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text);
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
                dtSourcePeople.DefaultView.RowFilter = "";
                RecordsNumber();
                return;
            }
        }


        private void ReloadData()
        {
            dtSourcePeople = clsPeople.GetAllPeople();
            dgvAllPeople.DataSource = dtSourcePeople;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddOrEditPerson AddForm = new FrmAddOrEditPerson();
            AddForm.ShowDialog();
            ReloadData();
            RecordsNumber();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddOrEditPerson AddForm = new FrmAddOrEditPerson();
            AddForm.ShowDialog();
            ReloadData();
            RecordsNumber();
        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddOrEditPerson EditForm = 
                new FrmAddOrEditPerson(Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value));
            EditForm.ShowDialog();
            ReloadData();
            RecordsNumber();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonDetails ShowDetails = new FrmPersonDetails
                (Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value));
            ShowDetails.ShowDialog();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Are you sure delete this person" , "Warning" 
                    ,MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (clsPeople.DeletePerson
                    (Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value)))
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

        private void btnInbox_Click(object sender, EventArgs e)
        {
            ManagementEmails InboxForm = new ManagementEmails();
            InboxForm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEmail SendForm = new FrmAddEmail
                (Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value));
            SendForm.ShowDialog();
        }
    }
}
