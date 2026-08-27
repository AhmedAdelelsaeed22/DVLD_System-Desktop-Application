namespace DVLD_System.L.D_License
{
    partial class FrmNewLocalDriverLicense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBoxFIlter = new System.Windows.Forms.GroupBox();
            this.ctrlPersonSearch1 = new DVLD_Controls.UserControls.ctrlPersonSearch();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlPersonDetails1 = new DVLD_Controls.UserControls.ctrlPersonDetails();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.customLicenseClasses1 = new DVLD_Controls.CustomControlls.CustomLicenseClasses();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblID = new System.Windows.Forms.Label();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabControl1.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.groupBoxFIlter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Brown;
            this.lblTitle.Location = new System.Drawing.Point(419, 79);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(533, 34);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "New Local Driver License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPersonInfo);
            this.tabControl1.Controls.Add(this.tpLoginInfo);
            this.tabControl1.Location = new System.Drawing.Point(57, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1313, 669);
            this.tabControl1.TabIndex = 34;
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.Controls.Add(this.btnNext);
            this.tbPersonInfo.Controls.Add(this.groupBoxFIlter);
            this.tbPersonInfo.Controls.Add(this.groupBox2);
            this.tbPersonInfo.ImageIndex = 1;
            this.tbPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(1305, 640);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Personal Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Depth = 0;
            this.btnNext.Location = new System.Drawing.Point(952, 583);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.Primary = true;
            this.btnNext.Size = new System.Drawing.Size(141, 33);
            this.btnNext.TabIndex = 34;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBoxFIlter
            // 
            this.groupBoxFIlter.Controls.Add(this.ctrlPersonSearch1);
            this.groupBoxFIlter.Location = new System.Drawing.Point(284, 66);
            this.groupBoxFIlter.Name = "groupBoxFIlter";
            this.groupBoxFIlter.Size = new System.Drawing.Size(753, 76);
            this.groupBoxFIlter.TabIndex = 32;
            this.groupBoxFIlter.TabStop = false;
            this.groupBoxFIlter.Text = "Filter";
            // 
            // ctrlPersonSearch1
            // 
            this.ctrlPersonSearch1.Location = new System.Drawing.Point(41, 20);
            this.ctrlPersonSearch1.Name = "ctrlPersonSearch1";
            this.ctrlPersonSearch1.Size = new System.Drawing.Size(691, 46);
            this.ctrlPersonSearch1.TabIndex = 4;
            this.ctrlPersonSearch1.TextFilter = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPersonDetails1);
            this.groupBox2.Location = new System.Drawing.Point(182, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(965, 413);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personal Info";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Address = "?????";
            this.ctrlPersonDetails1.CountryName = "?????";
            this.ctrlPersonDetails1.DateOfBirth = "?????";
            this.ctrlPersonDetails1.Email = "?????";
            this.ctrlPersonDetails1.FullName = "?????";
            this.ctrlPersonDetails1.Gendor = "?????";
            this.ctrlPersonDetails1.ImagePath = null;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(44, 34);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = "?????";
            this.ctrlPersonDetails1.PersonID = "?????";
            this.ctrlPersonDetails1.Phone = "?????";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(900, 336);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.customLicenseClasses1);
            this.tpLoginInfo.Controls.Add(this.lblCreatedBy);
            this.tpLoginInfo.Controls.Add(this.materialLabel5);
            this.tpLoginInfo.Controls.Add(this.lblAppFees);
            this.tpLoginInfo.Controls.Add(this.lblAppDate);
            this.tpLoginInfo.Controls.Add(this.materialLabel4);
            this.tpLoginInfo.Controls.Add(this.materialLabel3);
            this.tpLoginInfo.Controls.Add(this.materialLabel2);
            this.tpLoginInfo.Controls.Add(this.lblID);
            this.tpLoginInfo.Controls.Add(this.materialLabel1);
            this.tpLoginInfo.ImageIndex = 0;
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 25);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(1305, 640);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Application Info";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            // 
            // customLicenseClasses1
            // 
            this.customLicenseClasses1.FormattingEnabled = true;
            this.customLicenseClasses1.Location = new System.Drawing.Point(604, 309);
            this.customLicenseClasses1.Name = "customLicenseClasses1";
            this.customLicenseClasses1.Size = new System.Drawing.Size(234, 24);
            this.customLicenseClasses1.TabIndex = 13;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(645, 459);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(44, 18);
            this.lblCreatedBy.TabIndex = 12;
            this.lblCreatedBy.Text = "????";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(408, 453);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(106, 24);
            this.materialLabel5.TabIndex = 11;
            this.materialLabel5.Text = "Created By:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(635, 378);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(44, 18);
            this.lblAppFees.TabIndex = 10;
            this.lblAppFees.Text = "????";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(635, 244);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(44, 18);
            this.lblAppDate.TabIndex = 8;
            this.lblAppDate.Text = "????";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(392, 375);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(157, 24);
            this.materialLabel4.TabIndex = 4;
            this.materialLabel4.Text = "Application Fees:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(408, 305);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(132, 24);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "License Class:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(402, 238);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(149, 24);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "ApplicationDate:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(635, 170);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(44, 18);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "????";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(402, 167);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(160, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "D.L.ApplicationID:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(1032, 794);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(104, 35);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(1155, 794);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(104, 35);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmNewLocalDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 842);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmNewLocalDriverLicense";
            this.Load += new System.EventHandler(this.FrmNewLocalDriverLicense_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbPersonInfo.ResumeLayout(false);
            this.groupBoxFIlter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private MaterialSkin.Controls.MaterialRaisedButton btnNext;
        private System.Windows.Forms.GroupBox groupBoxFIlter;
        private DVLD_Controls.UserControls.ctrlPersonSearch ctrlPersonSearch1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DVLD_Controls.UserControls.ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Label lblID;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private System.Windows.Forms.Label lblCreatedBy;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private DVLD_Controls.CustomControlls.CustomLicenseClasses customLicenseClasses1;
    }
}