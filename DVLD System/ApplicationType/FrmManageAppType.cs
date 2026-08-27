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

namespace DVLD_System.ApplicationLicense
{
    public partial class FrmManageAppType : MaterialSkin.Controls.MaterialForm
    {
        public FrmManageAppType()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }

        private DataTable dtSourceAppType = clsApplicationType.GetAllApplicationTypes();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllAppType.Rows.Count.ToString();
        }


        private void DataGridViewHandlerWidth()
        {
            dgvAllAppType.DataSource = dtSourceAppType;

            dgvAllAppType.Columns["ApplicationTypeID"].HeaderText = "ApplicationType ID";
            dgvAllAppType.Columns["ApplicationTypeID"].Width = 80;

            dgvAllAppType.Columns["ApplicationTypeTitle"].HeaderText = "ApplicationType Title";
            dgvAllAppType.Columns["ApplicationTypeTitle"].Width = 250;

            dgvAllAppType.Columns["ApplicationFees"].HeaderText = "Application Fees";
            dgvAllAppType.Columns["ApplicationFees"].Width = 100;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllAppType.BorderStyle = BorderStyle.None;
            dgvAllAppType.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllAppType.RowHeadersVisible = false;

            dgvAllAppType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllAppType.MultiSelect = false;
            dgvAllAppType.ReadOnly = true;
            dgvAllAppType.EnableHeadersVisualStyles = false;

            dgvAllAppType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllAppType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllAppType.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllAppType.DefaultCellStyle.BackColor = Color.White;
            dgvAllAppType.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllAppType.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllAppType.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void ReloadData()
        {
            dtSourceAppType = clsApplicationType.GetAllApplicationTypes();
            dgvAllAppType.DataSource = dtSourceAppType;
        }

        private void FrmManageAppTypes_Load(object sender, EventArgs e)
        {
            DataGridViewHandlerWidth();
            DataGridViewHandlerStyle();
            RecordsNumber();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateAppType updateAppType = new FrmUpdateAppType
                (Convert.ToInt32(dgvAllAppType.CurrentRow.Cells[0].Value));
            updateAppType.ShowDialog();
            ReloadData();
        }
    }
}
