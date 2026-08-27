namespace DVLD_System.ApplicationTestType
{
    partial class FrmManageTestType
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
            this.lblRecordValue = new System.Windows.Forms.Label();
            this.lblRecord = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvAllAppTestType = new System.Windows.Forms.DataGridView();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppTestType)).BeginInit();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(116, 285);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(465, 40);
            this.lblTitle.TabIndex = 36;
            this.lblTitle.Text = "Manage Application Test Types";
            // 
            // lblRecordValue
            // 
            this.lblRecordValue.AutoSize = true;
            this.lblRecordValue.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordValue.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRecordValue.Location = new System.Drawing.Point(209, 638);
            this.lblRecordValue.Name = "lblRecordValue";
            this.lblRecordValue.Size = new System.Drawing.Size(15, 16);
            this.lblRecordValue.TabIndex = 35;
            this.lblRecordValue.Text = "0";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Depth = 0;
            this.lblRecord.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRecord.Location = new System.Drawing.Point(107, 633);
            this.lblRecord.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(85, 24);
            this.lblRecord.TabIndex = 34;
            this.lblRecord.Text = "Records:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(277, 619);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(195, 45);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvAllAppTestType
            // 
            this.dgvAllAppTestType.AllowUserToAddRows = false;
            this.dgvAllAppTestType.AllowUserToDeleteRows = false;
            this.dgvAllAppTestType.AllowUserToOrderColumns = true;
            this.dgvAllAppTestType.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAllAppTestType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAllAppTestType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAppTestType.ContextMenuStrip = this.materialContextMenuStrip1;
            this.dgvAllAppTestType.Location = new System.Drawing.Point(32, 340);
            this.dgvAllAppTestType.Name = "dgvAllAppTestType";
            this.dgvAllAppTestType.ReadOnly = true;
            this.dgvAllAppTestType.RowHeadersWidth = 51;
            this.dgvAllAppTestType.RowTemplate.Height = 26;
            this.dgvAllAppTestType.Size = new System.Drawing.Size(649, 273);
            this.dgvAllAppTestType.TabIndex = 31;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(255, 58);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.Edit_AppTest;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Test Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.App_TestType;
            this.pictureBox1.Location = new System.Drawing.Point(239, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManageTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 687);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordValue);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvAllAppTestType);
            this.Name = "FrmManageTestType";
            this.Load += new System.EventHandler(this.FrmManageTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppTestType)).EndInit();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRecordValue;
        private MaterialSkin.Controls.MaterialLabel lblRecord;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAllAppTestType;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}