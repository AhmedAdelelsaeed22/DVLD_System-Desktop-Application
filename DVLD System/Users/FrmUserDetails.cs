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
    public partial class FrmUserDetails : MaterialSkin.Controls.MaterialForm
    {

        int _UserID = -1;
        clsUsers _UserInfo;
        clsPeople _PersonInfo;

        public FrmUserDetails(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }


        private void DataLoad()
        {
            _UserInfo = clsUsers.FindUser(_UserID);

            if (_UserInfo != null)
            {
                _PersonInfo = clsPeople.FindPerson(_UserInfo.PersonID);
            }

            if (_PersonInfo != null) 
            {
                ctrlUserDetails1.LoadDataToForm(_PersonInfo , _UserInfo);
            }
        }

        private void FrmUserDetails_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
    }
}
