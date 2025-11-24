namespace DVLD_System
{
    partial class UserDetailsForm
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
            this.ctrlUserDetails1 = new DVLD_System.ctrlUserDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.ctrlUserDetails1.Location = new System.Drawing.Point(35, 26);
            this.ctrlUserDetails1.Name = "ctrlUserDetails1";
            this.ctrlUserDetails1.NationalNo = "??????";
            this.ctrlUserDetails1.PersonID = "?????";
            this.ctrlUserDetails1.Phone = "??????";
            this.ctrlUserDetails1.Size = new System.Drawing.Size(973, 477);
            this.ctrlUserDetails1.TabIndex = 0;
            this.ctrlUserDetails1.UserID = "????";
            this.ctrlUserDetails1.UserName = "????";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(449, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 47);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 639);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlUserDetails1);
            this.Name = "UserDetailsForm";
            this.Text = "UserDetailsForm";
            this.Load += new System.EventHandler(this.UserDetailsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUserDetails ctrlUserDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}