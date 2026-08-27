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

namespace DVLD_System.People
{
    public partial class FrmPersonDetails : MaterialSkin.Controls.MaterialForm
    {

        int _PersonID = -1;
        clsPeople _PersonInfo;

        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;   

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void _DataLoad()
        {
            ctrlPersonDetails1.LinkEdit += linkLabelEditPersonalInfo_LinkClicked;
            _PersonInfo = clsPeople.FindPerson(_PersonID);

            if (_PersonInfo != null)
            {
                ctrlPersonDetails1.LoadDataToControl(_PersonInfo);
            }
        }


        private void linkLabelEditPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddOrEditPerson editPerson = new FrmAddOrEditPerson(_PersonInfo.PersonID);
            editPerson.ShowDialog();
        }


        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {
            _DataLoad();
        }
    }
}
