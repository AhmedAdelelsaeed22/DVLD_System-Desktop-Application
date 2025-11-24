namespace DVLD_System
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProviderCurrentPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderNewPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderConfirmPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserDetails1 = new DVLD_System.ctrlUserDetails();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCurrentPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNewPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfirmPass)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.AutoSize = true;
            this.lblCurrentPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPass.Location = new System.Drawing.Point(94, 555);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(147, 18);
            this.lblCurrentPass.TabIndex = 1;
            this.lblCurrentPass.Text = "Current Password:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(94, 609);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(124, 18);
            this.lblNewPass.TabIndex = 2;
            this.lblNewPass.Text = "New Password:";
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.Location = new System.Drawing.Point(92, 664);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(149, 18);
            this.lblConfirmPass.TabIndex = 3;
            this.lblConfirmPass.Text = "Confirm Password:";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPass.Location = new System.Drawing.Point(259, 554);
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.PasswordChar = '*';
            this.txtCurrentPass.Size = new System.Drawing.Size(199, 24);
            this.txtCurrentPass.TabIndex = 4;
            this.txtCurrentPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPass_Validating);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPass.Location = new System.Drawing.Point(259, 658);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(199, 24);
            this.txtConfirmPass.TabIndex = 5;
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass.Location = new System.Drawing.Point(259, 603);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(199, 24);
            this.txtNewPass.TabIndex = 6;
            this.txtNewPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPass_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(906, 677);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 51);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 51);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProviderCurrentPass
            // 
            this.errorProviderCurrentPass.ContainerControl = this;
            // 
            // errorProviderNewPass
            // 
            this.errorProviderNewPass.ContainerControl = this;
            // 
            // errorProviderConfirmPass
            // 
            this.errorProviderConfirmPass.ContainerControl = this;
            // 
            // ctrlUserDetails1
            // 
            this.ctrlUserDetails1.Address = "??????";
            this.ctrlUserDetails1.CountryName = "??????";
            this.ctrlUserDetails1.DateOfBirth = "??????";
            this.ctrlUserDetails1.EditLink = true;
            this.ctrlUserDetails1.Email = "??????";
            this.ctrlUserDetails1.FullName = "??????";
            this.ctrlUserDetails1.Gendor = "Female";
            this.ctrlUserDetails1.ImagePath = null;
            this.ctrlUserDetails1.IsActive = "????";
            this.ctrlUserDetails1.Location = new System.Drawing.Point(73, 25);
            this.ctrlUserDetails1.Name = "ctrlUserDetails1";
            this.ctrlUserDetails1.NationalNo = "??????";
            this.ctrlUserDetails1.PersonID = "?????";
            this.ctrlUserDetails1.Phone = "??????";
            this.ctrlUserDetails1.Size = new System.Drawing.Size(973, 477);
            this.ctrlUserDetails1.TabIndex = 0;
            this.ctrlUserDetails1.UserID = "????";
            this.ctrlUserDetails1.UserName = "????";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 757);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtCurrentPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblCurrentPass);
            this.Controls.Add(this.ctrlUserDetails1);
            this.Name = "ChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.Change_Password_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCurrentPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNewPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfirmPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserDetails ctrlUserDetails1;
        private System.Windows.Forms.Label lblCurrentPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProviderCurrentPass;
        private System.Windows.Forms.ErrorProvider errorProviderNewPass;
        private System.Windows.Forms.ErrorProvider errorProviderConfirmPass;
    }
}