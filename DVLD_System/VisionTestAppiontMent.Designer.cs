namespace DVLD_System
{
    partial class VisionTestAppiontMent
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
            this.lblAppointments = new System.Windows.Forms.Label();
            this.dgvAllAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblrecordsVal = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlApplicationInfo1 = new DVLD_System.ctrlApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(342, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driving Test AppionMent";
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointments.Location = new System.Drawing.Point(129, 677);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(137, 21);
            this.lblAppointments.TabIndex = 3;
            this.lblAppointments.Text = "Appointments:";
            // 
            // dgvAllAppointments
            // 
            this.dgvAllAppointments.AllowUserToAddRows = false;
            this.dgvAllAppointments.AllowUserToDeleteRows = false;
            this.dgvAllAppointments.AllowUserToOrderColumns = true;
            this.dgvAllAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllAppointments.Location = new System.Drawing.Point(115, 711);
            this.dgvAllAppointments.Name = "dgvAllAppointments";
            this.dgvAllAppointments.ReadOnly = true;
            this.dgvAllAppointments.RowHeadersWidth = 51;
            this.dgvAllAppointments.RowTemplate.Height = 26;
            this.dgvAllAppointments.Size = new System.Drawing.Size(825, 150);
            this.dgvAllAppointments.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppointmentToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(219, 60);
            // 
            // editAppointmentToolStripMenuItem
            // 
            this.editAppointmentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAppointmentToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Edit_Application;
            this.editAppointmentToolStripMenuItem.Name = "editAppointmentToolStripMenuItem";
            this.editAppointmentToolStripMenuItem.Size = new System.Drawing.Size(218, 28);
            this.editAppointmentToolStripMenuItem.Text = "Edit Appointment";
            this.editAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editAppointmentToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeTestToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.take_test;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(218, 28);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(130, 889);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(90, 18);
            this.lblRecords.TabIndex = 5;
            this.lblRecords.Text = "# Records:";
            // 
            // lblrecordsVal
            // 
            this.lblrecordsVal.AutoSize = true;
            this.lblrecordsVal.Location = new System.Drawing.Point(226, 891);
            this.lblrecordsVal.Name = "lblrecordsVal";
            this.lblrecordsVal.Size = new System.Drawing.Size(43, 17);
            this.lblrecordsVal.TabIndex = 6;
            this.lblrecordsVal.Text = "?????";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(801, 880);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::DVLD_System.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(864, 650);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 48);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Drivers;
            this.pictureBox1.Location = new System.Drawing.Point(398, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.AppID = "????";
            this.ctrlApplicationInfo1.ApplicationLicense = "????";
            this.ctrlApplicationInfo1.CreatedBy = "????";
            this.ctrlApplicationInfo1.Date = "????";
            this.ctrlApplicationInfo1.Fees = "????";
            this.ctrlApplicationInfo1.ID = "????";
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(110, 236);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.PassedTest = "0/3";
            this.ctrlApplicationInfo1.Person = "????";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(814, 418);
            this.ctrlApplicationInfo1.Status = "????";
            this.ctrlApplicationInfo1.StatusDate = "????";
            this.ctrlApplicationInfo1.TabIndex = 0;
            this.ctrlApplicationInfo1.TypeApplication = "????";
            // 
            // VisionTestAppiontMent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 938);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblrecordsVal);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvAllAppointments);
            this.Controls.Add(this.lblAppointments);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Name = "VisionTestAppiontMent";
            this.Text = "VisionTestAppiontMent";
            this.Load += new System.EventHandler(this.VisionTestAppiontMent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlApplicationInfo ctrlApplicationInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.DataGridView dgvAllAppointments;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblrecordsVal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}