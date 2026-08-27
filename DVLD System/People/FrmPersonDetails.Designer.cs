namespace DVLD_System.People
{
    partial class FrmPersonDetails
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(27, 156);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = "?????";
            this.ctrlPersonDetails1.PersonID = "?????";
            this.ctrlPersonDetails1.Phone = "?????";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(900, 336);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(336, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Details";
            // 
            // FrmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "FrmPersonDetails";
            this.Text = "Person Details";
            this.Load += new System.EventHandler(this.FrmPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD_Controls.UserControls.ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.Label label1;
    }
}