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
    public partial class ctrlApplicationInfo : UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        
        public string AppID
        {
            get {return  lblAppIDValue.Text;}
            set { lblAppIDValue.Text = value;}
        }


        public string ApplicationLicense
        {
            get { return lblAppLicenseValue.Text; }
            set { lblAppLicenseValue.Text = value; }
        }


        public string PassedTest
        {
            get {return lblPassedTestValue.Text;}
            set { lblPassedTestValue.Text = value;}
        }


        public string ID
        {
            get { return lblIDValue.Text; }
            set { lblIDValue.Text = value; }
        }


        public string Status
        {
            get { return lblStatusVal.Text; }
            set { lblStatusVal.Text = value; }
        }


        public string Fees
        {
            get { return lblFeesVal.Text; }
            set { lblFeesVal.Text = value; }
        }


        public string TypeApplication
        {
            get { return lblTypeVal.Text; }
            set { lblTypeVal.Text = value; }
        }


        public string Person
        {
            get {return lblPerson.Text;}
            set { lblPerson.Text = value;}
        }


        public string Date
        {
            get { return lblDateVal.Text; }
            set { lblDateVal.Text = value; }
        }


        public string StatusDate
        {
            get { return lblStatusDateVal.Text; }
            set { lblStatusDateVal.Text = value; }
        }



        public string CreatedBy
        {
            get { return lblCreatedByVal.Text; }
            set { lblCreatedByVal.Text = value; }
        }


        public event EventHandler ShowPersonInfo;

        private void linkLabelPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonInfo?.Invoke(this, new EventArgs());
        }
    }
}
