namespace DVLD_System.L.D_License.Manage_Application
{
    partial class FrmIssueDriverLicense
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
            this.ctrlVisionTest1 = new DVLD_Controls.UserControls.LDApplication.ctrlVisionTest();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnIssue = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // ctrlVisionTest1
            // 
            this.ctrlVisionTest1.Applicant = "????";
            this.ctrlVisionTest1.ApplicationID = "????";
            this.ctrlVisionTest1.ClassName = "????";
            this.ctrlVisionTest1.CreatedBy = "????";
            this.ctrlVisionTest1.Date = "????";
            this.ctrlVisionTest1.Fees = "????";
            this.ctrlVisionTest1.LastDate = "????";
            this.ctrlVisionTest1.LDAppID = "????";
            this.ctrlVisionTest1.Location = new System.Drawing.Point(24, 94);
            this.ctrlVisionTest1.Name = "ctrlVisionTest1";
            this.ctrlVisionTest1.PassedTest = "????";
            this.ctrlVisionTest1.Size = new System.Drawing.Size(905, 404);
            this.ctrlVisionTest1.Status = "????";
            this.ctrlVisionTest1.TabIndex = 0;
            this.ctrlVisionTest1.Type = "????";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(103, 511);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(732, 106);
            this.txtNote.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 516);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 18);
            this.label8.TabIndex = 67;
            this.label8.Text = "Note:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(565, 634);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.Depth = 0;
            this.btnIssue.Location = new System.Drawing.Point(688, 634);
            this.btnIssue.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Primary = true;
            this.btnIssue.Size = new System.Drawing.Size(99, 35);
            this.btnIssue.TabIndex = 65;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // FrmIssueDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 694);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlVisionTest1);
            this.Name = "FrmIssueDriverLicense";
            this.Load += new System.EventHandler(this.FrmIssueDriverLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD_Controls.UserControls.LDApplication.ctrlVisionTest ctrlVisionTest1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label8;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private MaterialSkin.Controls.MaterialRaisedButton btnIssue;
    }
}