namespace DVLD_System.L.D_License.Manage_Application
{
    partial class FrmShowLicense
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlShowLicense1 = new DVLD_Controls.UserControls.LDApplication.ctrlShowLicense();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(414, 209);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 40);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "License Details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Show_License;
            this.pictureBox1.Location = new System.Drawing.Point(453, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlShowLicense1
            // 
            this.ctrlShowLicense1.ClassName = "?????";
            this.ctrlShowLicense1.DateOfBirth = "?????";
            this.ctrlShowLicense1.DriverID = "?????";
            this.ctrlShowLicense1.ExpirationDate = "?????";
            this.ctrlShowLicense1.FName = "?????";
            this.ctrlShowLicense1.Gendor = "?????";
            this.ctrlShowLicense1.ImagePath = null;
            this.ctrlShowLicense1.IsActive = "?????";
            this.ctrlShowLicense1.IsDetained = "?????";
            this.ctrlShowLicense1.IssueDate = "?????";
            this.ctrlShowLicense1.IssueResons = "?????";
            this.ctrlShowLicense1.LicenseID = "?????";
            this.ctrlShowLicense1.Location = new System.Drawing.Point(47, 275);
            this.ctrlShowLicense1.Name = "ctrlShowLicense1";
            this.ctrlShowLicense1.NationalNo = "?????";
            this.ctrlShowLicense1.Size = new System.Drawing.Size(1012, 314);
            this.ctrlShowLicense1.TabIndex = 23;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(477, 606);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(138, 35);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmShowLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 665);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowLicense1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmShowLicense";
            this.Load += new System.EventHandler(this.FrmShowLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DVLD_Controls.UserControls.LDApplication.ctrlShowLicense ctrlShowLicense1;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
    }
}