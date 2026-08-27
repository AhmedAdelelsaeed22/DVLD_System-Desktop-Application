namespace DVLD_System.People
{
    partial class FrmAddOrEditPerson
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
            this.lblPersonID = new System.Windows.Forms.Label();
            this.ctrlAddorEditPerson1 = new DVLD_Controls.ctrlAddorEditPerson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "PersonID:";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(198, 86);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(47, 18);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "N / A";
            // 
            // ctrlAddorEditPerson1
            // 
            this.ctrlAddorEditPerson1.Address = "";
            this.ctrlAddorEditPerson1.DateOfBirth = new System.DateTime(2026, 1, 15, 17, 13, 59, 551);
            this.ctrlAddorEditPerson1.Email = "";
            this.ctrlAddorEditPerson1.FirstName = "";
            this.ctrlAddorEditPerson1.Gendor = "Male";
            this.ctrlAddorEditPerson1.ImagePath = null;
            this.ctrlAddorEditPerson1.LastName = "";
            this.ctrlAddorEditPerson1.Location = new System.Drawing.Point(53, 117);
            this.ctrlAddorEditPerson1.Name = "ctrlAddorEditPerson1";
            this.ctrlAddorEditPerson1.NationalNo = "";
            this.ctrlAddorEditPerson1.Phone = "";
            this.ctrlAddorEditPerson1.SecondName = "";
            this.ctrlAddorEditPerson1.Size = new System.Drawing.Size(965, 478);
            this.ctrlAddorEditPerson1.TabIndex = 0;
            this.ctrlAddorEditPerson1.ThridName = "";
            // 
            // FrmAddOrEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 623);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlAddorEditPerson1);
            this.Name = "FrmAddOrEditPerson";
            this.Text = "Add / Edit Person";
            this.Load += new System.EventHandler(this.FrmAddOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD_Controls.ctrlAddorEditPerson ctrlAddorEditPerson1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPersonID;
    }
}