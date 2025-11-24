namespace DVLD_System
{
    partial class EditTestTypes
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTestFees = new System.Windows.Forms.TextBox();
            this.txtTestTitle = new System.Windows.Forms.TextBox();
            this.lblIDValue = new System.Windows.Forms.Label();
            this.lblTestTypeFees = new System.Windows.Forms.Label();
            this.lblTestTypeTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestTypeDescription = new System.Windows.Forms.Label();
            this.txtTestDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(209, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 51);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(345, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 51);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTestFees
            // 
            this.txtTestFees.Location = new System.Drawing.Point(238, 338);
            this.txtTestFees.Name = "txtTestFees";
            this.txtTestFees.Size = new System.Drawing.Size(187, 24);
            this.txtTestFees.TabIndex = 15;
            // 
            // txtTestTitle
            // 
            this.txtTestTitle.Location = new System.Drawing.Point(238, 230);
            this.txtTestTitle.Name = "txtTestTitle";
            this.txtTestTitle.Size = new System.Drawing.Size(187, 24);
            this.txtTestTitle.TabIndex = 14;
            // 
            // lblIDValue
            // 
            this.lblIDValue.AutoSize = true;
            this.lblIDValue.Location = new System.Drawing.Point(306, 174);
            this.lblIDValue.Name = "lblIDValue";
            this.lblIDValue.Size = new System.Drawing.Size(36, 17);
            this.lblIDValue.TabIndex = 13;
            this.lblIDValue.Text = "????";
            // 
            // lblTestTypeFees
            // 
            this.lblTestTypeFees.AutoSize = true;
            this.lblTestTypeFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypeFees.Location = new System.Drawing.Point(48, 338);
            this.lblTestTypeFees.Name = "lblTestTypeFees";
            this.lblTestTypeFees.Size = new System.Drawing.Size(154, 24);
            this.lblTestTypeFees.TabIndex = 12;
            this.lblTestTypeFees.Text = "TestTypeFees:";
            // 
            // lblTestTypeTitle
            // 
            this.lblTestTypeTitle.AutoSize = true;
            this.lblTestTypeTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypeTitle.Location = new System.Drawing.Point(48, 230);
            this.lblTestTypeTitle.Name = "lblTestTypeTitle";
            this.lblTestTypeTitle.Size = new System.Drawing.Size(152, 24);
            this.lblTestTypeTitle.TabIndex = 11;
            this.lblTestTypeTitle.Text = "TestTypeTitle:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(108, 167);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(42, 24);
            this.lblID.TabIndex = 10;
            this.lblID.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(153, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Update Test Type";
            // 
            // lblTestTypeDescription
            // 
            this.lblTestTypeDescription.AutoSize = true;
            this.lblTestTypeDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypeDescription.Location = new System.Drawing.Point(0, 283);
            this.lblTestTypeDescription.Name = "lblTestTypeDescription";
            this.lblTestTypeDescription.Size = new System.Drawing.Size(223, 24);
            this.lblTestTypeDescription.TabIndex = 18;
            this.lblTestTypeDescription.Text = "TestTypeDescription:";
            // 
            // txtTestDesc
            // 
            this.txtTestDesc.Location = new System.Drawing.Point(238, 283);
            this.txtTestDesc.Name = "txtTestDesc";
            this.txtTestDesc.Size = new System.Drawing.Size(187, 24);
            this.txtTestDesc.TabIndex = 19;
            // 
            // EditTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 499);
            this.Controls.Add(this.txtTestDesc);
            this.Controls.Add(this.lblTestTypeDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTestFees);
            this.Controls.Add(this.txtTestTitle);
            this.Controls.Add(this.lblIDValue);
            this.Controls.Add(this.lblTestTypeFees);
            this.Controls.Add(this.lblTestTypeTitle);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.Name = "EditTestTypes";
            this.Text = "EditTestTypes";
            this.Load += new System.EventHandler(this.EditTestTypes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTestFees;
        private System.Windows.Forms.TextBox txtTestTitle;
        private System.Windows.Forms.Label lblIDValue;
        private System.Windows.Forms.Label lblTestTypeFees;
        private System.Windows.Forms.Label lblTestTypeTitle;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestTypeDescription;
        private System.Windows.Forms.TextBox txtTestDesc;
    }
}