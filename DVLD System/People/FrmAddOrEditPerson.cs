using DVLD_BussinessLayer;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.People
{
    public partial class FrmAddOrEditPerson : MaterialSkin.Controls.MaterialForm
    {

        public class SendPersonIDEvent : EventArgs
        {
            public int PersonID { get; }

            public SendPersonIDEvent(int personID)
            {
                PersonID = personID;
            }
        };

        public event EventHandler<SendPersonIDEvent> PersonIDSent;

        public void OnPersonIDSent(int personID)
        {
            OnPersonIDSent(this , new SendPersonIDEvent(personID));
        }

        protected virtual void OnPersonIDSent(object sender , SendPersonIDEvent e)
        {
            PersonIDSent?.Invoke(sender, e);
        }



        public enum enMode {Add = 0  , Edit = 1};
        private enMode _Mode;

        int _PersonID = -1;
        clsPeople _PeopleInfo;

        public FrmAddOrEditPerson()
        {
            InitializeComponent();
            _PersonID = -1;
            _Mode = enMode.Add;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }

        public FrmAddOrEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Edit;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900,
            Primary.Blue900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void _DataLoad()
        {
            ctrlAddorEditPerson1.DateOfBirthHandler();
            ctrlAddorEditPerson1.CustomCountriesHandler();
            ctrlAddorEditPerson1.LinkableVisibleRemoveImage();

            if (_Mode == enMode.Add)
            {
                _PeopleInfo = new clsPeople();
                return;
            }


            _PeopleInfo = clsPeople.FindPerson(_PersonID);

            if (_PeopleInfo != null)
            {
                ctrlAddorEditPerson1.LoadDataToControl(_PeopleInfo);
                lblPersonID.Text = _PeopleInfo.PersonID.ToString();
            }
        }

        private void FrmAddOrEdit_Load(object sender, EventArgs e)
        {
            _DataLoad();
            ctrlAddorEditPerson1.SaveChanges += SaveChanges;
            ctrlAddorEditPerson1.CloseForm += Close_Form;
            ctrlAddorEditPerson1.SetImage += SetImage;
          
        }


        private void SaveChanges(object sender, EventArgs e)
        {
            ctrlAddorEditPerson1.LoadDataToObject(_PeopleInfo);
            if (_PeopleInfo.Save())
            {
                MessageBox.Show("Save Successfully" , "Successfully" 
                    ,MessageBoxButtons.OK , MessageBoxIcon.Information);
                OnPersonIDSent(_PeopleInfo.PersonID);
                lblPersonID.Text = _PeopleInfo.PersonID.ToString();
            }
            else
            {
                MessageBox.Show("Erorr Saving", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Close_Form(object sender, EventArgs e)
        {
            Close();
        }


        private void SetImage(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png;*.bmp;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ctrlAddorEditPerson1.ImagePath = ofd.FileName;
            }

            ctrlAddorEditPerson1.LinkableVisibleRemoveImage();
        }
    }
}
