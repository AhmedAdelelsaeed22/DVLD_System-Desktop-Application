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

namespace DVLD_System.Drivers
{
    public partial class FrmManagmentDrivers : MaterialSkin.Controls.MaterialForm
    {
        public FrmManagmentDrivers()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private DataTable dtSourceDrivers =
            clsDrivers.GetAllDrivers();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllDrivers.Rows.Count.ToString();
        }

        private void DataGridViewHandlerWidth()
        {
            dgvAllDrivers.DataSource = dtSourceDrivers;

            dgvAllDrivers.Columns["DriverID"].HeaderText = "Driver ID";
            dgvAllDrivers.Columns["DriverID"].Width = 130;

            dgvAllDrivers.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllDrivers.Columns["PersonID"].Width = 120;

            dgvAllDrivers.Columns["CreatedByUserID"].HeaderText = "CreatedBy";
            dgvAllDrivers.Columns["CreatedByUserID"].Width = 130;

            dgvAllDrivers.Columns["CreatedDate"].HeaderText = "CreatedDate";
            dgvAllDrivers.Columns["CreatedDate"].Width = 140;

            cbFilter.SelectedIndex = 0;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllDrivers.BorderStyle = BorderStyle.None;
            dgvAllDrivers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllDrivers.RowHeadersVisible = false;

            dgvAllDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllDrivers.MultiSelect = false;
            dgvAllDrivers.ReadOnly = true;
            dgvAllDrivers.EnableHeadersVisualStyles = false;

            dgvAllDrivers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllDrivers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllDrivers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllDrivers.DefaultCellStyle.BackColor = Color.White;
            dgvAllDrivers.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllDrivers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllDrivers.DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        

        private void ApplyFilter()
        {
            string FilterColumn = "";
            if (cbFilter.SelectedIndex == 1)
            {
                FilterColumn = "DriverID";
                dtSourceDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                RecordsNumber();
            }
            
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                ApplyFilter();
            }
            else
            {
                dtSourceDrivers.DefaultView.RowFilter = "";
                RecordsNumber();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmManagmentDrivers_Load(object sender, EventArgs e)
        {
            DataGridViewHandlerWidth();
            DataGridViewHandlerStyle();
            RecordsNumber();
        }
    }
}
