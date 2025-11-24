namespace DVLD_System
{
    partial class ctrlAddOrEditNewCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblGendor = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblThird = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFmale = new System.Windows.Forms.RadioButton();
            this.lblBirthOfDate = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.dtpBirthOfDate = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSetImage = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProviderNationalNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderFirstName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderSecondName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderThirdName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderLastName = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialogSetImage = new System.Windows.Forms.OpenFileDialog();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNationalNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSecondName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderThirdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(30, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 22);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.Location = new System.Drawing.Point(12, 95);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(123, 22);
            this.lblNationalNo.TabIndex = 2;
            this.lblNationalNo.Text = "National No:";
            // 
            // lblGendor
            // 
            this.lblGendor.AutoSize = true;
            this.lblGendor.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGendor.Location = new System.Drawing.Point(28, 146);
            this.lblGendor.Name = "lblGendor";
            this.lblGendor.Size = new System.Drawing.Size(83, 22);
            this.lblGendor.TabIndex = 3;
            this.lblGendor.Text = "Gendor:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(34, 199);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(66, 22);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(23, 256);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(88, 22);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(113, 48);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(167, 24);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(663, 48);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(167, 24);
            this.txtLastName.TabIndex = 7;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // txtThirdName
            // 
            this.txtThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdName.Location = new System.Drawing.Point(481, 48);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(167, 24);
            this.txtThirdName.TabIndex = 8;
            this.txtThirdName.Validating += new System.ComponentModel.CancelEventHandler(this.txtThirdName_Validating);
            // 
            // txtSecondName
            // 
            this.txtSecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondName.Location = new System.Drawing.Point(296, 48);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(167, 24);
            this.txtSecondName.TabIndex = 9;
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.txtSecondName_Validating);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(180, 16);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(33, 17);
            this.lblFirst.TabIndex = 10;
            this.lblFirst.Text = "First";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(355, 16);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(54, 17);
            this.lblSecond.TabIndex = 11;
            this.lblSecond.Text = "Second";
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Location = new System.Drawing.Point(539, 16);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(39, 17);
            this.lblThird.TabIndex = 12;
            this.lblThird.Text = "Third";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(724, 16);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(33, 17);
            this.lblLast.TabIndex = 13;
            this.lblLast.Text = "Last";
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNationalNo.Location = new System.Drawing.Point(138, 95);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(167, 24);
            this.txtNationalNo.TabIndex = 14;
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(138, 149);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(55, 21);
            this.rbMale.TabIndex = 15;
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "0";
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // rbFmale
            // 
            this.rbFmale.AutoSize = true;
            this.rbFmale.Location = new System.Drawing.Point(241, 149);
            this.rbFmale.Name = "rbFmale";
            this.rbFmale.Size = new System.Drawing.Size(64, 21);
            this.rbFmale.TabIndex = 16;
            this.rbFmale.Tag = "1";
            this.rbFmale.Text = "Fmale";
            this.rbFmale.UseVisualStyleBackColor = true;
            // 
            // lblBirthOfDate
            // 
            this.lblBirthOfDate.AutoSize = true;
            this.lblBirthOfDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthOfDate.Location = new System.Drawing.Point(311, 97);
            this.lblBirthOfDate.Name = "lblBirthOfDate";
            this.lblBirthOfDate.Size = new System.Drawing.Size(135, 22);
            this.lblBirthOfDate.TabIndex = 17;
            this.lblBirthOfDate.Text = "Birth Of Date:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(334, 151);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 22);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Phone:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(334, 199);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(89, 22);
            this.lblCountry.TabIndex = 19;
            this.lblCountry.Text = "Country:";
            // 
            // dtpBirthOfDate
            // 
            this.dtpBirthOfDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthOfDate.Location = new System.Drawing.Point(449, 96);
            this.dtpBirthOfDate.MaxDate = new System.DateTime(2007, 10, 9, 0, 0, 0, 0);
            this.dtpBirthOfDate.Name = "dtpBirthOfDate";
            this.dtpBirthOfDate.Size = new System.Drawing.Size(215, 24);
            this.dtpBirthOfDate.TabIndex = 20;
            this.dtpBirthOfDate.Value = new System.DateTime(2005, 10, 9, 0, 0, 0, 0);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(449, 149);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(168, 24);
            this.txtPhone.TabIndex = 21;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // cbCountries
            // 
            this.cbCountries.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(449, 201);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(129, 24);
            this.cbCountries.TabIndex = 22;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(113, 256);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(465, 129);
            this.txtAddress.TabIndex = 23;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(138, 199);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 24);
            this.txtEmail.TabIndex = 24;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblSetImage
            // 
            this.lblSetImage.AutoSize = true;
            this.lblSetImage.Location = new System.Drawing.Point(707, 333);
            this.lblSetImage.Name = "lblSetImage";
            this.lblSetImage.Size = new System.Drawing.Size(70, 17);
            this.lblSetImage.TabIndex = 26;
            this.lblSetImage.TabStop = true;
            this.lblSetImage.Text = "Set Image";
            this.lblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetImage_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(458, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 48);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(303, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 48);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProviderNationalNo
            // 
            this.errorProviderNationalNo.ContainerControl = this;
            // 
            // errorProviderPhone
            // 
            this.errorProviderPhone.ContainerControl = this;
            // 
            // errorProviderEmail
            // 
            this.errorProviderEmail.ContainerControl = this;
            // 
            // errorProviderFirstName
            // 
            this.errorProviderFirstName.ContainerControl = this;
            // 
            // errorProviderSecondName
            // 
            this.errorProviderSecondName.ContainerControl = this;
            // 
            // errorProviderThirdName
            // 
            this.errorProviderThirdName.ContainerControl = this;
            // 
            // errorProviderLastName
            // 
            this.errorProviderLastName.ContainerControl = this;
            // 
            // openFileDialogSetImage
            // 
            this.openFileDialogSetImage.FileName = "openFileDialog1";
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLD_System.Properties.Resources.Male;
            this.pbImage.Location = new System.Drawing.Point(642, 151);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(199, 166);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 25;
            this.pbImage.TabStop = false;
            // 
            // ctrlAddOrEditNewCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSetImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cbCountries);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.dtpBirthOfDate);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblBirthOfDate);
            this.Controls.Add(this.rbFmale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblThird);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtThirdName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblGendor);
            this.Controls.Add(this.lblNationalNo);
            this.Controls.Add(this.lblName);
            this.Name = "ctrlAddOrEditNewCard";
            this.Size = new System.Drawing.Size(860, 474);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNationalNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSecondName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderThirdName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblGendor;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFmale;
        private System.Windows.Forms.Label lblBirthOfDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.DateTimePicker dtpBirthOfDate;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.LinkLabel lblSetImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProviderNationalNo;
        private System.Windows.Forms.ErrorProvider errorProviderPhone;
        private System.Windows.Forms.ErrorProvider errorProviderEmail;
        private System.Windows.Forms.ErrorProvider errorProviderFirstName;
        private System.Windows.Forms.ErrorProvider errorProviderSecondName;
        private System.Windows.Forms.ErrorProvider errorProviderThirdName;
        private System.Windows.Forms.ErrorProvider errorProviderLastName;
        private System.Windows.Forms.OpenFileDialog openFileDialogSetImage;
    }
}
