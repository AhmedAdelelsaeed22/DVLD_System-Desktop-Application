namespace DVLD_System
{
    partial class EditApplicationType
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.lblappFees = new System.Windows.Forms.Label();
            this.lblIDValue = new System.Windows.Forms.Label();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.txtAppFees = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(57, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Application Type";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(171, 169);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(42, 24);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID:";
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.AutoSize = true;
            this.lblApplicationTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTitle.Location = new System.Drawing.Point(38, 230);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(175, 24);
            this.lblApplicationTitle.TabIndex = 2;
            this.lblApplicationTitle.Text = "ApplicationTitle:";
            // 
            // lblappFees
            // 
            this.lblappFees.AutoSize = true;
            this.lblappFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblappFees.Location = new System.Drawing.Point(38, 298);
            this.lblappFees.Name = "lblappFees";
            this.lblappFees.Size = new System.Drawing.Size(177, 24);
            this.lblappFees.TabIndex = 3;
            this.lblappFees.Text = "ApplicationFees:";
            // 
            // lblIDValue
            // 
            this.lblIDValue.AutoSize = true;
            this.lblIDValue.Location = new System.Drawing.Point(296, 174);
            this.lblIDValue.Name = "lblIDValue";
            this.lblIDValue.Size = new System.Drawing.Size(36, 17);
            this.lblIDValue.TabIndex = 4;
            this.lblIDValue.Text = "????";
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.Location = new System.Drawing.Point(228, 230);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(187, 24);
            this.txtAppTitle.TabIndex = 5;
            // 
            // txtAppFees
            // 
            this.txtAppFees.Location = new System.Drawing.Point(228, 302);
            this.txtAppFees.Name = "txtAppFees";
            this.txtAppFees.Size = new System.Drawing.Size(187, 24);
            this.txtAppFees.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(335, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 51);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 51);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 505);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAppFees);
            this.Controls.Add(this.txtAppTitle);
            this.Controls.Add(this.lblIDValue);
            this.Controls.Add(this.lblappFees);
            this.Controls.Add(this.lblApplicationTitle);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.Name = "EditApplicationType";
            this.Text = "EditApplicationType";
            this.Load += new System.EventHandler(this.EditApplicationType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblApplicationTitle;
        private System.Windows.Forms.Label lblappFees;
        private System.Windows.Forms.Label lblIDValue;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.TextBox txtAppFees;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}