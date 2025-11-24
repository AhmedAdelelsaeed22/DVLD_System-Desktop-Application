namespace DVLD_System
{
    partial class PersonInfo
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
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.ctrlAddOrEditNewCard1 = new DVLD_System.ctrlAddOrEditNewCard();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(318, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add New Person";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(21, 78);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(88, 22);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "PersonID:";
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.AutoSize = true;
            this.lblIDNumber.Location = new System.Drawing.Point(113, 81);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(36, 17);
            this.lblIDNumber.TabIndex = 3;
            this.lblIDNumber.Text = "????";
            // 
            // ctrlAddOrEditNewCard1
            // 
            this.ctrlAddOrEditNewCard1.Address = "";
            this.ctrlAddOrEditNewCard1.CountryNameIndex = -1;
            this.ctrlAddOrEditNewCard1.DateOfBirth = new System.DateTime(2005, 10, 9, 0, 0, 0, 0);
            this.ctrlAddOrEditNewCard1.Email = "";
            this.ctrlAddOrEditNewCard1.FirstName = "";
            this.ctrlAddOrEditNewCard1.Gendor = ((byte)(0));
            this.ctrlAddOrEditNewCard1.LastName = "";
            this.ctrlAddOrEditNewCard1.Location = new System.Drawing.Point(26, 116);
            this.ctrlAddOrEditNewCard1.Name = "ctrlAddOrEditNewCard1";
            this.ctrlAddOrEditNewCard1.NationalNo = "";
            this.ctrlAddOrEditNewCard1.Phone = "";
            this.ctrlAddOrEditNewCard1.SecondName = "";
            this.ctrlAddOrEditNewCard1.Size = new System.Drawing.Size(869, 476);
            this.ctrlAddOrEditNewCard1.TabIndex = 0;
            this.ctrlAddOrEditNewCard1.ThirdName = "";
            // 
            // PersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 613);
            this.Controls.Add(this.lblIDNumber);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlAddOrEditNewCard1);
            this.Name = "PersonInfo";
            this.Text = "Add / Edit Person Info";
            this.Load += new System.EventHandler(this.PersonInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddOrEditNewCard ctrlAddOrEditNewCard1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblIDNumber;
    }
}