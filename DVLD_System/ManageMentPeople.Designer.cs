namespace DVLD_System
{
    partial class ManageMentPeople
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAllPersons = new System.Windows.Forms.DataGridView();
            this.cmsManagmentPerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterType = new System.Windows.Forms.ComboBox();
            this.lblRecordTitle = new System.Windows.Forms.Label();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPersons)).BeginInit();
            this.cmsManagmentPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(613, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "ManageMent People";
            // 
            // dgvAllPersons
            // 
            this.dgvAllPersons.AllowUserToAddRows = false;
            this.dgvAllPersons.AllowUserToDeleteRows = false;
            this.dgvAllPersons.AllowUserToOrderColumns = true;
            this.dgvAllPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPersons.ContextMenuStrip = this.cmsManagmentPerson;
            this.dgvAllPersons.Location = new System.Drawing.Point(2, 336);
            this.dgvAllPersons.Name = "dgvAllPersons";
            this.dgvAllPersons.ReadOnly = true;
            this.dgvAllPersons.RowHeadersWidth = 51;
            this.dgvAllPersons.RowTemplate.Height = 26;
            this.dgvAllPersons.Size = new System.Drawing.Size(1655, 425);
            this.dgvAllPersons.TabIndex = 2;
            // 
            // cmsManagmentPerson
            // 
            this.cmsManagmentPerson.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManagmentPerson.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManagmentPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.sendPhoneToolStripMenuItem});
            this.cmsManagmentPerson.Name = "cmsManagmentPerson";
            this.cmsManagmentPerson.Size = new System.Drawing.Size(262, 220);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Show_Details;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Add_person;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Edit_Person;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.delete_person;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.send_email;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // sendPhoneToolStripMenuItem
            // 
            this.sendPhoneToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.send_phone;
            this.sendPhoneToolStripMenuItem.Name = "sendPhoneToolStripMenuItem";
            this.sendPhoneToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.sendPhoneToolStripMenuItem.Text = "Send Phone";
            this.sendPhoneToolStripMenuItem.Click += new System.EventHandler(this.sendPhoneToolStripMenuItem_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(43, 255);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(90, 24);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Filter By:";
            // 
            // cbFilterType
            // 
            this.cbFilterType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbFilterType.FormattingEnabled = true;
            this.cbFilterType.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo"});
            this.cbFilterType.Location = new System.Drawing.Point(139, 255);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.Size = new System.Drawing.Size(189, 24);
            this.cbFilterType.TabIndex = 5;
            this.cbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbFilterType_SelectedIndexChanged);
            // 
            // lblRecordTitle
            // 
            this.lblRecordTitle.AutoSize = true;
            this.lblRecordTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordTitle.Location = new System.Drawing.Point(135, 795);
            this.lblRecordTitle.Name = "lblRecordTitle";
            this.lblRecordTitle.Size = new System.Drawing.Size(108, 24);
            this.lblRecordTitle.TabIndex = 7;
            this.lblRecordTitle.Text = "# Records:";
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.Location = new System.Drawing.Point(239, 800);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(36, 18);
            this.lblRecordNumber.TabIndex = 8;
            this.lblRecordNumber.Text = "????";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(1198, 783);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(174, 49);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::DVLD_System.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(1225, 223);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 66);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.People;
            this.pictureBox1.Location = new System.Drawing.Point(608, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(358, 255);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(132, 24);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // ManageMentPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 875);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterType);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvAllPersons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManageMentPeople";
            this.Text = "ManageMent People";
            this.Load += new System.EventHandler(this.ManageMentPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPersons)).EndInit();
            this.cmsManagmentPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAllPersons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilterType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordTitle;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.ContextMenuStrip cmsManagmentPerson;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendPhoneToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilter;
    }
}