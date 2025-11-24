namespace DVLD_System
{
    partial class PersonDetailsForm
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
            this.ctrlPersonDetails1 = new DVLD_System.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(409, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person Details";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Address = "Address:";
            this.ctrlPersonDetails1.CountryName = "Country:";
            this.ctrlPersonDetails1.DateOfBirth = "Birth Of Date:";
            this.ctrlPersonDetails1.Email = "Email:";
            this.ctrlPersonDetails1.FullName = "Name:";
            this.ctrlPersonDetails1.Gendor = "Female";
            this.ctrlPersonDetails1.ImagePath = null;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(63, 120);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = "National No:";
            this.ctrlPersonDetails1.PersonID = "PersonID:";
            this.ctrlPersonDetails1.Phone = "Phone:";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(963, 392);
            this.ctrlPersonDetails1.TabIndex = 1;
            // 
            // PersonDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 627);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.label1);
            this.Name = "PersonDetailsForm";
            this.Text = "PersonDetailsForm";
            this.Load += new System.EventHandler(this.PersonDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlPersonDetails ctrlPersonDetails1;
    }
}