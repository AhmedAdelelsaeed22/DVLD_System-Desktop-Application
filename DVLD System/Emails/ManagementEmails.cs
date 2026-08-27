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
    public partial class ManagementEmails : MaterialSkin.Controls.MaterialForm
    {
        public ManagementEmails()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private DataTable dtSourceEmails = clsEmails.GetAllEmails();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllEmails.Rows.Count.ToString();
        }


        private void DataGridViewHandlerWidth()
        {
            dgvAllEmails.DataSource = dtSourceEmails;

            dgvAllEmails.Columns["EmailID"].HeaderText = "Email ID";
            dgvAllEmails.Columns["EmailID"].Width = 80;
            
            dgvAllEmails.Columns["EmailRequeist"].HeaderText = "Email Requeist";
            dgvAllEmails.Columns["EmailRequeist"].Width = 110;
            
            dgvAllEmails.Columns["EmailResponse"].HeaderText = "Email Response";
            dgvAllEmails.Columns["EmailResponse"].Width = 100;
            
            dgvAllEmails.Columns["Message"].HeaderText = "Message";
            dgvAllEmails.Columns["Message"].Width = 110; 

            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllEmails.BorderStyle = BorderStyle.None;
            dgvAllEmails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllEmails.RowHeadersVisible = false;

            dgvAllEmails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllEmails.MultiSelect = false;
            dgvAllEmails.ReadOnly = true;
            dgvAllEmails.EnableHeadersVisualStyles = false;

            dgvAllEmails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllEmails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllEmails.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllEmails.DefaultCellStyle.BackColor = Color.White;
            dgvAllEmails.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllEmails.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllEmails.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void ManagementEmails_Load(object sender, EventArgs e)
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
                FilterColumn = "EmailID";
                dtSourceEmails.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
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
                dtSourceEmails.DefaultView.RowFilter = "";
                RecordsNumber();
                return;
            }
        }
    
    

    }
}
