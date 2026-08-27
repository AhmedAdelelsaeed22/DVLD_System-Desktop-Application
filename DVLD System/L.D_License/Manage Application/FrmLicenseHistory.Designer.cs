namespace DVLD_System.L.D_License.Manage_Application
{
    partial class FrmLicenseHistory
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
            this.ctrlPersonDetails1 = new DVLD_Controls.UserControls.ctrlPersonDetails();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tLocal = new System.Windows.Forms.TabPage();
            this.Inter = new System.Windows.Forms.TabPage();
            this.lblRecordValue = new System.Windows.Forms.Label();
            this.lblRecord = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvLocalLicense = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicense)).BeginInit();
            this.SuspendLayout();
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
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(58, 146);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = "?????";
            this.ctrlPersonDetails1.PersonID = "?????";
            this.ctrlPersonDetails1.Phone = "?????";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(900, 336);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(369, 85);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 40);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "License History";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tLocal);
            this.tabControl1.Controls.Add(this.Inter);
            this.tabControl1.Location = new System.Drawing.Point(58, 502);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 212);
            this.tabControl1.TabIndex = 24;
            // 
            // tLocal
            // 
            this.tLocal.Controls.Add(this.lblRecordValue);
            this.tLocal.Controls.Add(this.lblRecord);
            this.tLocal.Controls.Add(this.dgvLocalLicense);
            this.tLocal.Location = new System.Drawing.Point(4, 25);
            this.tLocal.Name = "tLocal";
            this.tLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tLocal.Size = new System.Drawing.Size(892, 183);
            this.tLocal.TabIndex = 0;
            this.tLocal.Text = "Local";
            this.tLocal.UseVisualStyleBackColor = true;
            // 
            // Inter
            // 
            this.Inter.Location = new System.Drawing.Point(4, 25);
            this.Inter.Name = "Inter";
            this.Inter.Padding = new System.Windows.Forms.Padding(3);
            this.Inter.Size = new System.Drawing.Size(892, 183);
            this.Inter.TabIndex = 1;
            this.Inter.Text = "International";
            this.Inter.UseVisualStyleBackColor = true;
            // 
            // lblRecordValue
            // 
            this.lblRecordValue.AutoSize = true;
            this.lblRecordValue.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordValue.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRecordValue.Location = new System.Drawing.Point(127, 153);
            this.lblRecordValue.Name = "lblRecordValue";
            this.lblRecordValue.Size = new System.Drawing.Size(15, 16);
            this.lblRecordValue.TabIndex = 40;
            this.lblRecordValue.Text = "0";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Depth = 0;
            this.lblRecord.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRecord.Location = new System.Drawing.Point(32, 147);
            this.lblRecord.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(85, 24);
            this.lblRecord.TabIndex = 39;
            this.lblRecord.Text = "Records:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(376, 733);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(263, 41);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvLocalLicense
            // 
            this.dgvLocalLicense.AllowUserToAddRows = false;
            this.dgvLocalLicense.AllowUserToDeleteRows = false;
            this.dgvLocalLicense.AllowUserToOrderColumns = true;
            this.dgvLocalLicense.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicense.Location = new System.Drawing.Point(19, 24);
            this.dgvLocalLicense.Name = "dgvLocalLicense";
            this.dgvLocalLicense.ReadOnly = true;
            this.dgvLocalLicense.RowHeadersWidth = 51;
            this.dgvLocalLicense.RowTemplate.Height = 26;
            this.dgvLocalLicense.Size = new System.Drawing.Size(855, 110);
            this.dgvLocalLicense.TabIndex = 37;
            // 
            // FrmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 788);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "FrmLicenseHistory";
            this.Load += new System.EventHandler(this.FrmLicenseHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tLocal.ResumeLayout(false);
            this.tLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD_Controls.UserControls.ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tLocal;
        private System.Windows.Forms.TabPage Inter;
        private System.Windows.Forms.Label lblRecordValue;
        private MaterialSkin.Controls.MaterialLabel lblRecord;
        private System.Windows.Forms.DataGridView dgvLocalLicense;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
    }
}