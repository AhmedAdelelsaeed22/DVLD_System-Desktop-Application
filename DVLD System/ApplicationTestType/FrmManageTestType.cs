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

namespace DVLD_System.ApplicationTestType
{
    public partial class FrmManageTestType : MaterialSkin.Controls.MaterialForm
    {
        public FrmManageTestType()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }



        private DataTable dtSourceAppTestType = clsApplicationTestType.GetAllApplicationTestTypes();


        private void RecordsNumber()
        {
            lblRecordValue.Text = dgvAllAppTestType.Rows.Count.ToString();
        }


        private void DataGridViewHandlerWidth()
        {
            dgvAllAppTestType.DataSource = dtSourceAppTestType;

            dgvAllAppTestType.Columns["TestTypeID"].HeaderText = "TestType ID";
            dgvAllAppTestType.Columns["TestTypeID"].Width = 80;

            dgvAllAppTestType.Columns["TestTypeTitle"].HeaderText = "TestType Title";
            dgvAllAppTestType.Columns["TestTypeTitle"].Width = 150;

            dgvAllAppTestType.Columns["TestTypeDescription"].HeaderText = "TestType Description";
            dgvAllAppTestType.Columns["TestTypeDescription"].Width = 250;

            dgvAllAppTestType.Columns["TestTypeFees"].HeaderText = "TestType Fees";
            dgvAllAppTestType.Columns["TestTypeFees"].Width = 80;
        }

        private void DataGridViewHandlerStyle()
        {
            dgvAllAppTestType.BorderStyle = BorderStyle.None;
            dgvAllAppTestType.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAllAppTestType.RowHeadersVisible = false;

            dgvAllAppTestType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllAppTestType.MultiSelect = false;
            dgvAllAppTestType.ReadOnly = true;
            dgvAllAppTestType.EnableHeadersVisualStyles = false;

            dgvAllAppTestType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvAllAppTestType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllAppTestType.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAllAppTestType.DefaultCellStyle.BackColor = Color.White;
            dgvAllAppTestType.DefaultCellStyle.ForeColor = Color.Black;
            dgvAllAppTestType.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgvAllAppTestType.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void ReloadData()
        {
            dtSourceAppTestType = clsApplicationTestType.GetAllApplicationTestTypes();
            dgvAllAppTestType.DataSource = dtSourceAppTestType;
        }

        private void FrmManageTestType_Load(object sender, EventArgs e)
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
           FrmEditApplicationTestType frmEditApplicationTestType = new FrmEditApplicationTestType
                (Convert.ToInt32(dgvAllAppTestType.CurrentRow.Cells[0].Value));
            frmEditApplicationTestType.ShowDialog();
            ReloadData();
        }
    }
}
